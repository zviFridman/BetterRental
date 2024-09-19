using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace BetterRental1.Controllers
{
    public class TypeExpensesController : ApiController
    {
        // GET: api/TypeExpenses
        public object GET()
        {
            List<TypeExpenses> LstTypeExpenses = TypeExpenses.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstTypeExpenses
            };
            return res;
        }
        // GET: api/TypeExpenses/5
        public object GET(int Id)
        {
            TypeExpenses tmp = TypeExpenses.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/TypeExpenses
        public object POST(TypeExpenses data)
        {


            data.TEid = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, TypeExpenses data)
        {

            data.TEid = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/TypeExpenses/5
        public object DELETE(int id)
        {
            TypeExpenses.DeleteById(id);

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
