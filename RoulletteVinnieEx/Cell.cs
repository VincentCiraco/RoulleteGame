using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoulletteVinnieEx
{
    class Cell
    {
        public int Value { get; set; }
        public CellColor Color { get; set; }
        public Cell()
        {

        }
        public Cell(int value, CellColor color)
        {
            this.Value = value;
            this.Color = color;
        }
    }
}
