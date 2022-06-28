using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3S.WebAPI.Models
{
    public class Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }


    }
}