using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
    

namespace BetterRental1.Controllers
{
    public class PayController : ApiController
    {
        // GET: api/Pay
        public object GET()
        {
            List<Pay> LstPay = Pay.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstPay
            };
            return res;
        }
        // GET: api/Pay/5
        public object GET(int Id)
        {
            Pay tmp = Pay.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Pay
        public object POST(Pay data)
        {


            data.Paid = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Pay data)
        {

            data.Paid = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/Pay/5
        public object DELETE(int id)
        {
            Pay.DeleteById(id);

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
