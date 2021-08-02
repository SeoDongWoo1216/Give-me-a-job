import serial
import time 
import string
import pynmea2
 
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
        print(gps)
        
    time.sleep(3)
