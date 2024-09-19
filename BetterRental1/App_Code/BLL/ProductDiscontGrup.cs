using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class ProductDiscontGrup
    {
        public int PDid { get; set; }
        public int Gpid { get; set; }
        public int Gid { get; set; }
        public float Discount { get; set; }


        public bool Status { get; set; }
        public DateTime AddDate { get; set; }
        public string Remarks { get; set; }
        public int CompanyCode { get; set; }


        public void Save()
        {
             ProductDiscontGrupDAL.Save(this);
        }
        public static List<ProductDiscontGrup> GetAll()
        {
            return ProductDiscontGrupDAL.GetAll();
        }
        public static ProductDiscontGrup GetById(int Id )
        {
            return ProductDiscontGrupDAL.GetById(Id);
        }
        public static int DeleteById(int Id)
        {
            return ProductDiscontGrupDAL.DeleteById(Id);
        }

    }
}