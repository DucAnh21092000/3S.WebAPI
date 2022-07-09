using _3S.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3S.BL
{
    public class UsersBL
    {
        // Lấy tất cả danh sách User
        public IEnumerable<Users> getUsers()
        {
            // Khởi tạo list Users
            var users = new List<Users>();

            var connecttionString = "Server = MSI; Database = 3S.MyProject; User Id = ducanh; Password = ducanhisme";

            // Khởi tạo đối tượng Sql Connecttion

            SqlConnection con = new SqlConnection(connecttionString);

            // Khởi tạo đối tượng Sql Command
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandText = "Select * from Users";

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var user = new Users();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var colName = reader.GetName(i);
                    var value = reader.GetValue(i);

                    var prop = user.GetType().GetProperty(colName);

                    if (prop != null && value != DBNull.Value)
                    {
                        prop.SetValue(user, value, null);
                    }

                }
                users.Add(user);
            }
            return users;
        }

        // Lấy user theo id hoặc mssv

        public IEnumerable<Users> getUser(int id)
        {
            // Khởi tạo list Users
            var users = new List<Users>();

            var connecttionString = "Server = MSI; Database = 3S.MyProject; User Id = ducanh; Password = ducanhisme";

            // Khởi tạo đối tượng Sql Connecttion

            SqlConnection con = new SqlConnection(connecttionString);

            // Khởi tạo đối tượng Sql Command
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandText = "Select * from Users where Id ="+id+ "or UserCode ="+id;

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var user = new Users();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var colName = reader.GetName(i);
                    var value = reader.GetValue(i);

                    var prop = user.GetType().GetProperty(colName);

                    if (prop != null && value != DBNull.Value)
                    {
                        prop.SetValue(user, value, null);
                    }

                }
                users.Add(user);
            }
            return users;
        }

        // Thêm User
        public Boolean insertUser(Users user)
        {
            var result = true;

            var connecttionString = "Server = MSI; Database = 3S.MyProject; User Id = ducanh; Password = ducanhisme";

            // Khởi tạo đối tượng Sql Connecttion

            SqlConnection con = new SqlConnection(connecttionString);

            // Khởi tạo đối tượng Sql Command
            SqlCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "SELECT MAX(Id)  FROM  Users";
            var id = Convert.ToInt32(cmd.ExecuteScalar());

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into Users " +
                "(Id, UserName, Password, UserCode, IsAdmin, FullName) " +
                "Values(@param,@param1, @param2,@param3, @param4, @param5);";

            if(id == 0)
            {
                cmd.Parameters.AddWithValue("@param", 1);
            }
            else
            {
                cmd.Parameters.AddWithValue("@param", id+1);
            }
            cmd.Parameters.AddWithValue("@param1", user.UserName);
            cmd.Parameters.AddWithValue("@param2", user.Password);
            cmd.Parameters.AddWithValue("@param3", user.UserCode);
            cmd.Parameters.AddWithValue("@param4", user.IsAdmin);
            cmd.Parameters.AddWithValue("@param5", user.FullName);
            
            if( user.IsAdmin != null && user.UserCode != null && 
                user.UserName != null && user.Password != null && user.FullName != null)
            {
                cmd.ExecuteNonQuery();
                result = true;
            }
            else
            {
                result = false;
            }
            con.Close();

            return result;
        }

        // Sửa User

        public Boolean updateUser(int id,Users user)
        {
            var result = false;

            if(id.GetType() == typeof(int) || user == null)
            {
                result = false;
            }
            else { result = true; }
            var connecttionString = "Server = MSI; Database = 3S.MyProject; User Id = ducanh; Password = ducanhisme";

            // Khởi tạo đối tượng Sql Connecttion

            SqlConnection con = new SqlConnection(connecttionString);

            // Khởi tạo đối tượng Sql Command
            SqlCommand cmd = con.CreateCommand();
            con.Open();            

            // Kiểm tra xem có UserName không
            if (user.UserName != null)
            {
                cmd.CommandText = "Update Users  Set" +
                    " UserName = @param where Id =" + id + "or UserCode =" + id;
                cmd.Parameters.AddWithValue("@param", user.UserName);
                cmd.ExecuteNonQuery();
            }
            // Kiểm tra xem có Password không
            if (user.Password != null)
            {
                cmd.CommandText = "Update Users  Set" +
                    " Password = @param1 where Id =" + id + "or UserCode =" + id;
                cmd.Parameters.AddWithValue("@param1", user.Password);
                cmd.ExecuteNonQuery();
            }
            // Kiểm tra xem có FullName không
            if (user.FullName!= null)
            {
                cmd.CommandText = "Update Users  Set" +
                    " FullName = @param2 where Id =" + id + "or UserCode =" + id;
                cmd.Parameters.AddWithValue("@param2", user.FullName);
                cmd.ExecuteNonQuery();
            }
            // Kiểm tra xem có IsAdmin không
            if (user.IsAdmin != null)
            {
                cmd.CommandText = "Update Users  Set" +
                    " IsAdmin = @param3 where Id =" + id + "or UserCode =" + id;
                cmd.Parameters.AddWithValue("@param3", user.IsAdmin);
                cmd.ExecuteNonQuery();
            }
            // Kiểm tra xem có UserCode không
            if (user.UserCode != null)
            {
                cmd.CommandText = "Update Users  Set" +
                    " UserCode = @param4 where Id =" + id + "or UserCode =" + id;
                cmd.Parameters.AddWithValue("@param4", user.UserCode);
                cmd.ExecuteNonQuery();
            }

           
            con.Close();


            return result;
        }



        // Xóa User
        public int deleteUser(int id)
        {
            var users = new List<Users>();
            var connecttionString = "Server = MSI; Database = 3S.MyProject; User Id = ducanh; Password = ducanhisme";

            // Khởi tạo đối tượng Sql Connecttion

            SqlConnection con = new SqlConnection(connecttionString);

            // Khởi tạo đối tượng Sql Command
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandText = "Delete  from Users where Id="+id+";";

            con.Open();
            var rs = cmd.ExecuteNonQuery();
            return rs;
        }
    }
}

