﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareMate.Entities;

namespace ShareMate.BLL.Interfaces
{
    public interface IAccessLogic
    {
        void Add(int IdUser, int IdFile);
        void Remove(int IdUser, int IdFile);
        void FileHasBeenRemoved(int IdFile);
        IEnumerable<Access> GetAccessByIdUser(int IdUser);

    }
}
