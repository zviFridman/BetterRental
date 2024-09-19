using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Company
    {

        public int CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }

        public bool Status { get; set; }
        public DateTime AddDate { get; set; }
        public string Remarks { get; set; }


        public void Save()
        {
             CompanyDAL.Save(this);
        }
        public static List<Company> GetAll()
        {
            return CompanyDAL.GetAll();
        }
        public static Company GetById(int Id)
        {
            return CompanyDAL.GetById(Id);
        }
        public static int DeleteById(int Id)
        {
            return CompanyDAL.DeleteById(Id);
        }


    }
}