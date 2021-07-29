from typing import OrderedDict      #데이터 순서대로 받기
import serial
import string 
import pynmea2
import paho.mqtt.client as mqtt
import datetime as dt

while True:
    port = "/dev/ttyAMA0"
    ser = serial.Serial(port, baudrate=9600, timeout=0.5)
    dataout = pynmea2.NMEAStreamReader()
    newdata = ser.readline()
    #print(newdata) 

    newdata_u = newdata.decode('utf-8')
    #print(newdata_u)
    
    if newdata_u[0:6] == "$GPRMC":
        new_gps = pynmea2.parse(newdata_u)
        lat = new_gps.latitude  
        lon = new_gps.longitude  
        gps = "Latitude = " + str(lat) + " Longitude = " + str(lon)
        # print(gps)

# 그런데 안끝내고 계속 데이터를 받을 건가? 
# 산책이 끝나서 종료 버튼을 누르면 종료 되어야할텐데 
# 이건 여기서 하는게 아닐까? (WPF에서 하는 건가)

# 데이터를 MQTT로 보내는 메서드
def send_date(result):
    pass 