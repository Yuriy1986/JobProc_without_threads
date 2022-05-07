using JobProc.DAL.Interfaces;
using JobProc.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Db.CountPeoples = countImagesAndPeopleModel.CountPeoples;
        }

        public void SavePeopleTimes(List<PeopleTimesModel> peopleTimes)
        {
            Db.PeopleTimes.Clear();

            foreach (var item in peopleTimes)
            {
                Db.PeopleTimes.Add(item.PeopleTime);
            }
        }

        public List<PeopleTimesModel> GetAllPeopleTimes(out CountImagesAndPeopleModel countImagesAndPeopleModel)
        {
            countImagesAndPeopleModel = new CountImagesAndPeopleModel
            {
                CountImages = Db.CountImages,
                CountPeoples = Db.CountPeoples
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
