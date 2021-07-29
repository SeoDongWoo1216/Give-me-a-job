## 취업시켜조 회의록
- 많은 분들의 정리가 필요합니다.
- 진행사항, 회의했던 얘기들을 기록하기위해 리드미를 만듭니다.

---------------------------

#### 🚩21-06-08
- UI는 .NET 으로 제작 
- GPS 진행은 프로젝트 깃허브에 업로드 
- 지도 API는 선별 필요
- 회의는 18일 이후 진행 (진행 사항은 공유) => MQTT 미니프로젝트 진행하면서 통신 기술을 익히기 위함   

##### UI 1차 구성   
<img src = "https://github.com/SeoDongWoo1216/Give-me-a-job/blob/main/%ED%9A%8C%EC%9D%98%EC%9D%BC%EC%A7%80/Image/UI/ui(Tk).png" width="50%" height="50%">    
<img src = "https://github.com/SeoDongWoo1216/Give-me-a-job/blob/main/%ED%9A%8C%EC%9D%98%EC%9D%BC%EC%A7%80/Image/UI/ui1(Tk).png" width="50%" height="50%">

#### 🚩21-06-24
- 라즈베리파이를 이용한 GPS(NEO-6M) 모듈 데이터 값 받아오기 완료(경도, 위도 가져옴)
- 오븐앱을 통한 UI 샘플 제작 : [샘플](https://ovenapp.io/view/k2pj3Aw4Yk3ALgxk6fzoN3IziTbctloR#LKVqJ)
- UI는 WPF 결정 : 확장성이나 사용할 특정 다수를 위해서는 웹이 좋지만, 우리가 스타트업이나 창업하는게 아니기때문에 WPF로 결정
- 실시간 좌표값을 UI에 보여줄 수 있는지에 대해(카카오맵 API 사용 권장하심) => 강사님께 여쭤보니 된다고 하심(자료조사 필요할듯)
- DB 구성 : 각각의 화면에 따른 테이블 생성 논의 필요

#### 🚩21-06-25
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

- DB 구성  
  - 사람(User, Worker) 테이블   
  - 반려견 테이블   
  - 도그워커 타임 테이블
  - 유저 타임 테이블
  - 노트 테이블
  - 실시간 맵 테이블
  - 세팅 테이블

--------------------------------------------------------------------------------------

#### 🚩21-06-28   
1. Oven 활용한 UI 샘플 만들기   
2. 테이블 기술서 작성하기   
  - 관리자(setting), 사람 (Human), 반려견(Dog), 일지(Note), 실시간 지도(RealtimeMap), 이용자 신청(UserTimetable), 도그워커 신청(DogWalkerTimetable)    
  - 관리자 테이블 : 견종 및 특이사항 코드관리   
  - 사람 : [S- 관리자, W- 도그워커, U- 견주] 권한으로 이용자 분리   
  - 반려견 : M-남, W-여, N-중성   
  
#### 💈 이용자 서비스 주 내용    
  - 실시간 산책 경로 파악 가능   
  - 실시간 산책 상황 파악 가능(간식, 배변, 특이사항등)   
  - 날짜 및 시간별 산책 list확인 가능   

#### 📟 DB 설계서 작성 ([링크](https://github.com/SeoDongWoo1216/Give-me-a-job/blob/main/%EC%84%A4%EA%B3%84%EC%84%9C/%ED%85%8C%EC%9D%B4%EB%B8%94_%EA%B8%B0%EC%88%A0%EC%84%9C_V1.0.xlsx))

#### 🎬Oven UI  ([링크](https://github.com/SeoDongWoo1216/Give-me-a-job/blob/main/%ED%9A%8C%EC%9D%98%EC%9D%BC%EC%A7%80/Image/UI/Readme.md))

------------------------------------------------------------------------------------------------------------

#### 🚩21-06-30
1. 중간보고 PPT 제작
2. 오븐을 토대로 UI 제작(WPF) 
3. 요구사항 정의서 작성 ([링크](https://github.com/SeoDongWoo1216/Give-me-a-job/blob/main/%EC%84%A4%EA%B3%84%EC%84%9C/%EC%9A%94%EA%B5%AC%EC%82%AC%ED%95%AD_%EC%A0%95%EC%9D%98%EC%84%9C.xlsx)) <br>


#### 🚩21-07-12
1. 통신 모듈 조사 및 구매하기 : 블루투스, 와이파이, 장거리통신, USIM(?) <br>
구매사이트 : [디바이스마트](https://www.devicemart.co.kr/main/index?gclid=Cj0KCQjwraqHBhDsARIsAKuGZeGGaNTRgKOz7LehG0nAj2I1PNSToGUBaA_SGckcKS_F2yM5jMUTzmUaAtATEALw_wcB), [엘레파츠](https://www.eleparts.co.kr/main/index)

#### 🚩21-07-28
취업 이슈로인해 기능 축소
1. UI는 도그워커로 만들예정(관리자모드)
2. DB는 도그워커측면으로 축소
3. WPF(UI)도 수정 예정
4. GPS 모듈 테스트 -> MQTT로 GPS 데이터값을 받을 수 있는지 테스트 필요   

#### 🚩21-07-29   
1. UI ver2. 전체 틀 제작   
<img src = "https://github.com/SeoDongWoo1216/Give-me-a-job/blob/main/%ED%9A%8C%EC%9D%98%EC%9D%BC%EC%A7%80/Image/UI/0729ui.jpg" width="50%" height="50%">   
2. 테이블 기술서 ver2. 작성   
 
