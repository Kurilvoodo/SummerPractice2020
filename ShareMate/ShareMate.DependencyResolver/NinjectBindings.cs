using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareMate.BLL.Interfaces;
using ShareMate.BLL;
using ShareMate.DAO.Interfaces;
using ShareMate.DAL;
using Ninject.Modules;

namespace ShareMate.Ioc
{
    public class NinjectBindings :NinjectModule
    {
        public override void Load()
        {
            Bind<IAccessDao>().To<AccessDao>();
            Bind<IFileDao>().To<FileDao>();
            Bind<IUserDao>().To<UserDao>();
            Bind<IRequestDao>().To<RequestDao>();

            Bind<IAccessLogic>().To<AccessLogic>();
            Bind<IFileLogic>().To<FileLogic>();
            Bind<IUserLogic>().To<UserLogic>();
            Bind<IRequestLogic>().To<RequestLogic>();
        }
    }
}
