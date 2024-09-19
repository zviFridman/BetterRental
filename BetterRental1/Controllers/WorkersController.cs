using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;


namespace BetterRental1.Controllers
{
    public class WorkersController : ApiController
    {
        // GET: api/Workers
        public object GET()
        {
            List<Workers> LstWorkers = Workers.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstWorkers
            };
            return res;
        }
        // GET: api/Workers/5
        public object GET(int Id)
        {
            Workers tmp = Workers.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Workers
        public object POST(Workers data)
        {


            data.Wid = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Workers data)
        {

            data.Wid = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/Workers/5
        public object DELETE(int id)
        {
            Workers.DeleteById(id);

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
