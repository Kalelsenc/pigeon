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
        Bitmap bmp = new Bitmap(300, 300);

        public Paint()
        {
            InitializeComponent();

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
            Graphics gr = pictureBox1.CreateGraphics();
            gr.FillEllipse(Brushes.Black, X, Y, 10, 10);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();
            gr.Clear(Color.White);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            bmp.Save("D:/1.jpg");
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
        }
    }
}
