from typing import OrderedDict      #데이터 순서대로 받기
import time
import serial
import string 
import pynmea2          #프로토콜을 위한 파이썬 라이브러리
import paho.mqtt.client as mqtt
import datetime as dt
import uuid
import json

# MQTT 브로커 설정 
dev_id = 'GPS01'
dev_uid = str(uuid.uuid3(uuid.NAMESPACE_OID, dev_id))
broker_address = '210.119.12.97'    #브로커 주소
pub_topic = 'gps01/machine1/data/'  #MQTT topic

#send-data 구성 : Mosquito를 활영하여 MQTT방식으로 json형태의 데이터 전달
#Mosquito : MQTT 브로커중에 대표적인 프로그램 
#-> 클라이언트에서 메시지를 받아서 전달해주는 역할 

def send_data(result,lat,lon):
    if result == 'LON':
        send_msg = 'OK'
    elif result == 'CONN':
        send_msg = 'CONN'
    else:
        send_msg = 'ERROR'

    #우리가 원하는 날짜 출력
    currtime = dt.datetime.now().strftime('%Y-%m-%d %H:%M:%S.%f')

    #json data generate
    raw_data = OrderedDict()    #데이터 순서대로 받기
    raw_data['dev_id'] = dev_id
    #raw_data['dev_uid'] = dev_uid
    raw_data['prc_time'] = currtime
    raw_data['prc_msg'] = send_msg
    raw_data['gps_lon'] = lon
    raw_data['gps_lat'] = lat

    #publish data 변환 
    pub_data = json.dumps(raw_data, ensure_ascii=False, indent='\t')

    #mqtt_publish
    print(pub_data)
    client2.publish(pub_topic, pub_data)

# GPS 데이터 받아오기 
def loop():
    result = ""

    while True:
        port = "/dev/ttyAMA0"      # 우리가 사용하는 시리얼 이름 
        ser = serial.Serial(port, baudrate=9600, timeout=0.5)
        #(포토, 전송 속도 = 9600, 시간초과=0.5)
        dataout = pynmea2.NMEAStreamReader()
        #데이터 출력을 NMEA로 출력하겠음 
        #NMEA(위치전송 규격)문장의 스트림을 데이터 처리 가능 
        #GPGGA - 위동,경도 알려줌 
        newdata = ser.readline()
        newdata_u = ''
        try:
            newdata_u = newdata.decode('utf-8') 
        except Exception as e:
            pass

        if newdata_u == '': continue
        if newdata_u[0:6] == "$GPRMC":
            new_gps = pynmea2.parse(newdata_u)  #newdata_u를 파씽
            result = "LON"
            #if new_gps.latitude :
               #lat = "lat"
            #if new_gps.longitude:
               #lon = "lon"
            lat = new_gps.latitude
            lon = new_gps.longitude
            #gps = "Lat : " + str(lat) + "Lon : " + str(lon)
            send_data(result,lat,lon)
            
        time.sleep(3)
        

#MQTT 초기화
client2 = mqtt.Client(dev_id)
client2.connect(broker_address, 1883)   #브로커가 서버에 접속할 수 있게 해줌
print('MQTT Client connected')  #접속 확인 문 

# main 
if __name__=='__main__':
    send_data('CONN',None,None)
    try:
        loop()
    except KeyboardInterrupt:
        pass