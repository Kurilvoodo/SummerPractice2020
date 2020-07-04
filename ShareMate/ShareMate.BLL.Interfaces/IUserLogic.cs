using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareMate.Entities;

namespace ShareMate.BLL.Interfaces
{
    public interface IUserLogic
    {
        void Add(User user);
        void Remove(int id);
        bool Authentication(User user);
        User GetUserByUsername(string username);
        User GetUserById(int id);
        void Edit(User user);
        IEnumerable<User> GetAllUsers();
        int GetIdByUsername(string username);
    }
}
