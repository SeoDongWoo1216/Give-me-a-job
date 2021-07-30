using DogWorker.Model;
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
        public static List<USERTBL> Getusers()//Model(DB안의 USER이라는 테이블)
        {
            List<USERTBL> users;

            using (var ctx = new DogWorkerEntities()) //ERPModel.Context.cs와 연결이 됨 ctx는 context의 약자
            {
                users = ctx.USERTBL.ToList(); //ctx는 ERPEnitities의 내용을 가지고 있기 때문에 안에 user가 들어있다.
                //위의 문장은 DB의 명령어 SELECT * FROM USER와 같다.
            }
            return users;
        }
        public static List<ScheduleTBL> Getschedules()//Model(DB안의 USER이라는 테이블)
        {
            List<ScheduleTBL> schedules;

            using (var ctx = new DogWorkerEntities()) //ERPModel.Context.cs와 연결이 됨 ctx는 context의 약자
            {
                schedules = ctx.ScheduleTBL.ToList(); //ctx는 ERPEnitities의 내용을 가지고 있기 때문에 안에 user가 들어있다.
                //위의 문장은 DB의 명령어 SELECT * FROM USER와 같다.
            }
            return schedules;
        }

        internal static List<DiaryTBL> GetDiary()
        {
            List<DiaryTBL> diaries;
            using (var ctx = new DogWorkerEntities())
            {
                diaries = ctx.DiaryTBL.ToList();
                foreach (var item in diaries)
                {
                    item.Contents_Summary = item.Contents.Substring(0, 20)+ " ...";
                }
            }
            return diaries;
        }

        public static int Setschedules(ScheduleTBL scheduleTBL)
        {
            using (var ctx = new DogWorkerEntities())
            {
                ctx.ScheduleTBL.AddOrUpdate(scheduleTBL);
                return ctx.SaveChanges(); //COMMIT
            }
        }


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
