//using DogWorker.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWorker.Logic
{
    public class DataAccess
    {
        //셋팅 테이블에서 데이터 가져오기
        //public static List<Settings> GetSettings()
        //{
        //    List<Model.Settings> settings;
        //    using (var ctx = new MRPEntities()) // ctx에 MRP데이터를 넣는 행동 , new MRPEntities를 사용함으로써 커넥션 커맨드 파라미터 역할을 해줌
        //    {
        //        settings = ctx.Settings.ToList();
        //    }// using을 사용함으로써 데이터베이스를 열고 알아서 닫아주는 역할을 함
        //    return settings;

        //}

        //public static int SetSettings(Settings item)
        //{
        //    using (var ctx = new MRPEntities())
        //    {
        //        ctx.Settings.AddOrUpdate(item);
        //        return ctx.SaveChanges(); //COMMIT
        //    }
        //}

        //public static int DelSetting(Settings item)
        //{
        //    using (var ctx = new MRPEntities())
        //    {
        //        var obj = ctx.Settings.Find(item.BasicCode);//DB안에서 데이터를 찾아야 삭제할 수 있음(BasicCode를 통해=>PK이기 때문에)
        //        ctx.Settings.Remove(obj); //DB데이터를 삭제하는 과정
        //        return ctx.SaveChanges();
        //    }
        //}
    }
}
