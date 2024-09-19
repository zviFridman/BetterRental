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
    public class OrdersDal
    {
        public static void Save(Orders Tmp)
        {
            string Sql;
            if (Tmp.Oid == -1)
            {
                Sql = $"insert into T_orders(Odate,CollectionDate,ReturnDate,CAid,PlaceToSend,SumOrder,Remarks,AddDate,StatusOrder,StatusRedy,StatusPay,Collection,CompanyCode) " +
                    $"values(@Odate,@CollectionDate,@ReturnDate,@CAid,@PlaceToSend,@SumOrder,@Remarks,@AddDate,@StatusOrder,@StatusRedy,@StatusPay,@Collection,@CompanyCode)";
            }
            else
            {
                Sql = $"Update T_orders set " +
                        $"Odate=@Odate," +
                        $"CollectionDate=@CollectionDate," +
                    $"ReturnDate=@ReturnDate," +
                     $"CAid=@CAid," +
                       $"PlaceToSend=@PlaceToSend," +
                      $"SumOrder=@SumOrder," +
                        $"Remarks=@Remarks," +
                      $"AddDate=@AddDate," +
                     $"StatusOrder=@StatusOrder," +
                      $"StatusRedy=@StatusRedy," +
                     $"StatusPay=@StatusPay," +
                       $"Collection=@Collection," +
                        $"CompanyCode=@CompanyCode  Where Oid=@Oid";
            }

            DbContext Db = new DbContext();
            var Obj = new
            {
                Odate = Tmp.Odate,
                CollectionDate = Tmp.CollectionDate,
                ReturnDate = Tmp.ReturnDate,
                CAid = Tmp.CAid,
                Oid = Tmp.Oid,
                PlaceToSend = Tmp.PlaceToSend,
                SumOrder = Tmp.SumOrder,
                Remarks = Tmp.Remarks,
                AddDate = Tmp.AddDate,

                StatusOrder = Tmp.StatusOrder,
                StatusRedy = Tmp.StatusRedy,
                StatusPay = Tmp.StatusPay,
                Collection = Tmp.Collection,
                CompanyCode = Tmp.CompanyCode,
               
            };


            var lstParam = DbContext.CreateParameters(Obj);





            Db.ExecuteNonQuery(Sql, lstParam);


           
            Db.Close();

        }
        public static List<Orders> GetAll()
        {
            List<Orders> ordersList = new List<Orders>();
            string Sql = "Select * from T_orders";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Orders tmp = new Orders()
                {
                    Odate = DateTime.Parse(Dt.Rows[i]["Odate"].ToString()),
                    CollectionDate = DateTime.Parse(Dt.Rows[i]["CollectionDate"].ToString()),
                    ReturnDate = DateTime.Parse(Dt.Rows[i]["ReturnDate"].ToString()),
                    CAid = int.Parse(Dt.Rows[i]["CAid"].ToString()),
                    Oid = int.Parse(Dt.Rows[i]["Oid"].ToString()),
                    PlaceToSend = Dt.Rows[i]["PlaceToSend"].ToString(),
                    SumOrder = int.Parse(Dt.Rows[i]["SumOrder"].ToString()),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString()),
                    StatusOrder = bool.Parse(Dt.Rows[i]["StatusOrder"].ToString()),
                    StatusRedy = bool.Parse(Dt.Rows[i]["StatusRedy"].ToString()),
                    StatusPay = bool.Parse(Dt.Rows[i]["StatusPay"].ToString()),
                    Collection = bool.Parse(Dt.Rows[i]["Collection"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[i]["CompanyCode"].ToString()),
                };
                ordersList.Add(tmp);
            }
            Db.Close();
            return ordersList;
        }
        public static Orders GetById(int Id)
        {
            Orders tmp = null;
            string Sql = $"Select * from T_orders Where Oid = {Id}";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Orders()
                {
                    Odate = DateTime.Parse(Dt.Rows[0]["Odate"].ToString()),
                    CollectionDate = DateTime.Parse(Dt.Rows[0]["CollectionDate"].ToString()),
                    ReturnDate = DateTime.Parse(Dt.Rows[0]["ReturnDate"].ToString()),
                    CAid = int.Parse(Dt.Rows[0]["CAid"].ToString()),
                    Oid = int.Parse(Dt.Rows[0]["Oid"].ToString()),
                    PlaceToSend = Dt.Rows[0]["PlaceToSend"].ToString(),
                    SumOrder = int.Parse(Dt.Rows[0]["SumOrder"].ToString()),
                    Remarks = Dt.Rows[0]["Remarks"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"].ToString()),
                    StatusOrder = bool.Parse(Dt.Rows[0]["StatusOrder"].ToString()),
                    StatusRedy = bool.Parse(Dt.Rows[0]["StatusRedy"].ToString()),
                    StatusPay = bool.Parse(Dt.Rows[0]["StatusPay"].ToString()),
                    Collection = bool.Parse(Dt.Rows[0]["Collection"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[0]["CompanyCode"].ToString()),
                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  T_orders Where Oid = {Id}";
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