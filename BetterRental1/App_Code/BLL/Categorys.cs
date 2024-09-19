using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Categorys
    {

        public int Cid { get; set; }
        public string Cname { get; set; }
        public bool Status { get; set; }
        public DateTime AddDate { get; set; }
        public string Remarks { get; set; }
        public int CompanyCode { get; set; }

        public void Save()
        {
             CategorysDAL.Save(this);
        }
        public static List<Categorys> GetAll()
        {
            return CategorysDAL.GetAll();
        }
        public static Categorys GetById(int Id)
        {
            return CategorysDAL.GetById(Id);
        }
        public static int  DeleteById(int Id)
        {
            
           return CategorysDAL.DeleteById(Id);
        }


    }
}