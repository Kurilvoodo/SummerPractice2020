using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareMate.Entities;

namespace ShareMate.BLL.Interfaces
{
    public interface IFileLogic
    {
        void Upload(File file);
        void Remove(int idFile);
        File GetFileById(int id);
        int GetFileIdByOwnerId(int id);
    }
}
