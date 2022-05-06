using JobProc.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobProc.DAL.Interfaces
{
    public interface IRepository
    {
        void SaveCountImagesAndPeople(CountImagesAndPeopleModel countImagesAndPeopleModel);

        void SavePeopleTimes(List<PeopleTimesModel> peopleTimes);

    }
}
