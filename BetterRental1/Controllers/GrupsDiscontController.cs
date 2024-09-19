using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace BetterRental1.Controllers
{
    public class GrupsDiscontController : ApiController
    {
        // GET: api/GrupsDiscont
        public object GET()
        {
            List<GrupsDiscont> LstGrupsDiscont = GrupsDiscont.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstGrupsDiscont
            };
            return res;
        }
        // GET: api/GrupsDiscont/5
        public object GET(int Id)
        {
            GrupsDiscont tmp = GrupsDiscont.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/GrupsDiscont
        public object POST(GrupsDiscont data)
        {


            data.Gid = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, GrupsDiscont data)
        {

            data.Gid = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/GrupsDiscont/5
        public object DELETE(int id)
        {
            GrupsDiscont.DeleteById(id);

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
