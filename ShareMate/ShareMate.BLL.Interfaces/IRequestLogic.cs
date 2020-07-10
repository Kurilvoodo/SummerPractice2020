using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareMate.Entities;

namespace ShareMate.BLL.Interfaces
{
    public interface IRequestLogic
    {
        void AddRequest(Request request);
        void RemoveRequest(Request request);
        IEnumerable<Request> GetOwnerRequests(int OwnerId);
        IEnumerable<Request> GetMyRequests(int MyId);
    }
}
