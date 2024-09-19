using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class TypeExpenses
    {
        public int TEid { get; set; }
        public string TypeExpense { get; set; }
        public bool Status { get; set; }
        public DateTime AddDate { get; set; }
        public string Remarks { get; set; }
        public int CompanyCode { get; set; }



        public void Save()
        {
             TypeExpensesDAL.Save(this);
        }
        public static List<TypeExpenses> GetAll()
        {
            return TypeExpensesDAL.GetAll();
        }
        public static TypeExpenses GetById(int Id)
        {
            return TypeExpensesDAL.GetById(Id);
        }
        public static int DeleteById(int Id)
        {
           return  TypeExpensesDAL.DeleteById(Id);
        }


    }
}