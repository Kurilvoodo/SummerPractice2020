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
    public class AccessLogic : IAccessLogic
    {
        private static IAccessDao _accessDao;
        public AccessLogic(IAccessDao accessDao)
        {
            _accessDao = accessDao;
        }
        public void Add(int IdUser, int IdFile)
        {
            _accessDao.Add(IdUser, IdFile);
        }

        public void FileHasBeenRemoved(int IdFile)
        {
            _accessDao.FileHasBeenRemoved(IdFile);
        }

        public IEnumerable<Access> GetAccessByIdUser(int IdUser)
        {
            return _accessDao.GetAccessByIdUser(IdUser);
        }

        public void Remove(int IdUser, int IdFile)
        {
            _accessDao.Remove(IdUser, IdFile);
        }
    }
}
