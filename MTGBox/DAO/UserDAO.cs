using MTGBox.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGBox.DAO
{
    public class UserDAO
    {
        public void Insert(User user)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "insert into users (name, login, password) values (@name, @login, @password)";

            sqlCommand.Parameters.AddWithValue("@name", user.Name);
            sqlCommand.Parameters.AddWithValue("@login", user.Login);
            sqlCommand.Parameters.AddWithValue("@password", user.Password);

            Db.Execute(sqlCommand);
        }

        public void Update(User user)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "update users set name = @name, login = @login, password = @password where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", user.Id);
            sqlCommand.Parameters.AddWithValue("@name", user.Name);
            sqlCommand.Parameters.AddWithValue("@login", user.Login);
            sqlCommand.Parameters.AddWithValue("@password", user.Password);

            Db.Execute(sqlCommand);
        }

        public void Delete(User user)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "delete from users where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", user.Id);

            Db.Execute(sqlCommand);
        }

        public User SelectById(User user)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from users where id = @id";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            User selectedUser = new User();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                user.Id = (Int32) sqlDataReader["id"];
                user.Name = (String) sqlDataReader["name"];
                user.Login = (String) sqlDataReader["login"];
                user.Password = (String) sqlDataReader["password"];
                
                return user;
            }
            else
            {
                return null;
            }
        }

        public List<User> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from users";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<User> listUser = new List<User>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    User user = new User();
                    user.Id = (Int32)sqlDataReader["id"];
                    user.Name = (String)sqlDataReader["name"];
                    user.Login = (String)sqlDataReader["login"];
                    user.Password = (String)sqlDataReader["password"];
                    listUser.Add(user);
                }
                sqlDataReader.Read();

                return listUser;
            }
            else
            {
                return null;
            }
        }
    }
}
