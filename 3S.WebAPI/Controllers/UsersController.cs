using _3S.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _3S.WebAPI.Controllers
{
    [RoutePrefix("api")]

    public class UsersController : ApiController
    {
        
        // GET api/users
        [Route("users")]
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return Users.users;
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
        [Route("users/{value}")]
        [HttpPost]
        public Users PostUser([FromUri] string value , Users users)
        {
            return users;
        }

            // PUT api/users/5
        public void Put(int id, [FromUri] string value)
        {
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
        }
    }
}
