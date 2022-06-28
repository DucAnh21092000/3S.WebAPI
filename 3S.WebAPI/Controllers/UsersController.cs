using _3S.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _3S.WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        
        // GET api/users
        [Route("api/users")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/users/5

        public string Get(int id)
        {
            return "value";
        }
        
        public string Get(int age, string name)
        {
            return name;
        }



        // POST api/users
        [Route("api/users/{user}")]

        [HttpPost]
        public Users PostUser([FromBody] string value, Users user)
        {
            return user;
        }

            // PUT api/users/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
        }
    }
}