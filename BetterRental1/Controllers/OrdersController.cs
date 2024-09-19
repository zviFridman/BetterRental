using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL;
using Newtonsoft.Json.Linq;


namespace BetterRental1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrdersController : ApiController
    {
        // GET: api/Orders
        public object GET()
        
        {
            List<Orders> LstOrders = Orders.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstOrders
            };
            return res;
        }
        // GET: api/Orders/5
        public object GET(int Id)
        {
            Orders tmp = Orders.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Orders
        public object POST(Orders data)
        {


            data.Oid = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Orders data)
        {

            data.Oid = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/Orders/5
        public object DELETE(int id)
        {
            Orders.DeleteById(id);

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
