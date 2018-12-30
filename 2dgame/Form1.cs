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
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {           
            gr.Clear(Color.White);
            gr.FillRectangle(bg, Pebble.x, Pebble.y, Pebble.size, Pebble.size);
            Pebble.y -= 10 - (5 * tick);
            Pebble.x += 0;
            tick++;
            if (Pebble.y + 10 > pictureBox1.Height) { timer1.Enabled = false;}
            else if (Pebble.x + 10 > pictureBox1.Width) { timer1.Enabled = false; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gr = pictureBox1.CreateGraphics();
            bg = new SolidBrush(Color.Black);
            timer1.Enabled = true;
            Pebble.x = 0 + pictureBox1.Width / 2;
            Pebble.y = pictureBox1.Height / 2 - Pebble.size;
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
