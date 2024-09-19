using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class PayTypes
    {
        public int Ptid { get; set; }
        public string PayTaype { get; set; }

        public bool Status { get; set; }
        public DateTime AddDate { get; set; }
        public string Remarks { get; set; }
        public int CompanyCode { get; set; }


        public void Save()
        {
             PayTypesDAL.Save(this);
        }
        public static List<PayTypes> GetAll()
        {
            return PayTypesDAL.GetAll();
        }
        public static PayTypes GetById(int Id)
        {
            return PayTypesDAL.GetById(Id);
        }
        public static int DeleteById(int Id)
        {
           return  PayTypesDAL.DeleteById(Id);
        }


    }
}