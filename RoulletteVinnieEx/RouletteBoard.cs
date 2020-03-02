using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoulletteVinnieEx
{
    class RouletteBoard
    {
        public Cell[] ZeroCells { get; set; }
        public Cell[,] GridCells { get; set; }
        public RouletteBoard()
        {
            ZeroCells = new Cell[2];
            ZeroCells[0] = new Cell(0, CellColor.Green);
            ZeroCells[1] = new Cell(37, CellColor.Green);
            GridCells = new Cell[12, 3];
            GridCells[0, 0] = new Cell(1, CellColor.Red);
            GridCells[0, 1] = new Cell(2, CellColor.Black);
            GridCells[0, 2] = new Cell(3, CellColor.Red);
            GridCells[1, 0] = new Cell(4, CellColor.Black);
            GridCells[1, 1] = new Cell(5, CellColor.Red);
            GridCells[1, 2] = new Cell(6, CellColor.Black);
            GridCells[2, 0] = new Cell(7, CellColor.Red);
            GridCells[2, 1] = new Cell(8, CellColor.Black);
            GridCells[2, 2] = new Cell(9, CellColor.Red);
            GridCells[3, 0] = new Cell(10, CellColor.Black);
            GridCells[3, 1] = new Cell(11, CellColor.Black);
            GridCells[3, 2] = new Cell(12, CellColor.Red);
            GridCells[4, 0] = new Cell(13, CellColor.Black);
            GridCells[4, 1] = new Cell(14, CellColor.Red);
            GridCells[4, 2] = new Cell(15, CellColor.Black);
            GridCells[5, 0] = new Cell(16, CellColor.Red);
            GridCells[5, 1] = new Cell(17, CellColor.Black);
            GridCells[5, 2] = new Cell(18, CellColor.Red);
            GridCells[6, 0] = new Cell(19, CellColor.Red);
            GridCells[6, 1] = new Cell(20, CellColor.Black);
            GridCells[6, 2] = new Cell(21, CellColor.Red);
            GridCells[7, 0] = new Cell(22, CellColor.Black);
            GridCells[7, 1] = new Cell(23, CellColor.Red);
            GridCells[7, 2] = new Cell(24, CellColor.Black);
            GridCells[8, 0] = new Cell(25, CellColor.Red);
            GridCells[8, 1] = new Cell(26, CellColor.Black);
            GridCells[8, 2] = new Cell(27, CellColor.Red);
            GridCells[9, 0] = new Cell(28, CellColor.Black);
            GridCells[9, 1] = new Cell(29, CellColor.Black);
            GridCells[9, 2] = new Cell(30, CellColor.Red);
            GridCells[10, 0] = new Cell(31, CellColor.Black);
            GridCells[10, 1] = new Cell(32, CellColor.Red);
            GridCells[10, 2] = new Cell(33, CellColor.Black);
            GridCells[11, 0] = new Cell(34, CellColor.Red);
            GridCells[11, 1] = new Cell(35, CellColor.Black);
            GridCells[11, 2] = new Cell(36, CellColor.Red);
        }
    }
}
