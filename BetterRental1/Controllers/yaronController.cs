using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BetterRental1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class yaronController : ApiController
    {
        // GET: api/yaron
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/yaron/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/yaron
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/yaron/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/yaron/5
        public void Delete(int id)
        {
        }
    }
}
