using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobProc.BLL.Interfaces
{
    public interface ICalculateService
    {
        int Calculate(bool fastCalculation);
    }
}
