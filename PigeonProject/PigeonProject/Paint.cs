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
        string path = "";
        public Paint()
        {
            InitializeComponent();
            gr = Graphics.FromImage(bmp);
            gr.Clear(Color.White);
            pictureBox1.Image = bmp;
            pen.Width = 30;
            domainUpDown1.SelectedIndex = 1;
            pictureBox1.Focus();
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

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBW = new FolderBrowserDialog();
            FBW.ShowDialog();
            path = FBW.SelectedPath;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                numericUpDown1.Visible = true;
            else
                numericUpDown1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                bmp.Save(path+"\\" + domainUpDown1.SelectedItem.ToString() + "_"+ numericUpDown1.Value + ".png");
                gr.Clear(Color.White);
                pictureBox1.Image = bmp;
                if (domainUpDown1.SelectedIndex == 32)
                {
                    domainUpDown1.SelectedIndex = 0;
                    numericUpDown1.Value++;
                }
                else
                    domainUpDown1.SelectedIndex++;
            }
            else
            {
                Program.bmp = new Bitmap(pictureBox1.Image, 30, 30);
                Close();
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
        }
    }
}
