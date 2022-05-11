using JobProc.BLL.DTO;
using JobProc.BLL.Interfaces;
using JobProc.DAL.Interfaces;
using JobProc.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobProc.BLL.Services
{
    public class CalculateService : ICalculateService
    {
        private IRepository Repo { get; }
        public CalculateService(IRepository repository)
        {
            Repo = repository;
        }

        // Time of processing
        private List<PeopleTimesModel> PeopleTimes { get; set; }

        public DTOResultViewModel Calculate()
        {
            // Time of processing
            PeopleTimes = Repo.GetAllPeopleTimes(out CountImagesAndPeopleModel countImagesAndPeopleModel);

            int countImages = countImagesAndPeopleModel.CountImages;
            int countPeople = countImagesAndPeopleModel.CountPeople;

            // Count of images processed by people
            int[] usersCountOfImages = new int[countPeople];

            int totalProcesingImages = 0;


            // 1. The first time we go through the cycle (regardless of processing time).
            for (int j = 0; j < countPeople; j++)
            {
                usersCountOfImages[j]++;
                totalProcesingImages++;
                // Check whether all the pictures are processed.
                if (totalProcesingImages == countImages)
                    return ResultCalculate(usersCountOfImages);
            }

            // 2. 
            int picturesLeft; 
            picturesLeft = countImages - totalProcesingImages;

            float totaltimes = 0;

            foreach (var item in PeopleTimes)
            {
                totaltimes += (float)1 / (item.PeopleTime);
            }

            for (int i = 0; i < countPeople; i++)
            {
                usersCountOfImages[i] += (int)Math.Floor(1.00 * picturesLeft * (1.00 / PeopleTimes[i].PeopleTime) / totaltimes);
            }

            totalProcesingImages = usersCountOfImages.Sum();

            // 3.
            if (totalProcesingImages != countImages)
            {
                Dictionary<int, int> PeopleTimesDictionary = new Dictionary<int, int>();

                for (int i = 0; i < PeopleTimes.Count; i++)
                {
                    PeopleTimesDictionary.Add(i, PeopleTimes[i].PeopleTime);
                }

                var sortedPeopleTimes = from s in PeopleTimesDictionary orderby s.Value, s.Key select s;    //time, index

                foreach (var item in sortedPeopleTimes)
                {
                    usersCountOfImages[item.Key]++;
                    totalProcesingImages++;
                    // Check whether all the pictures are processed.
                    if (totalProcesingImages == countImages)
                        return ResultCalculate(usersCountOfImages);
                }
            }
            return ResultCalculate(usersCountOfImages);
        }

        // 4.
        private DTOResultViewModel ResultCalculate(int[] usersCountOfImages)
        {
            // Total time is the user's longest time.
            int timeElapsed = 0;

            for (int i = 0; i < usersCountOfImages.Length; i++)
            {
                if (timeElapsed < usersCountOfImages[i] * PeopleTimes[i].PeopleTime)
                    timeElapsed = usersCountOfImages[i] * PeopleTimes[i].PeopleTime;
            }

            DTOResultViewModel dTOResultViewModel = new DTOResultViewModel
            {
                TimeElapsed = timeElapsed,
                PeoplesCountOfImages = usersCountOfImages
            };
            return dTOResultViewModel;
        }
    }
}
