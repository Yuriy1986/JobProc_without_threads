using System.Collections.Generic;
using JobProc.DAL.Models;
using JobProc.DAL.Repositories;
using Xunit;

namespace JobProc.Tests
{
    public class JobProcDALTests
    {
        [Fact]
        public void SaveCountImagesAndPeople()
        {
            // Arrange
            CountImagesAndPeopleModel countImagesAndPeopleModel = new CountImagesAndPeopleModel
            {
                CountImages = 10,
                CountPeople = 2
            };
            Repository repository = new Repository();

            // Act
            repository.SaveCountImagesAndPeople(countImagesAndPeopleModel);

            // Assert
            List<PeopleTimesModel> savedListPeopleTimes = repository.GetAllPeopleTimes(out CountImagesAndPeopleModel TestCountImagesAndPeopleModel);
            Assert.Equal(countImagesAndPeopleModel.CountImages, TestCountImagesAndPeopleModel.CountImages);
            Assert.Equal(countImagesAndPeopleModel.CountPeople, TestCountImagesAndPeopleModel.CountPeople);
        }

        [Fact]
        public void SavePeopleTimes()
        {
            // Arrange
            List<PeopleTimesModel> peopleTimes = new List<PeopleTimesModel>();
            peopleTimes.Add(new PeopleTimesModel { PeopleTime = 1 });
            peopleTimes.Add(new PeopleTimesModel { PeopleTime = 2 });
            peopleTimes.Add(new PeopleTimesModel { PeopleTime = 3 });

            Repository repository = new Repository();

            // Act
            repository.SavePeopleTimes(peopleTimes);

            // Assert
            List<PeopleTimesModel> savedListPeopleTimes = repository.GetAllPeopleTimes(out CountImagesAndPeopleModel TestCountImagesAndPeopleModel);
            Assert.Equal(3, peopleTimes.Count);
            Assert.Equal(1, peopleTimes[0].PeopleTime);
            Assert.Equal(2, peopleTimes[1].PeopleTime);
            Assert.Equal(3, peopleTimes[2].PeopleTime);
        }



    }
}
