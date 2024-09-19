using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace BetterRental1.Controllers
{
    public class ProductDiscontGrupController : ApiController
    {
        // GET: api/ProductDiscontGrup
        public object GET()
        {
            List<ProductDiscontGrup> LstProductDiscontGrup = ProductDiscontGrup.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstProductDiscontGrup
            };
            return res;
        }
        // GET: api/ProductDiscontGrup/5
        public object GET(int Id)
        {

            ProductDiscontGrup tmp = ProductDiscontGrup.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/ProductDiscontGrup
        public object POST(ProductDiscontGrup data)
        {


            data.PDid = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, ProductDiscontGrup data)
        {

            data.PDid = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/ProductDiscontGrup/5
        public object DELETE(int id)
        {
            ProductDiscontGrup.DeleteById(id);

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
