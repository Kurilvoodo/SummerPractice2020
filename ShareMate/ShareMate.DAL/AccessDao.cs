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
    public class AccessDao : IAccessDao
    {
        private string _connectionString = @"Data Source=DESKTOP-QALPV5U\SQLEXPRESS;Initial Catalog=ShareMate;Integrated Security=True";
        public void Add(int IdUser, int IdFile)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddAccess";

                var idUserParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdUser",
                    Value = IdUser,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idUserParameter);

                var idFileParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdFile",
                    Value = IdFile,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idFileParameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void FileHasBeenRemoved(int IdFile)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.FileHasBeenRemoved";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@ID",
                    Value = IdFile,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Access> GetAccessByIdUser(int IdUser) // исправить на менее тяжелую
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAccessByIdUser";

                var idUserParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdUser",
                    Value = IdUser,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idUserParameter);

                connection.Open();
                var reader = command.ExecuteReader();
                List<Access> accesses = new List<Access>();
                while (reader.Read())
                {
                    accesses.Add(new Access()
                    {
                        IdUser = (int)reader["IdUser"],
                        IdFile = (int)reader["IdFile"]
                    });
                }
                return accesses;
            }
        }

        public void Remove(int IdUser, int IdFile)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveAccess";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdFile",
                    Value = IdFile,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                var idUserParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdUser",
                    Value = IdUser,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idUserParameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
