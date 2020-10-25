using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiscale_Modelling
{
    public class Board
    {
        public List<Cell> CellList { get; set; } = new List<Cell>();

        public void DrawBoard(PictureBox p)
        {
            Graphics g = p.CreateGraphics(); // will be drawn and garbage collected automatically after function ends

            if (CellList == null || CellList.Count == 0)
            {
                Form1.GetForms<Form1>().First().addLog("The board is empty or not initialized!", Logs.LogLevel.Error); // Form1 instance
                return;
            }

            //for (int i = 0; i < cells.Count; i++)
            //{
            //    for (int j = 0; j < cells[i].Count; j++)
            //    {
            //        Cell cell = cells[i][j];
            //        g.FillRectangle(new SolidBrush(cell.ParentSeed.SeedColor), (float)(j * DimX), (float)(i * DimY), (float)DimX, (float)DimY);
            //        if (Rules.DrawWeights)
            //        {
            //            int thickness = 3;
            //            g.FillRectangle(new SolidBrush(Color.Red), (float)((cell.Weight.X + j) * DimX - thickness / 2), (float)((cell.Weight.Y + i) * DimY - thickness / 2), (float)thickness, (float)thickness);
            //        }
            //    }
            //}
        }
    }
}
