using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        static int n = 2000;// количество звёзд
        star[] s = new star[n];
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < n; i++)
            {
                s[i] = new star();
                s[i].x = r.Next(10, pictureBox1.Width);
                s[i].y = r.Next(1, pictureBox1.Height);
                s[i].speed = r.Next(1, 10);
                s[i].size = r.Next(1, 5);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
   
        private void PrepateGraph()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            PrepateGraph();
            for (int i = 0; i < n; i++)
            {
                s[i].move(pictureBox1.Width, pictureBox1.Height, r);
                g.FillEllipse(Brushes.White, (int)s[i].x, (int)s[i].y, (int)s[i].size, (int)s[i].size);
            }
            pictureBox1.BackgroundImage = bmp;
        }
    }
    public partial class star
    {
        public double x, y, speed, size;

        public void move(int maxX, int maxY, Random r)
        {
            y += speed;
            if (y > maxY)
            {
                x = r.Next(1, maxX - 1); y = 0; speed = r.Next(1, 10); size = r.Next(1, 5);
            }
        }
    }
}
