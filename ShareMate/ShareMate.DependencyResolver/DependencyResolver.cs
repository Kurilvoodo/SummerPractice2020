using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareMate.BLL.Interfaces;
using ShareMate.BLL;
using ShareMate.DAO.Interfaces;
using ShareMate.DAL;
using Ninject;

namespace ShareMate.DependencyResolver
{
    public class DependencyResolver
    {
        private static NinjectBindings _bindings = new NinjectBindings();
        public static StandardKernel Kernel = new StandardKernel(_bindings);
    }
}
