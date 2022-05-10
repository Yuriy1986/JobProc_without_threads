using System;
using System.ComponentModel.DataAnnotations;

namespace JobProc.BLL.DTO
{
    public class DTOPeopleTimesViewModel
    {
        [Range(1, 99999999, ErrorMessage = "Times must be in the range {1}-{2}")]
        public int PeopleTime { get; set; }
    }
}
