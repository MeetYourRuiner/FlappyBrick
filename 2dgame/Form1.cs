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
        Form MainForm;
        List<Obstacle> Obstacles;
        int tick = 0;
        int speed = 1;
        GameDrawing gameDrawing;
        FallingStone Pebble;
        Bitmap BgCitySrc = _2dgame.Properties.Resources.City;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(Form form)
        {
            MainForm = form;
            InitializeComponent();
            MainForm.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Pebble.ScaledPengRect.Y > pictureBox1.Height)
                { this.GameOver(); }
            else
                foreach (Obstacle obs in Obstacles)
                {
                    if (Pebble.ScaledPengRect.IntersectsWith(obs.rectangle))
                        this.GameOver();
                }

            tick++;
            if (tick % (225 / speed) == 1)
            {
                 Obstacles.Add(new Obstacle());
            }
            if (tick % 900 == 1 && speed < 5)
            {
                speed++;
            }

            if (Obstacles.Count == 4)
            {
                Obstacles.RemoveAt(0);
            }
            gameDrawing.Draw(BgCitySrc, Pebble, Obstacles, speed);

            //Debug
            //gameDrawing.graphics.DrawString(tick.ToString() + '\n' + Pebble.ScaledPengRect.ToString() + '\n' + speed.ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 0, 0);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            Pebble = new FallingStone();

            Obstacles = new List<Obstacle>();

            gameDrawing = new GameDrawing(new Bitmap(BgCitySrc), ref pictureBox1, Pebble);

            timer1.Interval = 1000 / 60;
            timer1.Start();         
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    Pebble.Flap();
                    break;
            }
        }
        
        void GameOver()
        {
            timer1.Stop();
            this.OnLoad(new EventArgs());
        }
    }
}
