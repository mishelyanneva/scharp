using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applicationcsharp
{
    public partial class Form1 : Form
    {
        List<Rectangle> shapeList1 = new List<Rectangle>();
        List<Ellipse> shapeList2 = new List<Ellipse>();
        List<Line> shapesList3 = new List<Line>();


        public Form1()
        {
            InitializeComponent();

            this.Width = 780;
            this.Height = 410;
            bm = new Bitmap(pic.Width, pic.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pic.Image = bm;
        }

        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 1);
        Pen eraser = new Pen(Color.White, 10);
        int index;
        int x, y, sX, sY, cX, cY;

        ColorDialog cd = new ColorDialog();
        Color new_color;
        private object pixel;

        class Shape
        {
            Bitmap bm { get; set; }
            public Graphics g { get; set; }
            public Point px { get; set; }
            public Point py { get; set; }
            public Pen p { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public int sX { get; set; }
            public int sY { get; set; }
            public int cX { get; set; }
            public int cY { get; set; }

            public Shape(int x, int y, int sX, int sY, int cX, int cY,
                Bitmap bm, Graphics g, Point px, Point py, Pen p)
            {
                this.x = x;
                this.y = y;
                this.sX = sX;
                this.sY = sY;
                this.cX = cX;
                this.cY = cY;
                this.bm = bm;
                this.g = g;
                this.px = px;
                this.py = py;
                this.p = p;
            }
        }

        class Rectangle : Shape
        {
            public Rectangle(int x, int y, int sX, int sY, int cX, int cY,
                Bitmap bm, Graphics g, Point px, Point py, Pen p)
                : base(x, y, sX, sY, cX, cY, bm, g, px, py, p)
            {
            }

            public void Draw()
            {
                this.g.DrawRectangle(this.p, this.cX, this.cY, this.sX, this.sY);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }



        private void pic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;

            cX = e.X;
            cY = e.Y;
        }

        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                if (index == 1)
                {
                    px = e.Location;
                    g.DrawLine(p, px, py);
                    py = px;
                }

                if (index == 2)
                {
                    px = e.Location;
                    g.DrawLine(eraser, px, py);
                    py = px;
                }

                pic.Refresh();
                x = e.X;
                y = e.Y;
                sX = e.X - cX;
                sY = e.Y - cY;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void color__Click(object sender, EventArgs e)
        {

        }
        class Ellipse : Shape
        {
            public Ellipse(int x, int y, int sX, int sY, int cX, int cY,
                Bitmap bm, Graphics g, Point px, Point py, Pen p)
                : base(x, y, sX, sY, cX, cY, bm, g, px, py, p)
            {
            }

            public void Draw()
            {
                this.g.DrawEllipse(this.p, this.cX, this.cY, this.sX, this.sY);
            }
        }
        class Line : Shape
        {
            public Line(int x, int y, int sX, int sY, int cX, int cY,
                Bitmap bm, Graphics g, Point px, Point py, Pen p)
                : base(x, y, sX, sY, cX, cY, bm, g, px, py, p)
            {
            }

            public void Draw()
            {
                this.g.DrawLine(this.p, this.cX, this.cY, this.sX, this.sY);
            }
        }

        class Fill : Shape
        {
            public Fill(int x, int y, int sX, int sY, int cX, int cY,
                Bitmap bm, Graphics g, Point px, Point py, Pen p)
                : base(x, y, sX, sY, cX, cY, bm, g, px, py, p)
            {
            }
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;

            sX = x - cX;
            sY = y - cY;

            if (index == 3)
            {
                g.DrawEllipse(p, cX, cY, sX, sY);
            }
            if (index == 4)
            {
                g.DrawRectangle(p, cX, cY, sX, sY);
            }
            if (index == 5)
            {
                g.DrawLine(p, cX, cY, x, y);
            }
        }

        private void btn_pencil_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void btn_eraser_click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void btn_ellipse_Click(object sender, EventArgs e)
        {
            index = 3;
        }

        private void btn_rectangle_Click(object sender, EventArgs e)
        {
            index = 4;
        }
        private void btn_line_Click(object sender, EventArgs e)
        {
            index = 5;
        }

        private void pic_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (paint)
            {
                if (index == 3)
                {
                    g.DrawEllipse(p, cX, cY, sX, sY);
                }
                if (index == 4)
                {
                    g.DrawRectangle(p, cX, cY, sX, sY);
                }
                if (index == 5)
                {
                    g.DrawLine(p, cX, cY, x, y);
                }
            }
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pic.Image = bm;
            index = 0;
        }
        private void btn_color_Click(object sender, EventArgs e)
        {
            cd.ShowDialog();
            new_color = cd.Color;
            pic_color.BackColor = cd.Color;
            p.Color = cd.Color;
        }



    
    }
}

