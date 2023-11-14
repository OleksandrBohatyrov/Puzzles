using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class PuzzlePiece : Control
    {
        private Bitmap image;
        private bool isClicked;
        private int offsetX, offsetY;

        public PuzzlePiece(Bitmap image)
        {
            this.image = image;
            Cursor = Cursors.Hand;

            // Calculate the size while maintaining the original aspect ratio
            float aspectRatio = (float)image.Width / image.Height;
            int newWidth = 100; // Set your desired width
            int newHeight = (int)(newWidth / aspectRatio);
            Size = new Size(newWidth, newHeight);

            MouseDown += OnMouseDown;
            MouseMove += OnMouseMove;
            MouseUp += OnMouseUp;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            isClicked = true;
            offsetX = e.X;
            offsetY = e.Y;
            Console.WriteLine("down");
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (isClicked)
            {
                Location = new Point(Location.X + e.X - offsetX, Location.Y + e.Y - offsetY);
                Console.WriteLine("move");
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            isClicked = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(image, ClientRectangle);
        }
    }

    public partial class Form1 : Form
    {
        private PuzzlePiece[] puzzlePieces;

        public Form1()
        {
            InitializeComponent();
            InitializeUI();

        }

        private void InitializeUI()
        {
            AddPuzzlePieces(24);
        }

        private void AddPuzzlePieces(int count)
        {
            puzzlePieces = new PuzzlePiece[count];

            for (int i = 0; i < count; i++)
            {
                Bitmap puzzleImage = new Bitmap($"../../../{i + 1}.png");
                puzzleImage.MakeTransparent();


                puzzlePieces[i] = new PuzzlePiece(puzzleImage)
                {
                    Location = new Point(10, 10),
                };

                Controls.Add(puzzlePieces[i]);
            }

        }

    }
}