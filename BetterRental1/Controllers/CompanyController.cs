using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace BetterRental1.Controllers
{
    public class CompanyController : ApiController
    {
        // GET: api/Company
        public object GET()
        {
            List<Company> LstCompany = Company.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstCompany
            };
            return res;
        }
        // GET: api/Company/5
        public object GET(int Id)
        {
            Company tmp = Company.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Company
        public object POST(Company data)
        {


            data.CompanyCode = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Company data)
        {

            data.CompanyCode = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/Company/5
        public object DELETE(int id)
        {
            Company.DeleteById(id);

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
