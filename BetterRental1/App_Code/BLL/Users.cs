using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Users
    {
        public int Uid { get; set; }

        public string Uname { get; set; }
        public string Password { get; set; }

        public bool Status { get; set; }
        public DateTime AddDate { get; set; }
        public string Remarks { get; set; }
        public int CompanyCode { get; set; }



        public void Save()
        {
             UsersDAL.Save(this);
        }
        public static List<Users> GetAll()
        {
            return UsersDAL.GetAll();
        }
        public static Users GetById(int Id)
        {
            return UsersDAL.GetById(Id);
        }
        public static int DeleteById(int Id)
        {
           return  UsersDAL.DeleteById(Id);
        }


    }
}