using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareMate.Entities;

namespace ShareMate.DAO.Interfaces
{
    public interface IRequestDao
    {
        void AddRequest(Request request);
        void RemoveRequest(Request request);
        IEnumerable<Request> GetOwnerRequests(int OwnerId);
        IEnumerable<Request> GetMyRequests(int MyId);
    }
}
