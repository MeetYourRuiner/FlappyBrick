using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2dgame
{
    class GameDrawing
    {
        int ScaleRatio = 4;
        int shift = 0;
        Rectangle destinationRect;
        Rectangle sourceRect;
        Rectangle ScaledPengRect;
        Rectangle DefPengRect;
        SolidBrush bg = new SolidBrush(Color.Black);
        public Graphics graphics { get; set; }
        public PictureBox Parent { get; set; }
        public Bitmap Game { get; set; }
        public GameDrawing (Bitmap bm, ref PictureBox _Parent, FallingStone Pebble)
        {
            this.Game = bm;
            this.graphics = Graphics.FromImage(Game);
            this.Parent = _Parent;
            this.Parent.Image = Game;
            destinationRect = new Rectangle(0, 0, bm.Width, bm.Height);
            sourceRect = destinationRect;
            ScaledPengRect = new Rectangle(0, 0, Pebble.Pic.Width / ScaleRatio, Pebble.Pic.Height / ScaleRatio);
            DefPengRect = new Rectangle(0, 0, Pebble.Pic.Width, Pebble.Pic.Height);
            ScaledPengRect.X = Pebble.x - (Pebble.Pic.Width / ScaleRatio / 2);
        }
        public void Draw (Bitmap bgimg, FallingStone Pebble)
        {
            if (shift > 450) shift = 1;
            else destinationRect.X = shift += 1;
            ScaledPengRect.Y = Pebble.y - (Pebble.Pic.Height / ScaleRatio / 2);
            
            graphics.DrawImage(bgimg, sourceRect, destinationRect, GraphicsUnit.Pixel);
            graphics.DrawImage(Pebble.Pic, ScaledPengRect, DefPengRect, GraphicsUnit.Pixel);
            graphics.FillRectangle(new SolidBrush(Color.Red), 450 / 2, 450 / 2, 2, 2);
            Parent.Invalidate();
        }
    }
}
