using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dgame
{
    public class FallingStone
    {
        public int x { get; set; }
        public int y { get; set; }
        public int size { get; set; }
        public Bitmap Pic { get; set; }
        public FallingStone(int _x, int _y, int _size)
        {
            this.x = _x;
            this.y = _y;
            this.size = _size;
        }

        public void Fly(int tick)
        {
            this.y -= 13 - (1 * tick);
        }
    }
}
