using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class GrupProducts
    {

        public int Gpid { get; set; }
        public string Gpname { get; set; }
        public string ProductsId { get; set; }
        public bool Status { get; set; }
        public DateTime AddDate { get; set; }
        public string Remarks { get; set; }
        public int CompanyCode { get; set; }

        public void Save()
        {
             GrupProductsDAL.Save(this);
        }
        public static List<GrupProducts> GetAll()
        {
            return GrupProductsDAL.GetAll();
        }
        public static GrupProducts GetById(int Id)
        {
            return GrupProductsDAL.GetById(Id);
        }
        public static int DeleteById(int Id)
        {
            return GrupProductsDAL.DeleteById(Id);
        }


    }
}