﻿using System;
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

        public File GetFileById(int id)
        {
            return _fileDao.GetFileById(id);
        }

        public int GetFileIdByOwnerId(int id)
        {
            return _fileDao.GetFileIdByOwnerId(id);
        }

        public void Remove(int idFile)
        {
            _fileDao.Remove(idFile);
        }

        public void Upload(File file)
        {
            _fileDao.Upload(file);
        }
    }
}
