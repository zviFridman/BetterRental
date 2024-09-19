using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace BetterRental1.Controllers
{
    public class CategorysController : ApiController
    {
        // GET: api/Categorys
        public object GET()
        {
            List<Categorys> LstCategorys = Categorys.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstCategorys
            };
            return res;
        }
        // GET: api/Categorys/5
        public object GET(int Id)
        {
            Categorys tmp = Categorys.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Categorys
        public object POST(Categorys data)
        {


            data.Cid = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Categorys data)
        {

            data.Cid = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/Categorys/5
        public object DELETE(int id)
        {
            Categorys.DeleteById(id);


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

