using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace BetterRental1.Controllers
{
    public class ProductController : ApiController
    {
        // GET: api/Product
        public object GET()
        {
            List<Product> LstProduct = Product.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstProduct
            };
            return res;
        }
        // GET: api/Product/5
        public object GET(int Id)
        {
            Product tmp = Product.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Product
        public object POST(Product data)
        {


            data.Pid = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Product data)
        {

            data.Pid = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/Product/5
        public object DELETE(int id)
        {
            Product.DeleteById(id);

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
