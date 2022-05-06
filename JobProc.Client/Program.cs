using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using JobProc.BLL.Infrastructure;
using JobProc.BLL.Interfaces;
using JobProc.BLL.Services;
using SimpleInjector;
using SimpleInjector.Diagnostics;

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

            var container = Injector();

            Application.Run(container.GetInstance<Main>());
        }

        private static Container Injector()
        {
            var container = new Container();
            new ServiceModule(container);

            container.Register<IJobService, JobService>();

            AutoRegisterWindowsForms(container);
         //    container.Verify();
            return container;
        }

        private static void AutoRegisterWindowsForms(Container container)
        {
            var types = container.GetTypesToRegister<Form>(typeof(Program).Assembly);

            foreach (var type in types)
            {
                var registration =
                Lifestyle.Transient.CreateRegistration(type, container);

                registration.SuppressDiagnosticWarning(
                    DiagnosticType.DisposableTransientComponent,
                    "Forms should be disposed by app code; not by the container.");

                container.AddRegistration(type, registration);
            }
        }

    }
}
