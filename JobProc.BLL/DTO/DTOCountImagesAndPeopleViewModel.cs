using System;
using System.ComponentModel.DataAnnotations;


namespace JobProc.BLL.DTO
{
    public class DTOCountImagesAndPeopleViewModel
    {
        [Range(1, 99999999, ErrorMessage = "Count of images must be in the range {1}-{2}")]
        public int CountImages { get; set; }

        [Range(1, 99999, ErrorMessage = "Count of people must be in the range {1}-{2}")]
        public int CountPeople { get; set; }
    }
}
