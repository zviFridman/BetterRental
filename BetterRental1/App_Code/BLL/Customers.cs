using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;


namespace BLL
{
    public class Customers
    {

        public int CUid { get; set; }
        public string CUname { get; set; }
        public string CUemail { get; set; }
        public string CUphone { get; set; }
        public string CUadress { get; set; }
        public string Ltd { get; set; }
        public bool CUtype { get; set; }
        public float Money { get; set; }
        public int Gid { get; set; }
        public string Payname { get; set; }
        public string Payphone { get; set; }
        public bool Status { get; set; }
        public DateTime AddDate { get; set; }
        public string Remarks { get; set; }
        public float Oblogo { get; set; }

        public int CompanyCode { get; set; }

        public void Save()
        {
             CustomersDAL.Save(this);
        }
        public static List<Customers> GetAll()
        {
            return CustomersDAL.GetAll();
        }
        public static Customers GetById(int Id)
        {
            return CustomersDAL.GetById(Id);
        }
        public static int DeleteById(int Id)
        {
            return CustomersDAL.DeleteById(Id);
        }
















    }
}