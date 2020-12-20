using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiscale_Modelling
{
    public interface INeighborhood
    {
        //IEnumerable<Cell> GetNeighborhood(Cell cell); // TODO: possibly a more convenient implementation
        IEnumerable<int> GetNeighborhood(); // TODO: or change to a type that supports [] operators directly
    }
}
