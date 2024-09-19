using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using System.Data.SqlClient;
using BLL;
using System.Data;


namespace DAL
{
    public class orderDetalsDAL
    {
        public static void Save(OrderDetals Tmp)
        {
            string Sql;
            if (Tmp.Odid == -1)
            {
                Sql = $"insert into T_orderDetals(Pid,Pname,CountOD,CountReturn,CountNotUse,Oid,AddDate,Status,Remarks,SumProduct,CompanyCode) " +
                    $"values(@Pid,@Pname,@CountOD,@CountReturn,@CountNotUse,@Oid,@AddDate,@Status,@Remarks,@SumProduct,@CompanyCode)";
            }
            else
            {
                Sql = $"Update T_orderDetals set " +
                    $"Pid=@Pid," +
                    $"Pname=@Pname," +
                     $"CountOD=@CountOD," +
                     $"CountNotUse=@CountNotUse," +
                     $"CountReturn=@CountReturn," +
                     $"Oid=@Oid," +
                     $"SumProduct=@SumProduct," +

                      $"Remarks=@Remarks," +
                        $"CompanyCode=@CompanyCode," +
                          $"AddDate=@AddDate," +
                    $"Status=@Status  Where Odid=@Odid";
            }
            DbContext Db = new DbContext();
            var Obj = new
            {
                Odid = Tmp.Odid,
                Pid = Tmp.Pid,
                Pname=Tmp.Pname,
                CountOD = Tmp.CountOD,
                CountReturn = Tmp.CountReturn,
                CountNotUse = Tmp.CountNotUse,
                Oid = Tmp.Oid,
                AddDate = Tmp.AddDate,
                Status = Tmp.Status,
                Remarks = Tmp.Remarks,
                SumProduct = Tmp.SumProduct,
                CompanyCode = Tmp.CompanyCode,
            };


            var lstParam = DbContext.CreateParameters(Obj);





            Db.ExecuteNonQuery(Sql, lstParam);


            
            Db.Close();

        }
        public static List<OrderDetals> GetAll()
        {
            List<OrderDetals> orderDetalsList = new List<OrderDetals>();
            string Sql = "Select * from T_orderDetals";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                OrderDetals tmp = new OrderDetals()
                {
                    Odid = int.Parse(Dt.Rows[i]["Odid"].ToString()),
                    Pid = int.Parse(Dt.Rows[i]["Pid"].ToString()),
                    Pname = Dt.Rows[i]["Pname"].ToString(),
                    CountOD = int.Parse(Dt.Rows[i]["CountOD"].ToString()),
                    CountReturn = int.Parse(Dt.Rows[i]["CountReturn"].ToString()),
                    CountNotUse = int.Parse(Dt.Rows[i]["CountNotUse"].ToString()),
                    Oid = int.Parse(Dt.Rows[i]["Oid"].ToString()),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString()),
                    Status = bool.Parse(Dt.Rows[i]["Status"].ToString()),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    SumProduct = int.Parse(Dt.Rows[i]["SumProduct"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[i]["CompanyCode"].ToString()),
                };
                orderDetalsList.Add(tmp);
            }
            Db.Close();
            return orderDetalsList;
        }
        public static OrderDetals GetById(int Id)
        {
            OrderDetals tmp = null;
            string Sql = $"Select * from T_orderDetals Where Odid = {Id}";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new OrderDetals()
                {
                    Odid = int.Parse(Dt.Rows[0]["Odid"].ToString()),
                    Pid = int.Parse(Dt.Rows[0]["Pid"].ToString()),
                    Pname = Dt.Rows[0]["Pname"].ToString(),
                    CountOD = int.Parse(Dt.Rows[0]["CountOD"].ToString()),
                    CountReturn = int.Parse(Dt.Rows[0]["CountReturn"].ToString()),
                    CountNotUse = int.Parse(Dt.Rows[0]["CountNotUse"].ToString()),
                    Oid = int.Parse(Dt.Rows[0]["Oid"].ToString()),
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"].ToString()),
                    Status = bool.Parse(Dt.Rows[0]["Status"].ToString()),
                    Remarks = Dt.Rows[0]["Remarks"].ToString(),
                    SumProduct = int.Parse(Dt.Rows[0]["SumProduct"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[0]["CompanyCode"].ToString()),
                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  T_orderDetals Where Odid = {Id}";
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