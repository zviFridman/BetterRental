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
    public class UsersDAL
    {
        
            public static void Save(Users Tmp)
            {
                string Sql;
                if (Tmp.Uid == -1)
                {
                    Sql = $"insert into T_users(Uname,Password,Remarks,CompanyCode,Status,AddDate) " +
                        $"values(@Uname,@Password,@Remarks,@CompanyCode,@Status,@AddDate)";
                }
                else
                {
                    Sql = $"Update T_users set " +
                        $"Uname=@Uname," +
                         $"Password=@Password," +
                          $"Remarks=@Remarks," +
                            $"CompanyCode=@CompanyCode," +
                             $"Status=@Status ," +
                              $"AddDate=@AddDate Where  Uid=@Uid";
                }
                DbContext Db = new DbContext();
                 var Obj = new
                 {
                      Uname = Tmp.Uname,
                      Password = Tmp.Password,
                      Uid = Tmp.Uid,             
                      Remarks = Tmp.Remarks,
                      CompanyCode = Tmp.CompanyCode,
                      Status = Tmp.Status,
                      AddDate = Tmp.AddDate,
                  };


             var lstParam = DbContext.CreateParameters(Obj);





               Db.ExecuteNonQuery(Sql, lstParam);

             
              Db.Close();

            }
            public static List<Users> GetAll()
            {
                List<Users> UsersList = new List<Users>();
                string Sql = "Select * from T_users";
                DbContext Db = new DbContext();
                DataTable Dt = Db.Execute(Sql);
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                Users tmp = new Users()
                {
                    Uname = Dt.Rows[i]["Uname"].ToString(),
                    Password = Dt.Rows[i]["Password"].ToString(),
                    Uid = int.Parse(Dt.Rows[i]["Uid"].ToString()),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    CompanyCode = int.Parse(Dt.Rows[i]["CompanyCode"].ToString()),
                    Status = bool.Parse(Dt.Rows[i]["Status"].ToString()),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString()),
                 };
                UsersList.Add(tmp);
                }
                Db.Close();
                return UsersList;
            }
            public static Users GetById(int Id)
            {
            Users tmp = null;
                string Sql = $"Select * from T_users Where Uid = {Id}";
                DbContext Db = new DbContext();
                DataTable Dt = Db.Execute(Sql);
                if (Dt.Rows.Count > 0)
                {
                    tmp = new Users()
                    {
                        Uname = Dt.Rows[0]["Uname"].ToString(),
                        Password = Dt.Rows[0]["Password"].ToString(),
                        Uid = int.Parse(Dt.Rows[0]["Uid"].ToString()),
                        Remarks = Dt.Rows[0]["Remarks"].ToString(),
                        CompanyCode = int.Parse(Dt.Rows[0]["CompanyCode"].ToString()),
                        Status = bool.Parse(Dt.Rows[0]["Status"].ToString()),
                        AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"].ToString()),
                    };

                }
                Db.Close();
                return tmp;
            }
            public static int DeleteById(int Id)
            {
                string Sql = $"Delete from  T_users Where Uid = {Id}";
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