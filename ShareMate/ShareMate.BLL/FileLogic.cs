using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareMate.Entities;
using ShareMate.BLL.Interfaces;
using ShareMate.DAO.Interfaces;

namespace ShareMate.BLL
{
    public class FileLogic : IFileLogic
    {
        private static IFileDao _fileDao;
        public FileLogic(IFileDao fileDao)
        {
            _fileDao = fileDao;
        }
        public void Remove(int id)
        {
            _fileDao.Remove(id);
        }

        public void Upload(File file)
        {
            _fileDao.Upload(file);
        }
    }
}
