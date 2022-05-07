using JobProc.BLL.Interfaces;
using JobProc.DAL.Interfaces;
using JobProc.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobProc.BLL.Services
{
    public class CalculateService : ICalculateService
    {
        private IRepository Repo { get; }

        public CalculateService(IRepository repository)
        {
            Repo = repository;
        }

        public int Calculate(bool fastCalculation)
        {
           var tt = Repo.GetAllPeopleTimes(out CountImagesAndPeopleModel countImagesAndPeopleModel);

            return 1;
        }
    }
}
