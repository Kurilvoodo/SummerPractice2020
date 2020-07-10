using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ShareMate.DAO.Interfaces;
using ShareMate.Entities;
namespace ShareMate.DAL
{
    public class UserDao : BaseDao, IUserDao
    {
        public void Add(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.AddUser");
                AddParameter(GetParameter("@Username", user.Username, DbType.String), command);
                AddParameter(GetParameter("@Password", user.HashPassword, DbType.Binary), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public bool Authentication(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.Authentication");
                AddParameter(GetParameter("@Username", user.Username, DbType.String), command);
                AddParameter(GetParameter("@Password", user.HashPassword, DbType.Binary), command);
                connection.Open();
                var resultCommand = command.ExecuteScalar();
                return (int)resultCommand > 0;
            }
        }
        public IEnumerable<User> GetAllUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetAllUsers");
                connection.Open();
                List<User> users = new List<User>();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User()
                    {
                        Username = reader["Username"] as string
                    });
                }
                return users;
            }
        }
        public int GetIdByUsername(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetIdByUsername");
                AddParameter(GetParameter("@Username", username, DbType.String), command);
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }
        public User GetUserById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetUserById");
                AddParameter(GetParameter("@ID", id, DbType.Int32), command);
                connection.Open();
                User userinfo = null;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userinfo = new User()
                    {
                        Username = reader["Username"] as string
                    };
                }
                return userinfo;
            }
        }
        public User GetUserByUsername(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetUserByUsername");
                AddParameter(GetParameter("@Username", username, DbType.String), command);
                connection.Open();
                User userinfo = null;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userinfo = new User()
                    {
                        Username = reader["Username"] as string
                    };
                }
                return userinfo;
            }
        }
        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.RemoveUser");
                AddParameter(GetParameter("@ID", id, DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        #region NotImplementedMethods
        public void Edit(User user) //А нужно ли вообще? ¯ \ _ (ツ) _ / ¯
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
