## 취업시켜조 회의록
- 많은 분들의 정리가 필요합니다.
- 진행사항, 회의했던 얘기들을 기록하기위해 리드미를 만듭니다.

----------------------------

#### 21-06-08
- UI는 .NET 으로 제작 
- GPS 진행은 프로젝트 깃허브에 업로드 
- 지도 API는 선별 필요
- 회의는 18일 이후 진행 (진행 사항은 공유) => MQTT 미니프로젝트 진행하면서 통신 기술을 익히기 위함   

##### UI 1차 구성   
<img src = "https://github.com/SeoDongWoo1216/Give-me-a-job/blob/main/images/ui.png" width="50%" height="50%">    
<img src = "https://github.com/SeoDongWoo1216/Give-me-a-job/blob/main/images/ui1.png" width="50%" height="50%">

#### 21-06-24
- 라즈베리파이를 이용한 GPS(NEO-6M) 모듈 데이터 값 받아오기 완료(경도, 위도 가져옴)
- 오븐앱을 통한 UI 샘플 제작 : [샘플](https://ovenapp.io/view/doXSWgLZQuiVAfsfyqvjr9SsY4EY8I9d/Yb6El)
- UI는 WPF 결정 : 확장성이나 사용할 특정 다수를 위해서는 웹이 좋지만, 우리가 스타트업이나 창업하는게 아니기때문에 WPF로 결정
- 실시간 좌표값을 UI에 보여줄 수 있는지에 대해(카카오맵 API 사용 권장하심) => 강사님께 여쭤보니 된다고 하셨음.. 자료조사 필요할듯
- DB 구성 : 각각의 화면에 따른 테이블 생성 논의 필요

#### 21-06-25
##### 🚦구현 전체 구성   
- UI(WPF), DB, 하드웨어(GPS)   
##### 금일 회의 내용   
- WPF 화면 구성   
  - 공통화면 : Main화면, LoginView, ButtonView   
      - Main : 신청 / 코스 / 산책일지 / 계정관리 / 종료 버튼   
      - LoginView : ID, PW (텍스트박스), 회원가입, 로그인(버튼)   
      - ButtonView : User(이용자-견주) / Worker(도그워커)   
  - User 화면   
    - 신청 / 산책일지 / 계정관리 / 종료 버튼 (코스비활성)   
    - Information View : 이름, 전화번호, (주소), 반려견 이름, 반려견 나이, 반려견 종, 반려견 특이사항   
    - 신청 View : 원하는 날짜 및 시간 , 원하는 도그워커, next버튼      
    - 코스 View : GPS화면, 시간 선택, '뒤로' , '신청' 버튼 , '신청완료'팝업      
    - 산책 일지 View : Worker의 산책 일지 View최종본   
    - 계정 관리 View : Information View에서 '수정' , '완료', '수정이 완료되었습니다'팝업   
    - 종료버튼 : '종료하시겠습니까'팝업, 'Yes/No' 버튼   
  - Worker 화면    
    - 신청 / 코스 / 산책일지 / 계정관리 / 종료 버튼   
    - Information View : 이름, 나이, 전화번호, 경력   
    - 신청 View : 산책 가능한 날짜 및 시간, 신청 대기, 신청 완료(매칭데이터연결그리드)   
    - 코스 View : '시작', '종료'버튼, 실시간 데이터 좌표 GPS화면   
    - 산책 일지 View : 최종 GPS화면, 일지 텍스트 박스   
    - 계정 관리 View : Information View에서 '수정' , '완료', '수정이 완료되었습니다'팝업   
    - 종료버튼 : '종료하시겠습니까'팝업, 'Yes/No' 버튼    

- DB구성   
  - 사람(User, Worker) 테이블   
  - 반려견 테이블   
  - 예약 테이블   
