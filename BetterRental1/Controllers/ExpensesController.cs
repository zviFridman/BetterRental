using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace BetterRental1.Controllers
{
    public class ExpensesController : ApiController
    {
        // GET: api/Expenses
        public object GET()
        {
            List<Expenses> LstExpenses = Expenses.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstExpenses
            };
            return res;
        }
        // GET: api/Expenses/5
        public object GET(int Id)
        {
            Expenses tmp = Expenses.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Expenses
        public object POST(Expenses data)
        {


            data.Teid = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Expenses data)
        {

            data.Teid = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/Expenses/5
        public object DELETE(int id)
        {
            Expenses.DeleteById(id);

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
