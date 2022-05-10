using JobProc.BLL.DTO;
using JobProc.BLL.Interfaces;
using JobProc.DAL.Interfaces;
using JobProc.DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
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


        private object Locker { get; set; }
        private Task[] Tasks { get; set; }
        private CancellationTokenSource Source { get; set; }
        private CancellationToken Token { get; set; }


        private int[] PeopleTimes { get; set; }
        private int CountImages { get; set; }

        // Count of images processed by people
        private int[] UsersCountOfImages { get; set; }


        public DTOResultViewModel Calculate(bool fastCalculation)
        {
            string service_info;

            List<PeopleTimesModel> peopleTimesModels = Repo.GetAllPeopleTimes(out CountImagesAndPeopleModel countImagesAndPeopleModel);

            CountImages = countImagesAndPeopleModel.CountImages;
            int countPeoples = countImagesAndPeopleModel.CountPeople;

            PeopleTimes=new int[countPeoples];

            //If fastCalculation =true calculate in seconds, else - in minutes)
            for (int i = 0; i < countPeoples; i++)
            {
                PeopleTimes[i] = (fastCalculation ? (peopleTimesModels[i].PeopleTime * 1000) : (peopleTimesModels[i].PeopleTime * 60000));
            }

            Source = new CancellationTokenSource();
            Token = Source.Token;

            Locker = new object();

            Tasks = new Task[countPeoples];

            UsersCountOfImages = new int[countPeoples];

            Stopwatch clock = new Stopwatch();
            clock.Start();

            for (int i = 0; i < countPeoples; i++)
            {
                StartTasks(i);
            }

            try
            {
                Task.WaitAll(Tasks, Token);
            }
            catch (Exception ex)
            {
                service_info = ex.Message;
            }

            clock.Stop();

             DTOResultViewModel dTOResultViewModel = new DTOResultViewModel
            {
                Ticks = clock.ElapsedTicks,
                PeoplesCountOfImages= UsersCountOfImages
            };

            return dTOResultViewModel;
        }

        private void StartTasks(int i)
        {
            Tasks[i] = new Task(() => Calculating(i), Token);
            Tasks[i].Start();
        }
        private void Calculating(int index)
        {
            while (!Source.IsCancellationRequested)
            {
                lock (Locker)
                {
                    if (CountImages == 0)
                    {
                        Source.Cancel();
                    }
                    else
                    {
                        CountImages--;
                        UsersCountOfImages[index]++;
                    }
                }

                if (!Source.IsCancellationRequested)
                  Tasks[index].Wait(PeopleTimes[index]);
            }
        }



    }
}
