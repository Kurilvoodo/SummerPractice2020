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
    public class FileDao : BaseDao, IFileDao
    {
        public File GetFileById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetFileById");
                AddParameter(GetParameter("@Id", id, DbType.Int32), command);
                connection.Open();
                var reader = command.ExecuteReader();// Возвратить файл по id ИЗМЕНИТЬ
                File fileinfo = null;
                while (reader.Read())
                {
                    fileinfo = new File()
                    {
                        FileName = reader["FileName"] as string
                    };
                }
                return fileinfo;
            }
        }

        public int GetFileIdByOwnerId(int id, string filename) //здесь не хватает filename для точности иначе он вытаскивает первый попавшийся убрать Execute Scalar yf nonquery
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.GetFileIdByOwnerId");
                AddParameter(GetParameter("@Id", id, DbType.Int32), command);
                AddParameter(GetParameter("@FileName", filename, DbType.String), command);
                connection.Open();
                var reader = command.ExecuteReader();
                int result=0;
                while (reader.Read())
                {
                    result = (int)reader["Id"];
                }

                return result;
            }

        }

        public void Remove(int idFile)
        {
            AccessDao accessDao = new AccessDao(); //Поскольку мы удаляем файл из базы 
            accessDao.FileHasBeenRemoved(idFile);//Нужно заранее удалить все доступы к нему у пользователей \\\\ Заменить на каскадное удаление в бд
            // и не вызывать злобы Sql о том что удаляют Row  с зависимостями
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.RemoveFile");
                AddParameter(GetParameter("@IdFile", idFile, DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<File> Search(string search)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.Search");
                AddParameter(GetParameter("@Search", search, DbType.String), command);
                connection.Open();
                List<File> files = new List<File>();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    files.Add(new File()
                    {
                        FileName = reader["FileName"] as string,
                        Id = (int)reader["Id"],
                        OwnerId = (int)reader["OwnerId"]
                    });
                }
                return files;
            }
        }

        public void Upload(File file)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = GetCommand(connection, "dbo.UploadFile");
                AddParameter(GetParameter("@FileName", file.FileName, DbType.String), command);
                AddParameter(GetParameter("@OwnerId", file.OwnerId, DbType.Int32), command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
