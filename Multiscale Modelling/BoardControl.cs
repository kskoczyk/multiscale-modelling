﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private SolidBrush phaseBrush = new SolidBrush(Color.DeepPink);
        private SolidBrush selectionBrush = new SolidBrush(Color.Yellow);
        private SolidBrush borderBrush = new SolidBrush(Color.Aqua);
        private SolidBrush emptyBrush = new SolidBrush(Color.White);
        public int BorderThickness = 1;
        public bool ShowPhases = true;
        public bool ShowBorders = true;
        public bool ShowSubstructure = true;

        public Cell SelectedCell = null;

        public Board Board = new Board();
		//public Action<string, Logs.LogLevel> Log { get; set; } // TESTING
		//public Func<int, sbyte, string> MyProperty { get; set; } // same as Action, but has return type
		public BoardControl()
        {
            InitializeComponent();
        }

		protected override void OnLoad(EventArgs e) // TESTING
		{
			base.OnLoad(e);

			//Log?.Invoke("CTOR", Logs.LogLevel.Info);
			//Task.Run(() => Log("TASK", Logs.LogLevel.Error));
			//this.Invoke(new Action(() => Log?.Invoke("Invoke", Logs.LogLevel.Info)));
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

        private object _lock = new object();
        public void Draw(IEnumerable<Cell> cellsToDraw = null)
        {
            if (!IsHandleCreated)
                return;

            CalculateCellSize();

            lock (_lock) // lock to make window resizing thread-safe
            {
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
            }

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

        public SolidBrush GetBrush(Cell cell)
        {
            SolidBrush brush = null;

            if (ShowBorders && cell.IsOnBorder)
                brush = borderBrush;
            else if (cell.IsSelected)
                brush = selectionBrush;
            else if (ShowPhases && cell.Phase == 1)
                brush = phaseBrush;
            else if (ShowSubstructure)
                brush = Cell.UniqueColors[cell.Color.ToArgb()];
            else
                brush = emptyBrush;

            return brush;
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
                        graphics.FillRectangle(GetBrush(cell), cellSize * cell.Position.X - 1, cellSize * cell.Position.Y - 1, cellSize + 1, cellSize + 1);
                    }
                }
            }
            else
            {
                foreach (Cell cell in cellsToDraw)
                {
                    graphics.FillRectangle(GetBrush(cell), cellSize * cell.Position.X - 1, cellSize * cell.Position.Y - 1, cellSize + 1, cellSize + 1);
                }
            }
        }

        public void LoadBoard(Bitmap bitmap, int cellBmpSize)
        {
            Board.Clear();
            int rowsCount = bitmap.Height / cellBmpSize;
            int columnsCount = bitmap.Width / cellBmpSize;

            CellNumberHeight = rowsCount;
            CellNumberWidth = columnsCount;

            HashSet<int> colors = new HashSet<int>()
            {
                Color.Black.ToArgb(),
                Color.White.ToArgb()
            };

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    Color color = bitmap.GetPixel(j * cellBmpSize, i * cellBmpSize);
                    int colorArgb = color.ToArgb();
                    colors.Add(colorArgb);

                    var list = colors.ToList();

                    var id = list.IndexOf(list.Find(x => x == colorArgb)) - 1;
                    Board.GetCell(i, j).SetId(id);
                    Board.GetCell(i, j).SetColor(color);
                }
            }
        }

        public void LoadBoard(List<(int Id, int Phase, int IndexX, int IndexY)> cellsToLoad)
        {
            int maxIndexX = cellsToLoad.Select(c => c.IndexX).Max();
            int maxIndexY = cellsToLoad.Select(c => c.IndexY).Max();

            CellNumberHeight = maxIndexY + 1;
            CellNumberWidth = maxIndexX + 1;

            HashSet<int> colors = new HashSet<int>()
            {
                Color.Black.ToArgb(),
                Color.White.ToArgb()
            };

            int coloredCells = cellsToLoad.Select(c => c.Id).Where(id => id > 0).Distinct().Count();
            while (colors.Count < coloredCells + 2)
                colors.Add(Color.FromArgb(RandomDevice.Next(255), RandomDevice.Next(255), RandomDevice.Next(255)).ToArgb()); // TODO: colors will vary between consequent imports

            foreach ((int Id, int Phase, int IndexX, int IndexY) in cellsToLoad)
            {
                // TODO: cell c = get()...
                Board.GetCell(IndexY, IndexX).SetId(Id);
                Board.GetCell(IndexY, IndexX).Phase = Phase;
                Board.GetCell(IndexY, IndexX).SetColor(Color.FromArgb(colors.ToList().ElementAt(Id + 1)));
            }
        }

        private void pictureBoxBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Board.IsSimulationFinished)
               return;

            int indexX = ToInt32(Math.Floor(e.X / cellSize)); // this is safe because cellSize is calculated at the very start when 1-cell board is drawn
            int indexY = ToInt32(Math.Floor(e.Y / cellSize));

            if (indexX > Board.ColumnCount - 1 || indexY > Board.RowCount - 1)
                return;

            SelectedCell = Board.GetCell(indexY, indexX);

            if (e.Button == MouseButtons.Left) // phase selection
            {
                Logs.Log($"Seed {SelectedCell.Id} selected ({SelectedCell.Position.X}, {SelectedCell.Position.Y})", Logs.LogLevel.Info);
                IEnumerable<Cell> shiftedCells = Board.ShiftPhase(SelectedCell);
                Draw(shiftedCells); // add cells to draw
            }
            else if (e.Button == MouseButtons.Right) // border drawing
            {
                Logs.Log($"Seed {SelectedCell.Id} selected ({SelectedCell.Position.X}, {SelectedCell.Position.Y})", Logs.LogLevel.Info);
                Board.SetBorderCells(BorderThickness, SelectedCell.Id);
                Draw();
            }
            else if (e.Button == MouseButtons.Middle) // mode selection
            {
                // switch mode
                //Logs.Log("Middle button clicked!", Logs.LogLevel.Info);
                // option ++
                // option = option % 
                // var namesCount = Enum.GetNames(typeof(MyEnum)).Length;
                //var test = SelectedCell.GetNeighborsByPreviousId(SelectedCell.PreviousId);
                Logs.Log($"Seed {SelectedCell.Id} selected ({SelectedCell.Position.X}, {SelectedCell.Position.Y})", Logs.LogLevel.Info);

                if (SelectedCell.IsSelected)
                {
                    IEnumerable<Cell> deselectedCells = Board.DeselectAll();
                    Draw(deselectedCells);
                }
                else
                {
                    //IEnumerable<Cell> selectedCells = Board.Select(SelectedCell.Id);
                    Board.Select(SelectedCell.Id);
                    Draw(); // has to redraw the whole board due to possible deselecting of another group
                }
            }
        }
    }
}
