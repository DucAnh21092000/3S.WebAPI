using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using _3S.BL;
using _3S.Model;

namespace _3S.WebAPI.Controllers
{
    [RoutePrefix("api/users")]

    public class UsersController : ApiController
    {
        
        // GET api/users
        [Route("")]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            // Khởi tạo listUser
            var userBL = new UsersBL();
            return userBL.getUsers();   
            
        }

        // GET api/users/5
        [Route("{id}")]
        public IHttpActionResult GetUserById(int id)
        {
            UsersBL userBL = new UsersBL();
            var rs = userBL.getUser(id);
            if(rs.FirstOrDefault() != null)
            {
                return Ok(rs);
            }
            else
            {
                return NotFound();
            }

        }
        
        
        public string Get(int age, string name)
        {
            return name;
        }



        // POST api/users
        [Route("")]
        [HttpPost]
        public IHttpActionResult PostUser([FromBody] Users user)
        {
            var userBL = new UsersBL();
            var rs = userBL.insertUser(user);
            if(rs == true)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/users/5
        [Route("{id}")]
        
        public IHttpActionResult Put(int id, [FromBody] Users user)
        {
            var userBL = new UsersBL();
            var result = userBL.updateUser(id,user);

            if (result)
            {
                return Ok(userBL);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/users/5
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var userBL = new UsersBL();
            var row = userBL.deleteUser(id);
            if(row == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }
}
