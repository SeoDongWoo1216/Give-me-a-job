from typing import OrderedDict      #데이터 순서대로 받기
import serial
import string 
import pynmea2          #프로토콜을 위한 파이썬 라이브러리
import paho.mqtt.client as mqtt
import datetime as dt
import uuid
import json

# MQTT 브로커 설정 
dev_id = 'GPS01'
dev_uid = uuid.uuid3(uuid.NAMESPACE_OID, dev_id)
broker_address = '192.168.200.105'

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
        newdata_u = newdata.decode('utf-8')

        if newdata_u[0:6] == "$GPRMC":
            new_gps = pynmea2.parse(newdata_u)  #newdata_u를 파씽
            if new_gps.latitude :
                result = "lat"
            elif new_gps.longitude:
                result = "lon"

            

#데이터를 MQTT로 보내는 메서드
def send_data(result):
    send_msg = ''
    if result == 'lat':
        send_msg = 'latitude'
    elif result == 'lon':
        send_msg = 'longitude'
    else:
        send_msg = 'ERR'

    currtime = dt.datetime.now().strftime('%Y-%m-%d %H:%M:%S.%f')

# groupdata generate
raw_data = OrderedDict()
raw_data['']

# main 
if __name__=='__main__':
    setup()
    send_data('CONN')
    try:
        loop()
    except KeyboardInterrupt:
        pass