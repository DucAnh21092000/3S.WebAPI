using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _3S.WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {

        [Route("values")]

        // GET api/values
        
        public IEnumerable<string> Get()
        {
            return new string[] { "Đức Anh is me", "Trang giấy trắng" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "Hello mọi người";
        }

        // POST api/values
        [Route("values/{value}")]
        [HttpPost]
        public void PostValue([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}












