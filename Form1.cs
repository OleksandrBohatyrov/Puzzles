using System;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private PictureBox pcBox;
        private Rectangle rectangle;
        private Rectangle circle;
        private Rectangle square;
        private bool RectangleClicked = false;
        private bool CircleClicked = false;
        private bool SquareClicked = false;
        private int RectangleX, RectangleY;

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            pcBox = new PictureBox();
            pcBox.Location = new Point(10, 10);
            pcBox.Size = new Size(900, 900);
            pcBox.Paint += new PaintEventHandler(OnPaint);
            pcBox.MouseDown += new MouseEventHandler(OnMouseDown);
            pcBox.MouseMove += new MouseEventHandler(OnMouseMove);
            pcBox.MouseUp += new MouseEventHandler(OnMouseUp);
            Controls.Add(pcBox);

            rectangle = new Rectangle(10, 10, 200, 100);
            circle = new Rectangle(220, 10, 150, 150);
            square = new Rectangle(380, 10, 150, 150);


            this.pcBox.BorderStyle = BorderStyle.Fixed3D;
        }
    

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.FillEllipse(Brushes.Red, circle);
            graphics.FillRectangle(Brushes.Blue, square);
            graphics.FillRectangle(Brushes.Yellow, rectangle);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (rectangle.Contains(e.Location))
            {
                RectangleClicked = true;
                RectangleX = e.X - rectangle.X;
                RectangleY = e.Y - rectangle.Y;
            }
            else if (circle.Contains(e.Location))
            {
                CircleClicked = true;
                RectangleX = e.X - circle.X;
                RectangleY = e.Y - circle.Y;
            }
            else if (square.Contains(e.Location))
            {
                SquareClicked = true;
                RectangleX = e.X - square.X;
                RectangleY = e.Y - square.Y;
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (RectangleClicked)
            {
                rectangle.X = e.X - RectangleX;
                rectangle.Y = e.Y - RectangleY;
                pcBox.Invalidate();
            }
            else if (CircleClicked)
            {
                circle.X = e.X - RectangleX;
                circle.Y = e.Y - RectangleY;
                pcBox.Invalidate();
            }
            else if (SquareClicked)
            {
                square.X = e.X - RectangleX;
                square.Y = e.Y - RectangleY;
                pcBox.Invalidate();
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            RectangleClicked = false;
            CircleClicked = false;
            SquareClicked = false;
        }
    }
}
