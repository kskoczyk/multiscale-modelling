using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Multiscale_Modelling
{
    public partial class BoardControl : UserControl
    {
        private Bitmap bitmap;
        private Graphics graphics;
        public Board Board = new Board();
		public Action<string, Logs.LogLevel> Log { get; set; } // TODO: use static instead
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
        public int GridCellWidth
        {
            get => _cellNumberWidth;
            set
            {
                if (_cellNumberWidth != value)
                {
                    _cellNumberWidth = value;
                    //Matrix.Rearange(_gridCellWidth, _gridCellHeight);
                    Draw();
                }
            }
        }

        private int _cellNumberHeight;
        public int GridCellHeight
        {
            get => _cellNumberHeight;
            set
            {
                if (_cellNumberHeight != value)
                {
                    _cellNumberHeight = value;
                    //Matrix.Rearange(_gridCellWidth, _gridCellHeight);
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

        public void ResizeBitmap()
        {
            int bitmapSize = pictureBoxBoard.Width < pictureBoxBoard.Height ? pictureBoxBoard.Width : pictureBoxBoard.Height;
            bitmap = new Bitmap(bitmapSize, bitmapSize);
            pictureBoxBoard.Image?.Dispose();
            pictureBoxBoard.Image = bitmap;
            graphics = Graphics.FromImage(bitmap);
        }

        public void Draw(IEnumerable<Cell> cellsToDraw = null)
        {
            if (!IsHandleCreated)
                return;

            //CalculateCellSize();
            if (pictureBoxBoard.Image == null)
            {
                //pictureBoxBoard.Image?.Dispose();
                //pictureBoxBoard.Image = new Bitmap(pictureBoxBoard.Width, pictureBoxBoard.Height);
                //bitmap = new Bitmap(pictureBoxBoard.Width, pictureBoxBoard.Height);
            }

            if (cellsToDraw?.Count() > 0)
            {
                //PrintCells(cellsToDraw);
            }
            else
            {
                graphics.Clear(Color.White);
                //PrintCells();
            }

            //if (IsGridEnabled)
            //PrintGrid();

            pictureBoxBoard.Invoke(new Action(() => pictureBoxBoard.Image = bitmap)); // invoke - draw pictureBox in the main thread
        }

        public void DrawGrid()
        {

        }
    }
}
