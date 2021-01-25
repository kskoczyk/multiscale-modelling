using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiscale_Modelling
{
    public class FullMoore : IRule
    {
        public Cell GetDominantCell(Cell[] neighbors, int? probability)
        {
            Cell dominantCell = null;

            IGrouping<int, Cell> dominantGroup = neighbors.Where(c => c is Cell && c.Id > 0)
                                .GroupBy(c => c.Id)
                                .OrderByDescending(g => g.Count())
                                .FirstOrDefault(); // most numerous group of neighbours

            if (dominantGroup?.Count() > 4)
                dominantCell = dominantGroup.FirstOrDefault();

            return dominantCell;
        }
    }

    public class NearestMoore : IRule
    {
        public Cell GetDominantCell(Cell[] neighbors, int? probability)
        {
            Cell dominantCell = null;

            IGrouping<int, Cell> dominantGroup = neighbors.Where((c, index) => c is Cell && c.Id > 0 && index % 2 != 0)
                                .GroupBy(c => c.Id)
                                .OrderByDescending(g => g.Count())
                                .FirstOrDefault();

            if (dominantGroup?.Count() > 2)
                dominantCell = dominantGroup.FirstOrDefault();

            return dominantCell;
        }
    }

    public class FurtherMoore : IRule
    {
        public Cell GetDominantCell(Cell[] neighbors, int? probability)
        {
            Cell dominantCell = null;

            IGrouping<int, Cell> dominantGroup = neighbors.Where((c, index) => c is Cell && c.Id > 0 && index % 2 == 0)
                                .GroupBy(c => c.Id)
                                .OrderByDescending(g => g.Count())
                                .FirstOrDefault();

            if (dominantGroup?.Count() > 2)
                dominantCell = dominantGroup.FirstOrDefault();

            return dominantCell;
        }
    }

    public class ProbabilityChoice : IRule
    {
        public Cell GetDominantCell(Cell[] neighbors, int? probability)
        {
            Cell dominantCell = null;
            int chance = RandomDevice.Next(1, 100);

            if (chance > probability)
                return dominantCell;

            IEnumerable<IGrouping<int, Cell>> groups = neighbors.Where(c => c is Cell && c.Id > 0)
                                             .GroupBy(c => c.Id)
                                             .OrderByDescending(g => g.Count());
            if (groups.Any())
            {
                IEnumerable<IGrouping<int, Cell>> max = groups.Where(x => x.Count() == groups.First().Count());
                dominantCell = max.ElementAt(RandomDevice.Next(max.Count())).First();
            }

            return dominantCell;
        }
    }
}
