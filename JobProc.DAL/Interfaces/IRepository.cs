using JobProc.DAL.Models;
using System.Collections.Generic;

namespace JobProc.DAL.Interfaces
{
    public interface IRepository
    {
        void SaveCountImagesAndPeople(CountImagesAndPeopleModel countImagesAndPeopleModel);

        void SavePeopleTimes(List<PeopleTimesModel> peopleTimes);

        List<PeopleTimesModel> GetAllPeopleTimes(out CountImagesAndPeopleModel countImagesAndPeopleModel);
    }
}
