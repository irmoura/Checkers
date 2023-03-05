using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{
    public partial class Form1 : Form
    {

        private Graphics graphics;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            //
            Draw();
        }

        private void Draw()
        {
            int size = 800;
            int x = (this.Width / 2) - ((size / 2) + 9);
            int y = (this.Height / 2) - ((size / 2) + 8);
            //
            Rectangle rect = new Rectangle(x, y, size, size);
            //graphics.DrawRectangle(new Pen(new SolidBrush(Color.White), 1), rect);//checkerboard full size
            //
            int x_ = x;
            int y_ = y;
            //
            int xP = x;
            int yP = y;
            //
            int lowSize = (int)(size / (size * 0.01));
            bool switchColor = true;
            //
            for (int i = 0; i < (size * 0.01); i++)
            {
                for (int j = 0; j < (size * 0.01); j++)
                {
                    var rect_ = new Rectangle(x_, y_, lowSize, lowSize);
                    graphics.DrawRectangle(new Pen(new SolidBrush(Color.White), 1), rect_);//each sqare make the checkerboard
                    //
                    var rect_3 = new Rectangle(x_ + 2, y_ + 2, lowSize - 3, lowSize - 3);
                    //
                    switchColor = !switchColor;
                    var color = switchColor ? Color.Green : Color.LightGreen;//switching square colors
                    graphics.FillRectangle(new SolidBrush(color), rect_3);
                    //
                    if (switchColor && i < 3)
                    {
                        graphics.FillEllipse(new SolidBrush(Color.Red), xP + (lowSize / 4), yP + (lowSize / 4), lowSize / 2, lowSize / 2);//draw red circles
                    }
                    else
                    {
                        if (switchColor && i > 4)
                        {
                            graphics.FillEllipse(new SolidBrush(Color.White), xP + (lowSize / 4), yP + (lowSize / 4), lowSize / 2, lowSize / 2);//draw white circles
                        }
                    }
                    //
                    x_ += lowSize;
                    xP += lowSize;
                }
                switchColor = !switchColor;
                x_ = x;
                y_ += lowSize;
                //
                yP += lowSize;
                xP = x;
            }
        }
    }
}
