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
    public class GrupsDiscontDAL
    {





        public static void Save(GrupsDiscont Tmp)
        {
            string Sql;
            if (Tmp.Gid == -1)
            {
                Sql = $"insert into T_grupsDiscont(Gname,Status,AddDate,Remarks,CompanyCode,CustomerId) " +
                    $"values(@Gname,@Status,@AddDate,@Remarks,@CompanyCode,@CustomerId)";
            }
            else
            {
                Sql = $"Update T_grupsDiscont set " +
                    $"Gname=@Gname," +
                    $"Status=@Status," +
                    $"AddDate = @AddDate ," +
                    $"Remarks=@Remarks," +
                    $"CompanyCode=@CompanyCode,"+
                    $"CustomerId=@CustomerId   Where Gid =@Gid";
            }
            DbContext Db = new DbContext();
            var Obj = new
            {

                Gid = Tmp.Gid,
                Gname = Tmp.Gname,
                Status = Tmp.Status,
                AddDate = Tmp.AddDate,
                Remarks = Tmp.Remarks,
                CompanyCode = Tmp.CompanyCode,
                CustomerId=Tmp.CustomerId
            };


            var lstParam = DbContext.CreateParameters(Obj);





            Db.ExecuteNonQuery(Sql, lstParam);

           
            Db.Close();


        }
        public static List<GrupsDiscont> GetAll()
        {
            List<GrupsDiscont> categorysList = new List<GrupsDiscont>();
            string Sql = "Select * from T_grupsDiscont";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                GrupsDiscont tmp = new GrupsDiscont()
                {
                    Gid = int.Parse(Dt.Rows[i]["Gid"].ToString()),
                    Gname = Dt.Rows[i]["Gname"].ToString(),
                    Status = bool.Parse(Dt.Rows[i]["Status"].ToString()),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString()),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    CompanyCode = int.Parse(Dt.Rows[i]["CompanyCode"].ToString()),
                    CustomerId = Dt.Rows[i]["CustomerId"].ToString(),
                };
                categorysList.Add(tmp);
            }
            Db.Close();
            return categorysList;
        }
        public static GrupsDiscont GetById(int Id)
        {
            GrupsDiscont tmp = null;
            string Sql = $"Select * from T_grupsDiscont Where Gid  = {Id}";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new GrupsDiscont()
                {
                    Gid = int.Parse(Dt.Rows[0]["Gid"].ToString()),
                    Gname = Dt.Rows[0]["Gname"].ToString(),
                    Status = bool.Parse(Dt.Rows[0]["Status"].ToString()),
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"].ToString()),
                    Remarks = Dt.Rows[0]["Remarks"].ToString(),
                    CompanyCode = int.Parse(Dt.Rows[0]["CompanyCode"].ToString()),
                    CustomerId = Dt.Rows[0]["CustomerId"].ToString(),

                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  T_grupsDiscont Where Gid  = {Id}";
            DbContext Db = new DbContext();
            int Total = Db.ExecuteNonQuery(Sql);
            Db.Close();
            if (Total > 0)
                return 1;
            else
                return -1;
        }
   }   }