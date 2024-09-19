using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace BetterRental1.Controllers
{
    public class PayTypesController : ApiController
    {
        // GET: api/PayTypes
        public object GET()
        {
            List<PayTypes> LstPayTypes = PayTypes.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstPayTypes
            };
            return res;
        }
        // GET: api/PayTypes/5
        public object GET(int Id)
        {
            PayTypes tmp = PayTypes.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/PayTypes
        public object POST(PayTypes data)
        {


            data.Ptid = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, PayTypes data)
        {

            data.Ptid = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/PayTypes/5
        public object DELETE(int id)
        {
            PayTypes.DeleteById(id);

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
