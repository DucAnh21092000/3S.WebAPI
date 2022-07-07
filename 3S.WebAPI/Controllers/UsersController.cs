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
        [Route("users/{id}")]
        public IHttpActionResult GetUserById(int id)
        {
            var data = Users.users.Where(x => x.Id == id);
            if (data.Count() !=0)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest();
            }

        }
        
        [Route("users/age={age}")]
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
        [Route("users/{value}")]
        [HttpPut]
        public void Put(int id, [FromUri] string value)
        {
        }

        // DELETE api/users/5
        [Route("users/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
