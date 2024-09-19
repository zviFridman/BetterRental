using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Data;
using System.Data.SqlClient;
using BLL;

namespace DAL
{
    public class WorkersDAL
    {
        public static void Save(Workers Tmp)
        {
            string Sql;
            if (Tmp.Wid == -1)
            {
                Sql = $"insert into T_workers(Wfname,Wlname,Wadress,Wemail,Wphone,Wjob,SaleryHour,SaleryMonth,Remarks,AddDate,Status,CompanyCode) " +
                    $"values(@Wfname,@Wlname,@Wadress,@Wemail,@Wphone,@Wjob,@SaleryHour,@SaleryMonth,@Remarks,@AddDate,@Status,@CompanyCode)";
            }
            else
            {
                Sql = $"Update T_workers set " +
                    $"Wfname=@Wfname," +
                    $"Wlname=@Wlname," +
                    $"Wadress=@Wadress," +
                     $"Wemail=@Wemail," +
                     $"Wphone=@Wphone," +
                     $"Wjob=@Wjob," +
                     $"SaleryHour=@SaleryHour," +
                     $"SaleryMonth=@SaleryMonth," +
                      
                
                      $"Remarks=@Remarks," +
                        $"CompanyCode=@CompanyCode," +
                          $"AddDate=@AddDate," +
                    $"Status=@Status  Where Wid=@Wid";
            }
            DbContext Db = new DbContext();


            var Obj = new
            {
                Wfname=Tmp.Wfname,
                Wlname=Tmp.Wlname,
                Wadress=Tmp.Wadress,
                Wemail=Tmp.Wemail,
                Wphone=Tmp.Wphone,
                Wjob=Tmp.Wjob,
                Wid=Tmp.Wid,
                SaleryHour=Tmp.SaleryHour,
                SaleryMonth=Tmp.SaleryMonth,
                Remarks=Tmp.Remarks,
                CompanyCode=Tmp.CompanyCode,
                AddDate=Tmp.AddDate,
                Status=Tmp.Status,
            };


            var lstParam = DbContext.CreateParameters(Obj);





            Db.ExecuteNonQuery(Sql, lstParam);
            

            
            Db.Close();
        }
        public static List<Workers> GetAll()
        {
            List<Workers> WorkersList = new List<Workers>();
            string Sql = "Select * from T_workers";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Workers tmp = new Workers()
                {
                    Wfname = Dt.Rows[i]["Wfname"].ToString(),
                    Wlname = Dt.Rows[i]["Wlname"].ToString(),
                    Wadress = Dt.Rows[i]["Wadress"].ToString(),
                    Wemail = Dt.Rows[i]["Wemail"].ToString(),
                    Wphone = Dt.Rows[i]["Wphone"].ToString(),
                    Wjob = Dt.Rows[i]["Wjob"].ToString(),
                    Wid = int.Parse(Dt.Rows[i]["Wid"].ToString()),
                    SaleryHour = float.Parse(Dt.Rows[i]["SaleryHour"].ToString()),
                    SaleryMonth = float.Parse(Dt.Rows[i]["SaleryMonth"].ToString()),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString()),
                    Status = bool.Parse(Dt.Rows[i]["Status"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[i]["CompanyCode"].ToString()),
                };
                WorkersList.Add(tmp);
            }
            Db.Close();
            return WorkersList;
        }
        public static Workers GetById(int Id)
        {
            Workers tmp = null;
            string Sql = $"Select * from T_workers Where Wid = {Id}";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Workers()
                {
                    Wfname = Dt.Rows[0]["Wfname"].ToString(),
                    Wlname = Dt.Rows[0]["Wlname"].ToString(),
                    Wadress = Dt.Rows[0]["Wadress"].ToString(),
                    Wemail = Dt.Rows[0]["Wemail"].ToString(),
                    Wphone = Dt.Rows[0]["Wphone"].ToString(),
                    Wjob = Dt.Rows[0]["Wjob"].ToString(),
                    Wid = int.Parse(Dt.Rows[0]["Wid"].ToString()),
                    SaleryHour = float.Parse(Dt.Rows[0]["SaleryHour"].ToString()),
                    SaleryMonth = float.Parse(Dt.Rows[0]["SaleryMonth"].ToString()),
                    Remarks = Dt.Rows[0]["Remarks"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"].ToString()),
                    Status = bool.Parse(Dt.Rows[0]["Status"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[0]["CompanyCode"].ToString()),
                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  T_workers Where Wid = {Id}";
            DbContext Db = new DbContext();
            int Total = Db.ExecuteNonQuery(Sql);
            Db.Close();
            if (Total > 0)
                return 1;
            else
                return -1;
        }

    }
}