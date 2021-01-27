using System;
using System.Collections.Concurrent;
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
        public static int UniqueSeeds = 1; // start seeding from 1
        public long CellId { get; private set; }
        public int Type { get; set; }
        public Point Position { get; private set; } = new Point(0, 0);
        public Board Board { get; private set; }
        public int Phase { get; set; }

        public static ConcurrentDictionary<int, SolidBrush> UniqueColors = new ConcurrentDictionary<int, SolidBrush>(
            new Dictionary<int, SolidBrush>
            { 
                // reserve for special uses
                { Color.White.ToArgb(), new SolidBrush(Color.White) },
                { Color.Black.ToArgb(), new SolidBrush(Color.Black) },
                { Color.DeepPink.ToArgb(), new SolidBrush(Color.DeepPink) },
                { Color.Aqua.ToArgb(), new SolidBrush(Color.Aqua) } // TODO: they might be used in BoardControl instead
            });

        public Cell(Point position, Board board, int phase = 0)
        {
            CellId = CellCounter;
            CellCounter++;

            Phase = phase;
            Position = position;
            Board = board;
            Color = Color.White;
        }

        public int Id { get; private set; } // seed type
        public int NewId { get; set; }
        public int PreviousId { get; set; }
        public Color Color { get; private set; }
        public Color NewColor { get; set; }
        public Cell[] Neighbors { get; set; } = new Cell[] { null, null, null, null, null, null, null, null }; // max 8 neighbors

        public void SetId(int id)
        {
            PreviousId = Id;
            Id = id;
            NewId = id;
        }
        //private object _lock = new object();
        public void SetColor(Color color)
        {
            Color = color;
            NewColor = color;
            //lock (_lock)
            //{
                //if (!UniqueColors.TryGetValue(color.ToArgb(), out SolidBrush _))
                    UniqueColors.TryAdd(color.ToArgb(), new SolidBrush(color)); 
            //}
        }

        public void UpdateId()
        {
            Id = NewId;
            Color = NewColor;
        }

        public Cell[] GetNeighborsByPreviousId(int id) // used for setting borders in 2nd phase
        {
            Cell[] neighborsById = new Cell[8];

            for (int i = 0; i < Neighbors.Count(); i++)
            {
                if (Neighbors[i]?.PreviousId == id)
                    neighborsById[i] = Neighbors[i];
            }

            return neighborsById;
        }
    }
}
