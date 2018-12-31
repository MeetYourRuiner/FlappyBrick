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
        int time = 0;
        int ScaleRatio = 4;
        public int x { get; set; }
        public int y { get; set; }
        public int size { get; set; }
        public Bitmap Pic = _2dgame.Properties.Resources.Penguin;
        public Rectangle ScaledPengRect { get; set; }
        public Rectangle DefPengRect { get; set; }

        public FallingStone()
        {
            this.ScaledPengRect = new Rectangle
                (
                    225 - (this.Pic.Width / ScaleRatio / 2),
                    225,
                    this.Pic.Width / ScaleRatio, 
                    this.Pic.Height / ScaleRatio
                );
            this.DefPengRect = new Rectangle
                (
                    0, 
                    0, 
                    this.Pic.Width, 
                    this.Pic.Height
                );
        }

        public void Fly()
        {
            var temp = this.ScaledPengRect;
            temp.Y -= 13 - (1 * time);
            if (temp.Y < 0) temp.Y = 0;
            this.ScaledPengRect = temp;
            time++;
        }

        public void Flap()
        {
            time = 0;
        }
    }

    public class Obstacle
    {
        Random rnd = new Random();
        public Rectangle rectangle { get; set; }
        public Rectangle defrectangle { get; set; }
        public Obstacle ()
        {
            int height = rnd.Next(100, 250);
            int y;
            if (rnd.Next(0, 2) == 1)
                y = 450 - height;
            else y = 0;
            this.rectangle = new Rectangle(445, y, 30, height);
            this.defrectangle = new Rectangle(0, 0, 200, 400);
        }
        public void Shift(int speed)
        {
            var temp = this.rectangle;
            temp.X-= (1 + speed);
            this.rectangle = temp;
        }
    }
}
