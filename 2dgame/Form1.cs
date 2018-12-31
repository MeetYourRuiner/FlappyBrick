using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2dgame
{
    public partial class Form1 : Form
    {

        Graphics gr;
        SolidBrush bg = new SolidBrush(Color.Black);
        FallingStone Pebble = new FallingStone(0, 0, 10);
        int tick = 0;
        int pic = 0;
        RectangleF sourceRect = new Rectangle(0, 0, 600, 450);
        RectangleF destRect = new Rectangle(0, 0, 450, 450);
        Bitmap BgCitySrc = _2dgame.Properties.Resources.City;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            gr.DrawImage(BgCitySrc, 0, 0);
            gr.FillRectangle(bg, Pebble.x, Pebble.y, Pebble.size, Pebble.size);
            Pebble.Fly(tick++);
            pictureBox1.Invalidate();
            if (Pebble.y > pictureBox1.Height) { timer1.Stop(); }
            else if (Pebble.x > pictureBox1.Width) { timer1.Stop(); }        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            timer1.Interval = 1000 / 24;
            Bitmap BgCity = _2dgame.Properties.Resources.City;
            gr = Graphics.FromImage(BgCity);
            pictureBox1.Image = BgCity;
            Pebble.x = 0 + pictureBox1.Width / 2;
            Pebble.y = pictureBox1.Height / 2 - Pebble.size;
            timer1.Start();         
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    tick = 0;
                    break;
            }
        }
    }
}
