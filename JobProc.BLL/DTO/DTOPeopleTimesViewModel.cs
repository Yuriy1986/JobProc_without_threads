using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobProc.BLL.DTO
{
    public class DTOPeopleTimesViewModel
    {
        [Range(1, 99999999, ErrorMessage = "Times must be in the range {1}-{2}")]
        public int PeopleTime { get; set; }
    }
}
