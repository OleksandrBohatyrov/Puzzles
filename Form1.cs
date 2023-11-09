using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        private bool PuzzlePieceClicked;
        private int PuzzlePieceIndex;
        private int PuzzlePieceX, PuzzlePieceY;
        private PictureBox[] puzzlePieces;

        public Form1()
        {
            InitializeComponent();
            InitializeUI();

        }

        private void InitializeUI()
        {


     

            //rectangle = new Rectangle(10, 10, 200, 100);
            //circle = new Rectangle(220, 10, 150, 150);
            //square = new Rectangle(380, 10, 150, 150);


       


            //PictureBoxes
            AddPuzzlePieces(1);
        
        }


        //private void OnPaint(object sender, PaintEventArgs e)
        //{
        //    Graphics graphics = e.Graphics;

        //    graphics.FillEllipse(Brushes.Red, circle);
        //    graphics.FillRectangle(Brushes.Blue, square);
        //    graphics.FillRectangle(Brushes.Yellow, rectangle);
        //}

        private void AddPuzzlePieces(int count)
        {
            puzzlePieces = new PictureBox[count];

            for (int i = 0; i < count; i++)
            {
                puzzlePieces[i] = new PictureBox();
                puzzlePieces[i].Location = new Point();
                puzzlePieces[i].Image = new Bitmap($"../../../{i + 1}.png");
                puzzlePieces[i].Size = new Size(280, 280);
                puzzlePieces[i].SizeMode = PictureBoxSizeMode.Zoom;

                puzzlePieces[i].MouseDown += new MouseEventHandler(OnMouseDown);
                puzzlePieces[i].MouseMove += new MouseEventHandler(OnMouseMove);
                puzzlePieces[i].MouseUp += new MouseEventHandler(OnMouseUp);

                Controls.Add(puzzlePieces[i]);
            }
        }

        public DoubleBufferedForm()
        {
            DoubleBuffered = true;
        }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < puzzlePieces.Length; i++)
            {
                if (puzzlePieces[i].Bounds.Contains(e.Location))
                {
                    PuzzlePieceClicked = true;
                    PuzzlePieceIndex = i;
                    PuzzlePieceX = e.X - puzzlePieces[i].Location.X;
                    PuzzlePieceY = e.Y - puzzlePieces[i].Location.Y;
                    Console.WriteLine("down");
                    break;
                }
            }
        }


        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (PuzzlePieceClicked)
            {
                Controls[PuzzlePieceIndex].Location = new Point(e.X - PuzzlePieceX, e.Y - PuzzlePieceY);
                Console.WriteLine("move");
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            PuzzlePieceClicked = false;

        }
    }


}
