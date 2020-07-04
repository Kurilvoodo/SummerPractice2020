using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareMate.Entities;

namespace ShareMate.DAO.Interfaces
{
    public interface IFileDao
    {
        void Upload(File file);
        void Remove(int id);
    }
}
