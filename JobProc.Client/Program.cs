using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using JobProc.BLL.Infrastructure;
using JobProc.BLL.Interfaces;
using JobProc.BLL.Services;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JobProc.Client
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Main>());
        }


        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            IHostBuilder host = Host.CreateDefaultBuilder();

            host.ConfigureServices((context, services) =>
                {
                    services.AddTransient<ICalculateService, CalculateService>();
                    services.AddTransient<IJobService, JobService>();
                    services.AddTransient<Main>();
                });

            new ServiceModule(host);

            return host;
        }

    }
}

