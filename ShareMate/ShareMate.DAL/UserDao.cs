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
    public class UserDao : IUserDao
    {
        private string _connectionString = @"Data Source";
        public void Add(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddUser";

                var usernameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Username",
                    Value = user.Username,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(usernameParameter);

                var passwordParameter = new SqlParameter()
                {
                    DbType = DbType.Binary,
                    ParameterName = "@Password",
                    Value = user.HashPassword,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(passwordParameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool Authentication(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.Authentication";

                var usernameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Username",
                    Value = user.Username,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(usernameParameter);

                var passwordParameter = new SqlParameter()
                {
                    DbType = DbType.Binary,
                    ParameterName = "@Password",
                    Value = user.HashPassword,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(passwordParameter);

                connection.Open();

                var resultCommand = command.ExecuteScalar();

                return (int)resultCommand > 0;

            }
        }

        

        public IEnumerable<User> GetAllUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllUsers";

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
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetIdByUsername";

                var usernameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Username",
                    Value = username,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(usernameParameter);
                connection.Open();

                return (int)command.ExecuteScalar();
            }
        }

        public User GetUserById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserById";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@ID",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                User userinfo = null;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userinfo = new User()
                    {
                        Username = reader["Username"] as string,
                        Id = (int)reader["Id"]
                    };
                }
                return userinfo;
            }
        }

        public User GetUserByUsername(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserByUsername";

                var usernameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Username",
                    Value = username,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(usernameParameter);
                connection.Open();
                User userinfo = null;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userinfo = new User()
                    {
                        Username = reader["Username"] as string,
                        Id = (int)reader["Id"]
                    };
                }
                return userinfo;
            }
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveUser";

                var idUserParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@ID",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idUserParameter);
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
