using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class GrupsDiscont
    {
        public int Gid { get; set; }
        public string Gname { get; set; }
        public bool Status { get; set; }
        public DateTime AddDate { get; set; }
        public string Remarks { get; set; }
        public int CompanyCode { get; set; }
        public string CustomerId { get; set; }

        public void Save()
        {
             GrupsDiscontDAL.Save(this);
        }
        public static List<GrupsDiscont> GetAll()
        {
            return GrupsDiscontDAL.GetAll();
        }
        public static GrupsDiscont GetById(int Id)
        {
            return GrupsDiscontDAL.GetById(Id);
        }
        public static int DeleteById(int Id)
        {
            return GrupsDiscontDAL.DeleteById( Id);
        }

    }
}