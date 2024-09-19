using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Product
    {
        public int Pid { get; set; }
        public string Pname { get; set; }
        public int Pprice { get; set; }
        public int Cid { get; set; }
        public int Pinventory { get; set; }
        public string Picname { get; set; }


        public string Pdesc { get; set; }

        public bool Status { get; set; }
        public DateTime AddDate { get; set; }
        public string Remarks { get; set; }

        public int CompanyCode { get; set; }



        public void Save()
        {


             ProductDAL.Save(this);

        }
        public static List<Product> GetAll()
        {
            return ProductDAL.GetAll();
        }

        public static Product GetById(int Id)
        {
            return ProductDAL.GetById(Id);
        }
        public static int DeleteById(int Id)
        {
            return ProductDAL.DeleteById(Id);
        }



    }
}