using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using BLL;
using System.Data.SqlClient;
using System.Data;



namespace DAL
{
    public class ProductDAL
    {
        public static void Save(Product Tmp)
        {
            string Sql;
            if (Tmp.Pid == -1)
            {
                Sql = $"insert into T_product(Pname,Pdesc,Pprice,Picname,Cid,Pinventory,Remarks,AddDate,Status,CompanyCode) " +
                    $"values (@Pname,@Pdesc,@Pprice,@Picname,@Cid,@Pinventory,@Remarks,@AddDate,@Status,@CompanyCode)";
            }
            else
            {
                Sql = $"Update T_product set " +
                    $"Pname=@Pname," +
                    $"Pdesc=@Pdesc," +
                    $"Pprice=@Pprice," +
                    $"Picname=@Picname," +
                    $"Cid=@Cid," +
                    $"Pinventory=@Pinventory," +
                    $"Remarks=@Remarks," +
                    $"AddDate=@AddDate," +
                     $"Status=@Status ," +


                        $"CompanyCode=@CompanyCode   Where Pid=@Pid";
            }
            DbContext Db = new DbContext();
            var Obj = new
            {
                Pname = Tmp.Pname,
                Pid = Tmp.Pid,
                Pdesc = Tmp.Pdesc,
                Pprice = Tmp.Pprice,
                Picname = Tmp.Picname,
                Cid = Tmp.Cid,
                Pinventory = Tmp.Pinventory,
                Remarks = Tmp.Remarks,              
                AddDate = Tmp.AddDate,
                Status = Tmp.Status,
                CompanyCode = Tmp.CompanyCode,
            };


            var lstParam = DbContext.CreateParameters(Obj);





            Db.ExecuteNonQuery(Sql, lstParam);

           
            Db.Close();

        }
        public static List<Product> GetAll()
        {
            List<Product> productList = new List<Product>();
            string Sql = "Select * from T_product";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Product tmp = new Product()
                {
                    Pname = Dt.Rows[i]["Pname"].ToString(),
                    Pid = int.Parse(Dt.Rows[i]["Pid"].ToString()),
                    Pdesc = Dt.Rows[i]["Pdesc"].ToString(),
                    Pprice = int.Parse(Dt.Rows[i]["Pprice"].ToString()),
                    Picname = Dt.Rows[i]["Picname"].ToString(),
                    Cid = int.Parse(Dt.Rows[i]["Cid"].ToString()),
                    Pinventory = int.Parse(Dt.Rows[i]["Pinventory"].ToString()),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString()),
                    Status = bool.Parse(Dt.Rows[i]["Status"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[i]["CompanyCode"].ToString()),
                };
                productList.Add(tmp);
            }
            Db.Close();
            return productList;
        }
        public static Product GetById(int Id)
        {
            Product tmp = null;
            string Sql = $"Select * from T_product Where Pid = {Id}";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Product()
                {
                    Pname = Dt.Rows[0]["Pname"].ToString(),
                    Pid = int.Parse(Dt.Rows[0]["Pid"].ToString()),
                    Pdesc = Dt.Rows[0]["Pdesc"].ToString(),
                    Pprice = int.Parse(Dt.Rows[0]["Pprice"].ToString()),
                    Picname = Dt.Rows[0]["Picname"].ToString(),
                    Cid = int.Parse(Dt.Rows[0]["Cid"].ToString()),
                    Pinventory = int.Parse(Dt.Rows[0]["Pinventory"].ToString()),
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
            string Sql = $"Delete from  T_product Where Pid = {Id}";
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