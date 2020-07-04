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
    public class FileDao : IFileDao
    {
        private string _connectionString = @"Data Source";
        public void Remove(int idFile)
        {
            AccessDao accessDao = new AccessDao(); //Поскольку мы удаляем файл из базы 
            accessDao.FileHasBeenRemoved(idFile);//Нужно заранее удалить все доступы к нему у пользователей
            // и не вызывать злобы Sql о том что удаляют Row  с зависимостями
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveFile";

                var idFileParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdFile",
                    Value = idFile,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idFileParameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Upload(File file)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UploadFile";

                var fileNameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@FileName",
                    Value = file.FileName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(fileNameParameter);

                var ownerIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@OwnerId",
                    Value = file.OwnerId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(ownerIdParameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
