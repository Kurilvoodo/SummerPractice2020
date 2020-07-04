using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareMate.Entities;
using ShareMate.BLL.Interfaces;
using ShareMate.DAO.Interfaces;

namespace ShareMate.BLL
{
    public class UserLogic : IUserLogic
    {
        private static IUserDao _userDao;
        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }
        public void Add(User user)
        {
            using (SHA256 sha256= SHA256.Create())
            {
                byte[] password = Encoding.Default.GetBytes(user.Password);
                user.HashPassword = sha256.ComputeHash(password);
            }
            _userDao.Add(user);

        }

        public bool Authentication(User user)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] password = Encoding.Default.GetBytes(user.Password);
                user.HashPassword = sha256.ComputeHash(password);
            }
            return _userDao.Authentication(user);
        }

        public void Edit(User user)
        {
            _userDao.Edit(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userDao.GetAllUsers();
        }

        public int GetIdByUsername(string username)
        {
            return _userDao.GetIdByUsername(username);
        }

        public User GetUserById(int id)
        {
            return _userDao.GetUserById(id);
        }

        public User GetUserByUsername(string username)
        {
            return _userDao.GetUserByUsername(username);
        }

        public void Remove(int id)
        {
            _userDao.Remove(id);
        }
    }
}
