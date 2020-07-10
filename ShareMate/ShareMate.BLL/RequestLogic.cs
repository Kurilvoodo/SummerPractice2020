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
    public class RequestLogic : IRequestLogic
    {
        private static IRequestDao _requestDao;
        public RequestLogic(IRequestDao requestDao)
        {
            _requestDao = requestDao;
        }
        public void AddRequest(Request request)
        {
            _requestDao.AddRequest(request);
        }

        public IEnumerable<Request> GetMyRequests(int MyId)
        {
            return _requestDao.GetMyRequests(MyId);
        }

        public IEnumerable<Request> GetOwnerRequests(int OwnerId)
        {
            return _requestDao.GetOwnerRequests(OwnerId);
        }

        public void RemoveRequest(Request request)
        {
            _requestDao.RemoveRequest(request);
        }
    }
}
