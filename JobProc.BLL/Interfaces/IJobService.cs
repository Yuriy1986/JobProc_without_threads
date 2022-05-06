using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobProc.BLL.DTO;

namespace JobProc.BLL.Interfaces
{
    public interface IJobService
    {
        string SaveCountImagesAndPeoples(DTOCountImagesAndPeopleViewModel dtoCountImagesAndPeopleViewModel);

        string SaveListPeopleTimes(List<DTOPeopleTimesViewModel> dTOPeopleTimesViewModels);
    }
}
