using JobProc.BLL.DTO;
using System.Collections.Generic;

namespace JobProc.BLL.Interfaces
{
    public interface IJobService
    {
        string SaveCountImagesAndPeople(DTOCountImagesAndPeopleViewModel dtoCountImagesAndPeopleViewModel);

        string SaveListPeopleTimes(List<DTOPeopleTimesViewModel> dTOPeopleTimesViewModels);
    }
}
