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
        //private Form1 _mainWindowInstance { get; set; }
        public float CellSize { get; set; }

        public Board()
        {
            //_mainWindowInstance = form;
        }

        public void DrawBoard(PictureBox p)
        {
            Graphics g = p.CreateGraphics(); // will be drawn and garbage collected automatically after function ends


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

        public void DrawGridLines(PictureBox p)
        {
            //_mainWindowInstance.AddLog("Attempt to draw lines", Logs.LogLevel.Info);
            Graphics g = p.CreateGraphics();

            //Pen pen = new Pen(Color.Black);
            //// horizontal
            //for (int i = 0; i <= SizeY; i++)
            //{
            //    g.DrawLine(pen, 0, (float)(i * DimY), (float)(SizeX * DimX), (float)(i * DimY));
            //}

            //// vertical
            //for (int j = 0; j <= SizeX; j++)
            //{
            //    g.DrawLine(pen, (float)(j * DimX), 0, (float)(j * DimX), (float)(SizeY * DimY));
            //}
        }
    }
}
