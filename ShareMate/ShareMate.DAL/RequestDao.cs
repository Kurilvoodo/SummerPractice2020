using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ShareMate.DAO.Interfaces;
using ShareMate.Entities;
using ShareMate.DAL;

namespace ShareMate.DAL
{
    public class RequestDao : BaseDao, IRequestDao
    {
        public void AddRequest(Request request)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.AddRequest");
                AddParameter(GetParameter("@RequestId", request.RequestId, DbType.Int32), command);
                AddParameter(GetParameter("@FileId", request.FileId, DbType.Int32), command);
                AddParameter(GetParameter("@OwnerId", request.OwnerId, DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Request> GetMyRequests(int MyId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetMyRequests");
                AddParameter(GetParameter("@Id",MyId,DbType.Int32), command);
                connection.Open();
                List<Request> requests = new List<Request>();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    requests.Add(new Request()
                    {
                        RequestId = (int)reader["RequestId"],
                        FileId = (int)reader["FileId"],
                        OwnerId = (int)reader["OwnerId"]
                    });
                }
                return requests;
            }

        }

        public IEnumerable<Request> GetOwnerRequests(int OwnerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetOwnerRequests");
                AddParameter(GetParameter("@Id", OwnerId, DbType.Int32), command);
                connection.Open();
                List<Request> requests = new List<Request>();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    requests.Add(new Request()
                    {
                        RequestId = (int)reader["RequestId"],
                        FileId = (int)reader["FileId"],
                        OwnerId = (int)reader["OwnerId"]
                    });
                }
                return requests;
            }
        }

        public void RemoveRequest(Request request)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.RemoveRequest");
                AddParameter(GetParameter("@RequestId",request.RequestId,DbType.Int32), command);
                AddParameter(GetParameter("@FileId", request.FileId, DbType.Int32), command);
                AddParameter(GetParameter("@OwnerId", request.OwnerId, DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
