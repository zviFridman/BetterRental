using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Orders
    {
        public int Oid { get; set; }
        public DateTime Odate { get; set; }
        public int CAid { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool StatusRedy { get; set; }
        public bool StatusOrder { get; set; }
        public bool StatusPay { get; set; }
        public bool Collection { get; set; }
        public string PlaceToSend { get; set; }

        public DateTime AddDate { get; set; }
        public string Remarks { get; set; }
        public int CompanyCode { get; set; }
        public float SumOrder { get; set; }


        public void Save()
        {
            OrdersDal.Save(this);
        }
        public static List<Orders> GetAll()
        {
            return OrdersDal.GetAll();
        }
        public static Orders GetById(int Id)
        {
            return OrdersDal.GetById(Id);
        }
        public static int DeleteById(int Id)
        {
            return OrdersDal.DeleteById(Id);
        }

    }
}