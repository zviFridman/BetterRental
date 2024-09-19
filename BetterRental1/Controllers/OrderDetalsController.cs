using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace BetterRental1.Controllers
{
    public class OrderDetalsController : ApiController
    {
        // GET: api/OrderDetals
        public object GET()
        {
            List<OrderDetals> LstOrderDetals = OrderDetals.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstOrderDetals
            };
            return res;
        }
        // GET: api/OrderDetals/5
        public object GET(int Id)
        {
            OrderDetals tmp = OrderDetals.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/OrderDetals
        public object POST(OrderDetals data)
        {


            data.Odid = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, OrderDetals data)
        {

            data.Odid = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/OrderDetals/5
        public object DELETE(int id)
        {
            OrderDetals.DeleteById(id);

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
