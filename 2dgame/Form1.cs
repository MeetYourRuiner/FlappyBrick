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
        GameDrawing gameDrawing;
        FallingStone Pebble = new FallingStone(0, 0, 10);
        int tick = 0;
        Bitmap BgCitySrc = _2dgame.Properties.Resources.City;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gameDrawing.Draw(BgCitySrc, Pebble);
            Pebble.Fly(tick++);
            if (Pebble.y > pictureBox1.Height) { timer1.Stop(); }
            else if (Pebble.x > pictureBox1.Width) { timer1.Stop(); }        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);        

            Pebble.Pic = _2dgame.Properties.Resources.Penguin;
            Pebble.x = 0 + pictureBox1.Width / 2;
            Pebble.y = pictureBox1.Height / 2 - Pebble.size;

            gameDrawing = new GameDrawing(new Bitmap(BgCitySrc), ref pictureBox1, Pebble);

            timer1.Interval = 1000 / 60;
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
