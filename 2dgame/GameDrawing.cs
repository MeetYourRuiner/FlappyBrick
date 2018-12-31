﻿using System;
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
        int shift = 0;
        Rectangle destinationRect;
        Rectangle sourceRect;
        SolidBrush bg = new SolidBrush(Color.Black);
        public Graphics graphics { get; set; }
        public PictureBox Parent { get; set; }
        public Bitmap Game { get; set; }
        Bitmap Ice = _2dgame.Properties.Resources.Ice;
        public GameDrawing (Bitmap bm, ref PictureBox _Parent, FallingStone Pebble)
        {
            this.Game = bm;
            this.graphics = Graphics.FromImage(Game);
            this.Parent = _Parent;
            this.Parent.Image = Game;

            destinationRect = new Rectangle(0, 0, bm.Width, bm.Height);
            sourceRect = destinationRect;
        }
        public void Draw (Bitmap bgimg, FallingStone Pebble, List<Obstacle> Obstacles, int speed)
        {
            if (shift > destinationRect.Width / 2) { shift = 1 + speed; }
            else destinationRect.X = shift += (1 + speed);
            graphics.DrawImage(bgimg, sourceRect, destinationRect, GraphicsUnit.Pixel);
            graphics.DrawImage(Pebble.Pic, Pebble.ScaledPengRect, Pebble.DefPengRect, GraphicsUnit.Pixel);

            //Debug
            //graphics.FillRectangle(new SolidBrush(Color.Red), 450 / 2, 450 / 2, 2, 2);
            //graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1), Pebble.ScaledPengRect);

            Pebble.Fly();

            foreach (Obstacle obs in Obstacles)
            {
                //graphics.FillRectangle(new SolidBrush(Color.DodgerBlue), obs.rectangle);
                graphics.DrawImage(Ice, obs.rectangle, obs.defrectangle, GraphicsUnit.Pixel);
                obs.Shift(speed);
            }

            Parent.Invalidate();
        }
    }
}
