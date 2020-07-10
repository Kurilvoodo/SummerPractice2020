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
    public class AccessDao : BaseDao, IAccessDao
    {
        public void Add(int IdUser, int IdFile)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.AddAccess");
                AddParameter(GetParameter("@IdUser", IdUser, DbType.Int32), command);
                AddParameter(GetParameter("@IdFile", IdFile, DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void FileHasBeenRemoved(int IdFile)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.FileHasBeenRemoved");
                AddParameter(GetParameter("@ID", IdFile, DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public IEnumerable<int> GetAccessByIdUser(int IdUser) // исправить на менее тяжелую
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetAccessByIdUser");
                AddParameter(GetParameter("@IdUser", IdUser, DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();
                List<int> accesses = new List<int>();
                while (reader.Read())
                {
                    accesses.Add((int)reader["IdFile"]);
                }
                return accesses;
            }
        }
        public void Remove(int IdUser, int IdFile)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.RemoveAccess");
                AddParameter(GetParameter("@IdFile", IdFile, DbType.Int32), command);
                AddParameter(GetParameter("@IdUser", IdUser, DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
