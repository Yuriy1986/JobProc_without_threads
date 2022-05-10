using JobProc.DAL.Interfaces;
using JobProc.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace JobProc.DAL.Repositories
{
    public class Repository : IRepository
    {
        private Person Db { get; }

        public Repository()
        {
            this.Db = new Person();
        }


        public void SaveCountImagesAndPeople(CountImagesAndPeopleModel countImagesAndPeopleModel)
        {
            Db.CountImages = countImagesAndPeopleModel.CountImages;
            Db.CountPeople = countImagesAndPeopleModel.CountPeople;
        }

        public void SavePeopleTimes(List<PeopleTimesModel> peopleTimes)
        {
            Db.PeopleTimes.Clear();
            Db.PeopleTimes.AddRange(peopleTimes.Select(x=>x.PeopleTime));
        }

        public List<PeopleTimesModel> GetAllPeopleTimes(out CountImagesAndPeopleModel countImagesAndPeopleModel)
        {
            countImagesAndPeopleModel = new CountImagesAndPeopleModel
            {
                CountImages = Db.CountImages,
                CountPeople = Db.CountPeople
            };

            List<PeopleTimesModel> peopleTimes = new List<PeopleTimesModel>();

            foreach (int item in Db.PeopleTimes)
            {
                peopleTimes.Add(new PeopleTimesModel { PeopleTime=item});
            }

            return peopleTimes;
        }
    }
}
