using JobProc.BLL.DTO;
using JobProc.BLL.Interfaces;
using System.Collections.Generic;
using System.Text;
using JobProc.DAL.Interfaces;
using JobProc.DAL.Models;
using System.ComponentModel.DataAnnotations;


namespace JobProc.BLL.Services
{
    public class JobService : IJobService
    {
        private IRepository Repo { get; }

        public JobService(IRepository repository)
        {
            Repo = repository;
        }

        public string SaveCountImagesAndPeople(DTOCountImagesAndPeopleViewModel dtoCountImagesAndPeopleViewModel)
        {
            ValidationContext context = new ValidationContext(dtoCountImagesAndPeopleViewModel);
            List<ValidationResult> results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(dtoCountImagesAndPeopleViewModel, context, results, true))
            {
                StringBuilder errorMessage = new StringBuilder();

                foreach (var error in results)
                    errorMessage.AppendLine(error.ErrorMessage);

                return errorMessage.ToString();
            }

            CountImagesAndPeopleModel countImagesAndPeopleModel = new CountImagesAndPeopleModel
            {
                CountImages = dtoCountImagesAndPeopleViewModel.CountImages,
                CountPeople = dtoCountImagesAndPeopleViewModel.CountPeople
            };

            Repo.SaveCountImagesAndPeople(countImagesAndPeopleModel);

            return "";
        }

        public string SaveListPeopleTimes(List<DTOPeopleTimesViewModel> dtoPeopleTimesViewModels)
        {
            List<PeopleTimesModel> peopleTimesModels = new List<PeopleTimesModel>();
            List<ValidationResult> results = new List<ValidationResult>();

            for (int i = 0; i < dtoPeopleTimesViewModels.Count; i++)
            {
                ValidationContext context = new ValidationContext(dtoPeopleTimesViewModels[i]);

                if (!Validator.TryValidateObject(dtoPeopleTimesViewModels[i], context, results, true))
                {
                    StringBuilder errorMessage = new StringBuilder();
                    errorMessage.AppendLine("Error in row " + (i + 1));

                    foreach (var error in results)
                        errorMessage.AppendLine(error.ErrorMessage);

                    return errorMessage.ToString();
                }
                peopleTimesModels.Add(new PeopleTimesModel { PeopleTime = dtoPeopleTimesViewModels[i].PeopleTime });
            }

            Repo.SavePeopleTimes(peopleTimesModels);
            return "";
        }
    }
}
