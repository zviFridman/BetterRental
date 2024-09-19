using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;


namespace BetterRental1.Controllers
{
    public class CustomersController : ApiController
    {
        // GET: api/Customers
        public  object GET()
        {
            List<Customers> LstCustomers = Customers.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstCustomers
            };
            return res;
        }
        // GET: api/Customers/5
        public  object GET(int Id)
        {
            
            Customers tmp = Customers.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Customers
        public object POST(Customers data)
        {


            data.CUid = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data ="" 
            };
           
            return res;
        }


        public object PUT(int Id,Customers data)
        {

            data.CUid = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data =""
            };
            return res;
        }

        // DELETE: api/CUstomers/5
        public object DELETE(int id)
        {
            Customers.DeleteById(id);

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

