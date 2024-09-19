using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Expenses
    {
        public float Amount { get; set; }
        public int Teid { get; set; }

        public DateTime AddDate { get; set; }

        public bool Status { get; set; }
        public DateTime Exdate { get; set; }
        public string Remarks { get; set; }
        public int Exid { get; set; }
        public int CompanyCode { get; set; }




        public void Save()
        {
             ExpensesDAL.Save(this);
        }
        public static List<Expenses> GetAll()
        {
            return ExpensesDAL.GetAll();
        }
        public static Expenses GetById(int Id)
        {
            return ExpensesDAL.GetById(Id);
        }
        public static int DeleteById(int Id)
        {
          return   ExpensesDAL.DeleteById(Id);
        }


    }
}