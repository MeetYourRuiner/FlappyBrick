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
        List<Obstacle> Obstacles;
        int GameState = 0;
        int tick = 0;
        int speed = 1;
        int _score = 0;
        GameDrawing gameDrawing;
        FallingStone Pebble;
        Bitmap BgCitySrc = _2dgame.Properties.Resources.City;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tick++;

            // If penguin hit obstacle or bottom, then stop the game
            if (Pebble.ScaledPengRect.Y + Pebble.ScaledPengRect.Height / 2 > pictureBox1.Height)
                { this.GameOver(); }
            else
                foreach (Obstacle obs in Obstacles)
                {
                    if (Pebble.ScaledPengRect.IntersectsWith(obs.rectangle))
                        this.GameOver();
                }
            // Add new obstacle
            if (tick % (450 / (5 * speed / 2)) == 0)
            {
                 Obstacles.Add(new Obstacle());
            }

            if (tick % (350 * speed) == 1 && speed < 4 && tick > 0)
            {
                speed++;
            }
            // Delete passed obstacle
            if (Obstacles.Count == 4)
            {
                Obstacles.RemoveAt(0);
            }
            
            gameDrawing.Draw(BgCitySrc, Pebble, Obstacles, speed, tick);

            if (tick % 15 == 1)
                _score += (5 * (speed - 2));

            //Debug
            //gameDrawing.graphics.DrawString(tick.ToString() + '\n' + Pebble.ScaledPengRect.ToString() + '\n' + speed.ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 0, 0);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tick = 0;
            speed = 2;
            _score = 0;

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            Pebble = new FallingStone();

            Obstacles = new List<Obstacle>();

            gameDrawing = new GameDrawing(new Bitmap(BgCitySrc), ref pictureBox1, Pebble);

            timer1.Interval = 1000 / 60;
            timer1.Start();
            GameState = 1;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (GameState == 0)
                        pictureBox2_Click(sender, new EventArgs());
                    Pebble.Flap();
                    break;
            }
        }
        
        public void GameOver()
        {
            GameState = 0;
            timer1.Stop();
            pictureBox1.Hide();
            pictureBox2.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Hide();
            pictureBox1.Show();
            this.OnLoad(new EventArgs());
        }
    }
}
