using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiscale_Modelling
{
    class MooreNeighborhood : INeighborhood
    {
        public IEnumerable<int> GetNeighborhood()
        {
            return new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
        }
    }
}
