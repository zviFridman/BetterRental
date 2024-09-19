using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace BetterRental1.Controllers
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        public object GET()
        {
            List<Users> LstUsers = Users.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstUsers
            };
            return res;
        }
        // GET: api/Users/5
        public object GET(int Id)
        {
            Users tmp = Users.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Users
        public object POST(Users data)
        {


            data.Uid = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Users data)
        {

            data.Uid = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/Users/5
        public object DELETE(int id)
        {
            Users.DeleteById(id);

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
