using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobProc.DAL.Interfaces;
using JobProc.DAL.Repositories;
using SimpleInjector;

namespace JobProc.BLL.Infrastructure
{
    public class ServiceModule
    {
        public ServiceModule(Container container)
        {
            container.Register<IRepository, Repository>();

        }
    }
}
