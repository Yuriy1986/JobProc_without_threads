﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobProc.DAL.Interfaces;
using JobProc.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JobProc.BLL.Infrastructure
{
    public class ServiceModule
    {
        public ServiceModule(IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IRepository, Repository>();
                });
        }
    }
}
