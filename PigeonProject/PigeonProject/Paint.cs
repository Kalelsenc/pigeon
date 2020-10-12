using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace PigeonProject
{
    public partial class Paint : Form
    {
        int X, Y;
        int lastX=int.MinValue, lastY=int.MinValue;
        Bitmap bmp = new Bitmap(300, 300);
        Graphics gr;
        Pen pen = new Pen(Brushes.Black);
        public Paint()
        {
            InitializeComponent();
            gr = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            pen.Width = 20;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(lastX != int.MinValue)
                gr.DrawLine(pen, lastX, lastY, X, Y);
            lastX = X;
            lastY = Y;
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            lastX = int.MinValue;
            lastY = int.MinValue;
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.bmp = bmp;
            Close();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
        }
    }
}
