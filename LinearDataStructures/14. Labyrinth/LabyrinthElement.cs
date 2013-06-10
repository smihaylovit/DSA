using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthNS
{
    public class LabyrinthElement
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Value { get; set; }

        public LabyrinthElement(int x, int y, int value)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }

        public LabyrinthElement(LabyrinthElement element)
        {
            this.X = element.X;
            this.Y = element.Y;
            this.Value = element.Value;
        }
    }
}