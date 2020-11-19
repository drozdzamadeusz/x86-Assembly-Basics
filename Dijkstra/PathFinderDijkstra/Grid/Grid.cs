using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinderDijkstra.Grid
{
    public class Grid
    {
        public Cell[,] CellObjects { get; }


        public Grid(int horizontalCells, int verticalCells)
        {
            CellObjects = new Cell[horizontalCells, verticalCells];
            for (var x = 0; x < CellObjects.GetLength(0); x++)
            {
                for (var y = 0; y < CellObjects.GetLength(1); y++)
                {
                    SetCell(x, y, CellType.Empty);
                }
            }
        }

        public void ResetGrid()
        {
            for (var x = 0; x < CellObjects.GetLength(0); x++)
            {
                for (var y = 0; y < CellObjects.GetLength(1); y++)
                {
                    SetCell(x, y, CellType.Empty);
                }
            }
        }
    
        public Cell GetCell(int x, int y)
        {
            if (x > CellObjects.GetLength(0) - 1 || x < 0 || y > CellObjects.GetLength(1) - 1 || y < 0)
                return new Cell {coords=new Coords(x,y), type = CellType.Invalid};

            return CellObjects[x, y];
        }

        public Cell GetStart()
        {
            return CellObjects.Cast<Cell>().FirstOrDefault(cell => cell.type == CellType.A);
        }

        public Cell GetEnd()
        {
            return CellObjects.Cast<Cell>().FirstOrDefault(cell => cell.type == CellType.B);
        }

        public void SetCell(int x, int y, CellType type)
        {
            if (CellObjects[x, y] != null)
            {
                CellObjects[x, y].type = type;
            }
            else
            {
                CellObjects[x, y] = new Cell
                {
                    coords=new Coords(x,y),
                    type = type
                };
            }

            // SetStartAndEnd();
        }


        public int GetCountOfType(CellType type)
        {
            var total = 0;
            foreach (var cell in CellObjects)
            {
                total += cell.type == type ? 1 : 0;
            }

            return total;
        }

        public int GetTraversableCells()
        {
            return GetCountOfType(CellType.Unvisited) + GetCountOfType(CellType.A) + GetCountOfType(CellType.B);
        }

    }
}