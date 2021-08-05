from flask import Flask
import folium
import pymssql
import time

# DB 서버 주소
server = 'PC01'
# 데이터 베이스 이름
database = 'DogWorker'
# 접속 유저명
username = 'sa'
# 접속 유저 패스워드
password = 'mssql_p@ssw0rd!'
# MSSQL 접속
cnxn =  pymssql.connect(server , username, password, database)
cursor = cnxn.cursor()
# SQL문 실행
coordinate=[]   #좌표 변수

def newweb():
    while True:

        cursor.execute('SELECT Lat,Lon FROM GPSTBL;')
    # 데이타를 하나씩 Fetch하여 출력
        row = cursor.fetchone() #다음 데이터로 넘어가는 라이브러리 함수


        while row:
            coordinate.append([row[0],row[1]])
            row = cursor.fetchone()
        if row is None:
            break
#


app = Flask(__name__)

@app.route('/')
def index():
    newweb()
    start_coords = (35.11744755557854, 129.09058121349395)
    folium_map = folium.Map(location=coordinate[-1], zoom_start=18)
    folium.PolyLine(locations=coordinate).add_to(folium_map)    #연결라인 찍어주기
    return folium_map._repr_html_()


if __name__ == '__main__':
    app.run(
        host = "127.0.0.1",
        port = 8080,
        debug=True)
    
# 연결 끊기
cnxn.close()