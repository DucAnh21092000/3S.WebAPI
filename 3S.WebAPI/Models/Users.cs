using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3S.WebAPI.Models
{
    public class Users
    {



        public static List<Users> users = new List<Users>()
        {
             new Users(){
                 Id = 1,
                 UserCode= "abcd123", 
                 FullName= "Đinh Đức Anh",
                 UserName= "girl9xbietkhoc",
                 Password= "1234as",
                 IsAdmin= false
             },
             new Users() {
                 Id = 2,
                 UserCode = "abcd12345",
                 FullName = "Đinh Đức Anh",
                 UserName = "Đánh mất em",
                 Password = "1234asáds",
                 IsAdmin = false
             }    
        };

        /// <sumary>
        /// Id
        /// </sumary>
        public int Id { get; set; }

        /// <sumary>
        /// Id người dùng
        /// </sumary>
        public string UserCode { get; set; }

        /// <sumary>
        /// Tên người dùng
        /// </sumary>
        public string UserName { get; set; }

        /// <sumary>
        /// Mật khẩu
        /// </sumary>
        public string Password { get; set; }

        /// <sumary>
        /// Họ và tên
        /// </sumary>
        public string FullName { get; set; }

        /// <sumary>
        /// Có là Admin không
        /// </sumary>
        public bool IsAdmin { get; set; }

    }
}
