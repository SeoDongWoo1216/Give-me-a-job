using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;


namespace GPSDataTool
{
    public partial class FrmMain : Form
    {
        MqttClient client;
        string connectionString; // DB연결문자열 | MQTT Broker address
        ulong lineCount; // -가 없는 long값 .라인 넘버를 표시해주는 변수
        delegate void UpdateTextCallback(string message); // 스레드상 윈폼 Rtb 텍스트 박스에 출력시 필요.
                                                          // 추가 설명 MQTT 클라이언트 상에서 메세지를 보내는 것이랑 winform 데이터 텍스트에 텍스트 데이터 메세지를 올릴때 충돌을 방지하기 위함 
                                                          


        Stopwatch sw = new Stopwatch(); //winform 안에 있는 스탑워치를 가르키는 변수 

        public FrmMain()
        {
            InitializeComponent();
            InitializeAllData(); // 화면상에 우리가 만들 값,변수들을 초기화하기 위해 만든 함수
        }

        private void InitializeAllData()
        {
            connectionString = $"Data Source={TxtConnectionString.Text};Initial Catalog=DogWorker;" + //서버탐색기에서 DogWorker DB를 연결해서 값을 그냥 복사해오기
                                $"User ID=sa;password=mssql_p@ssw0rd!";

            lineCount = 0;
            BtnConnect.Enabled = true;
            BtnDisconnect.Enabled = false;
            IPAddress brokerAdress; // using System.Net 라이브러리를 사용 

            try
            {
                brokerAdress = IPAddress.Parse(TxtConnectionString.Text); // 210.119.12.94가 string 형식인데 이것을 IP형식으로 바꿔주는 코드, ip형식이 아닌 경우에 IPAddress.parse안에 있는 tryparse로 넘어가면서 멈추게 됨
                client = new MqttClient(brokerAdress); // IP형식으로 바뀐 210.119.12.94를 MqttClient
                client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived; //MqttMsgPublishReceived란 누군가 발행한 데이터를 받는 코드(subscribe와 다른 점은 따로 설명해주시지 않음)

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());// 오류가 난 부분을 메세지 박스에 표시
            }
            
            Timer.Enabled = true;
            Timer.Interval = 1000; // 1000ms = 1sec 타이머를 1초마다 돌게 함
            Timer.Tick += Timer_Tick; // Timer.Tick<- interval(1초)마다 어떤 행동을 하는 것
            Timer.Start(); // 타이머도 돌아가야함
            
        }
        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) //  MqttMsgPublishEventArgs e는 publish한것을 받는 메세지를 뜻함. 그래서 try 문 첫줄에 e.Message를 사용함
        {
            try
            {
                var message = Encoding.UTF8.GetString(e.Message); // publish할 대 UTF-8로 만들었기 때문에 encoding을 해줘야함
                UpdateText($">>>>> 받은 메세지 : {message}"); // RichTextbox에 넣어줌(여러 군데 사용되기 때문에 UpdateText라는 함수를 사용함)
                                                         // 여기까지 하게 되면 UI스레드랑 winform 화면 gui 스레드랑 (Richtextbox 메세지 출력하는 부분) MQTTMsgPublishReceived 발행한 데이터를 받는 스레드랑 겹치기 때문에 충돌이 남
               
                // message(json) > C#
                var currentData = JsonConvert.DeserializeObject<Dictionary<string, string>>(message); // publish된 데이터를 받은 저장한 변수가 message이고 MQTT publish의 과정을 통해 데이터가 직렬화가 됨
                                                                                                      // 직렬화란 객체를 전송 가능한 형태로 만드는 것을 의미함, 네트워크로 보낼 때 꼭 직렬화가 되어있어야 함
                                                                                                      // 그 message를 (Deserialize)역직렬화를 시켜 객체로의 형태로 만드는 것
                                                                                                      // JSON 형식인 key : value
                PrcInputDataToList(currentData);

                sw.Stop();
                sw.Reset(); //메세지가 하나 올 때마다 스탑워치를 다시 시작시켜주기 위한 코드
                sw.Start();
                /*생략한 부분
                //var currentData = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);// 무슨 코드인지 모르겠음...
                //PrcInputDataToList(currentData);

                
                생략한 부분*/
            }
            catch (Exception ex)
            {
                UpdateText($">>>>> Error : {ex.Message}");
            }
        }
        private void UpdateText(string message) // 위에서 스레드끼리 겹치는 부분을 해결하기 위해 만들어준 함수
                                                // 위에서 선언한 대리자를 사용하기

        {
            if (RtbSubscr.InvokeRequired) //invoke= 호출(스레드가 겹치면서 오류가 날 수 있는데 이걸 막기 위해서 사용해주는 것으로 생각됨)
                                          //invokeRequired가 true인 경우에 대리자를 사용하여 스레드끼리 충돌하는 것을 막아준다.
            {
                UpdateTextCallback callback = new UpdateTextCallback(UpdateText);
                this.Invoke(callback, new object[] { message });
            }
            else
            {
                lineCount++;
                RtbSubscr.AppendText($"{lineCount} : {message}\n");// \n을 통해서 텍스트박스에 안에 나오는 값이 따로 떨어져서 나오게 만듬
                RtbSubscr.ScrollToCaret(); // 메세지가 쌓이면 스크롤을 알아서 내려주는 역할
            }
        }
        
        private void PrcInputDataToList(Dictionary<string, string> currentData)
        {
            if (currentData["prc_msg"] == "OK" )// ["PRC_MSG"] => 뭔지 모르겠음.. // connect가 될 때 들어오는 데이터는 굳이 iotData에 저장할 필요가 없으므로
                iotData.Add(currentData);
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            LblResult.Text = sw.Elapsed.Seconds.ToString(); // 스탑워치에서 기록한 시간을 Statusstrip에 기록함
            if (sw.Elapsed.Seconds >= 5) // 스탑워치가 5초가 될때 스탑워치를 멈추고 리셋을 시켜주고 DB에 넣어준다.
            {
                sw.Stop();
                sw.Reset();
                // TODO : 실제 처리 프로세스 실행
                //UpdateText("처리!!");
                PrcCorrectDataToDB();
            }
        }
        

        // 여러 데이터 중 최종 데이터만 DB입력처리 메서드
        private void PrcCorrectDataToDB()
        {
            if (iotData.Count > 0)
            {
                var correctData = iotData[iotData.Count - 1];// 제일 마지막 데이터를 correctData 변수에 넣어줌
                // DB에 입력
                //UpdateText("DB 처리");
                using (var conn = new SqlConnection(connectionString))
                {
                    var prcResult = correctData["prc_msg"] == "OK" ? 1 : 0;

                    Console.WriteLine( correctData["gps_lon"]);
                    string strUpQry = $@"INSERT INTO GPSTBL (Lon, Lat, CrtTime)
                                         VALUES ('{correctData["gps_lon"]}','{correctData["gps_lat"]}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
                                                       

                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(strUpQry, conn);
                        if (cmd.ExecuteNonQuery() == 1)
                            UpdateText("[DB] 센싱값 Update 성공");
                        else
                            UpdateText("[DB] 센싱값 Update 실패");
                    }
                    catch (Exception ex)
                    {
                        UpdateText($">>>>> DB ERROR !! : {ex.Message}");
                    }
                }
            }

            iotData.Clear(); // 데이터 모두 삭제
        }

        

        List<Dictionary<string, string>> iotData = new List<Dictionary<string, string>>(); // JSON으로 변환된 데이터이기 때문에(key:value) List/Dictionary 형식으로 저장하기 위한 변수

        // 라즈베리에서 들어온 메시지를 전역리스트에 입력하는 메서드
        

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            client.Connect(TxtClientID.Text); // SUBSCR01 <= 클라이언트 이름 //client(MQTT)는 210.119.12.94 IP와 연결되어있다. 
            UpdateText(">>>>> Client Connected");
            client.Subscribe(new string[] { TxtSubscriptionTopic.Text }, // 토픽을 여러개 받을 수 있기 때문에 new string[] 배열형식을 넣는다. TxtSubscriptionTopic.Text은 DogWorker/machine1/data/ 이 내용임.
                new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE }); //QOS(Quality Of Service) , MqttMsgBase는 여러 개의 메서드를 가지는데 우리가 사용한 LEVEL_AT_MOST_ONCE(0과 같다)는 한번만 보내고 마는것
                                                                    //LEVEL_AT_LEAST_ONCE는 적어도 한번은 보내는 것
                                                                    //이 부분 모르겠으면 https://www.ibm.com/docs/ko/ibm-mq/9.0?topic=ssfksj-9-0-0-com-ibm-mq-dev-doc-q029090--htm 참고하기
            UpdateText(">>>>> Subscribing to : " + TxtSubscriptionTopic.Text);

            BtnConnect.Enabled = false;
            BtnDisconnect.Enabled = true;
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            client.Disconnect();
            UpdateText(">>>>> Client Disonnected");

            BtnConnect.Enabled = true;
            BtnDisconnect.Enabled = false;
        }

        


    }
}
