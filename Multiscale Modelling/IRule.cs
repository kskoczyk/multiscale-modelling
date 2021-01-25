using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiscale_Modelling
{
    public interface IRule
    {
        Cell GetDominantCell(Cell[] neighbors, int? probability = null);
    }
}
