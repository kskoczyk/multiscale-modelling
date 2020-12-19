using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiscale_Modelling
{
    public class Cell
    {
        private static long CellCounter = 0;
        public long CellId { get; private set; }
        public int Type { get; set; }
        public Point Position { get; private set; } = new Point(0, 0);
        public Board Board { get; private set; }
        public int Phase { get; set; } // TODO: currently not used

        public static Dictionary<int, SolidBrush> UniqueColors = new Dictionary<int, SolidBrush>()
        {
            // reserve for empty cells and inclusions
            { Color.White.ToArgb(), new SolidBrush(Color.White) },
            { Color.Black.ToArgb(), new SolidBrush(Color.Black) }
        };

        public Cell(Point position, Board board, int phase = 0)
        {
            CellId = CellCounter;
            CellCounter++;

            Phase = phase;
            Position = position;
            Board = board;
            Color = Color.White;
        }

        public int Id { get; private set; }
        public int NewId { get; set; }
        public Color Color { get; private set; }
        public Color NewColor { get; set; }
        public Cell[] Neighbors { get; set; } = new Cell[] { null, null, null, null, null, null, null, null }; // max 8 neighbors

        public void SetId(int id)
        {
            Id = id;
            NewId = id;
        }
        public void SetColor(Color color)
        {
            Color = color;
            NewColor = color;
            if (!UniqueColors.TryGetValue(color.ToArgb(), out SolidBrush _))
                UniqueColors.Add(color.ToArgb(), new SolidBrush(color));
        }

        public void UpdateId()
        {
            Id = NewId;
            Color = NewColor;
        }

    }
}
