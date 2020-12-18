using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiscale_Modelling
{
    interface INeighborhood
    {
        IEnumerable<Cell> MooreNeighborhood(Cell cell);
    }
}
