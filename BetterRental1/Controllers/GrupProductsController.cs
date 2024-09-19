using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace BetterRental1.Controllers
{
    public class GrupProductsController : ApiController
    {
        // GET: api/GrupProducts
        public object GET()
        {
            List<GrupProducts> LstGrupProducts = GrupProducts.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstGrupProducts
            };
            return res;
        }
        // GET: api/GrupProducts/5
        public object GET(int Id)
        {
            GrupProducts tmp = GrupProducts.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/GrupProducts
        public object POST(GrupProducts data)
        {


            data.Gpid = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, GrupProducts data)
        {

            data.Gpid = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/GrupProducts/5
        public object DELETE(int id)
        {
            GrupProducts.DeleteById(id);

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;

        }
    }
}
