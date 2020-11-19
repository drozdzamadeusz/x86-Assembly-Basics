using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinderDijkstra.Grid
{
    public enum CellType
        {
            Invalid = -1,
            Solid = 0,
            Empty = 1,
            A = 2,
            B = 3,
            Path = 5,
            Unvisited = 6,
            Visited = 7,
            Current = 8
        }
}
