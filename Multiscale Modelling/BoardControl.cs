using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Convert;

namespace Multiscale_Modelling
{
    public partial class BoardControl : UserControl
    {
        private Bitmap bitmap;
        private Graphics graphics;
        private float cellSize;
        private int bitmapSize;
        private Pen gridPen = new Pen(Color.Black);

        public Board Board = new Board();
		public Action<string, Logs.LogLevel> Log { get; set; } // TESTING TODO: use static instead
		//public Func<int, sbyte, string> MyProperty { get; set; } // same as Action, but has return type
		public BoardControl()
        {
            InitializeComponent();
        }

		protected override void OnLoad(EventArgs e) // TESTING
		{
			base.OnLoad(e);

			Log?.Invoke("CTOR", Logs.LogLevel.Info);
			//Task.Run(() => Log("TASK", Logs.LogLevel.Error));
			this.Invoke(new Action(() => Log?.Invoke("Invoke", Logs.LogLevel.Info)));
		}

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ResizeBitmap();
            Draw();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeBitmap();
            Draw();
        }


        private int _cellNumberWidth;
        public int CellNumberWidth
        {
            get => _cellNumberWidth;
            set
            {
                if (_cellNumberWidth != value)
                {
                    _cellNumberWidth = value;
                    Board.Resize(CellNumberWidth, CellNumberHeight);
                    Draw();
                }
            }
        }

        private int _cellNumberHeight;
        public int CellNumberHeight
        {
            get => _cellNumberHeight;
            set
            {
                if (_cellNumberHeight != value)
                {
                    _cellNumberHeight = value;
                    Board.Resize(CellNumberWidth, CellNumberHeight);
                    Draw();
                }
            }
        }

        private bool _isGridEnabled = false; // TODO: check whether it has to be consistent with checkbox
        public bool IsGridEnabled
        {
            get => _isGridEnabled;
            set
            {
                _isGridEnabled = value;
                Draw();
            }
        }

        private void ResizeBitmap() // TODO: adapt to rectangular boards instead of keeping a square
        {
            bitmapSize = pictureBoxBoard.Width < pictureBoxBoard.Height ? pictureBoxBoard.Width : pictureBoxBoard.Height;
            bitmap = new Bitmap(bitmapSize, bitmapSize);
            pictureBoxBoard.Image?.Dispose();
            pictureBoxBoard.Image = bitmap;
            graphics = Graphics.FromImage(bitmap);
        }

        private void CalculateCellSize()
        {
            float cellWidth = 1.0f * bitmapSize / CellNumberWidth;
            float cellHeight = 1.0f * bitmapSize / CellNumberHeight;
            cellSize = cellWidth < cellHeight ? cellWidth : cellHeight;
        }

        public void Draw(IEnumerable<Cell> cellsToDraw = null)
        {
            if (!IsHandleCreated)
                return;

            CalculateCellSize();

            if (pictureBoxBoard.Image == null)
                ResizeBitmap();

            if (cellsToDraw?.Count() > 0)
            {
                // print selected
                DrawCells(cellsToDraw);
            }
            else
            {
                // print all
                graphics.Clear(Color.White);
                DrawCells();
            }

            if (IsGridEnabled)
                DrawGrid();

            pictureBoxBoard.Invoke(new Action(() => pictureBoxBoard.Image = bitmap)); // invoke - draw pictureBox in the main thread
        }

        public void DrawGrid()
        {
            // vertical lines
            graphics.DrawLine(gridPen, 0, 0, 0, ToSingle(CellNumberHeight * cellSize));
            for (int i = 0; i <= CellNumberWidth; i++)
                graphics.DrawLine(gridPen, ToSingle(i * cellSize) - 1, 0, ToSingle(i * cellSize) - 1, ToSingle(CellNumberHeight * cellSize));

            // horizontal lines
            graphics.DrawLine(gridPen, 0, 0, ToSingle(CellNumberWidth * cellSize), 0);
            for (int i = 0; i <= CellNumberHeight; i++)
                graphics.DrawLine(gridPen, 0, ToSingle(i * cellSize) - 1, ToSingle(CellNumberWidth * cellSize), ToSingle(i * cellSize) - 1);
        }

        public void DrawCells(IEnumerable<Cell> cellsToDraw = null)
        {
            if (cellsToDraw == null)
            {
                for (int i = 0; i < Board.RowCount; i++)
                {
                    for (int j = 0; j < Board.ColumnCount; j++)
                    {
                        Cell cell = Board.GetCell(row: i, column: j);
                        SolidBrush brush = Cell.UniqueColors[cell.Color.ToArgb()];
                        graphics.FillRectangle(brush, cellSize * cell.Position.X - 1, cellSize * cell.Position.Y - 1, cellSize + 1, cellSize + 1);
                    }
                }
            }
            else
            {
                foreach (Cell cell in cellsToDraw)
                {
                    SolidBrush brush = Cell.UniqueColors[cell.Color.ToArgb()];
                    graphics.FillRectangle(brush, cellSize * cell.Position.X - 1, cellSize * cell.Position.Y - 1, cellSize + 1, cellSize + 1);
                }
            }
        }
    }
}
