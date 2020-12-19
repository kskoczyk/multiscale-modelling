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
        private List<List<Cell>> cellList;
        private const int RANDOM_ROLL_ATTEMPTS = 1000;
        //private readonly Dictionary<long, Cell> PotentialGrains = new Dictionary<long, Cell>();

        public int RowCount => cellList.Count;
        public int ColumnCount => cellList.ElementAtOrDefault(0)?.Count ?? 0;

        public Board()
        {
            cellList = new List<List<Cell>>();
        }

        public Cell GetCell(int row, int column)
        {
            return cellList[row][column];
        }

        public void AddRow()
        {
            List<Cell> row = new List<Cell>();
            for (int i = 0; i < ColumnCount; i++)
            {
                row.Add(new Cell(position: new Point(i, RowCount), board: this));
            }
            cellList.Add(row);
        }

        public void AddColumn()
        {
            int columnCount = ColumnCount;
            for (int i = 0; i < RowCount; i++)
            {
                cellList[i].Add(new Cell(position: new Point(columnCount, i), board: this));
            }
        }

        public void RemoveLastRow()
        {
            if (RowCount == 1)
                throw new Exception("Last row"); // TODO: use logs

            cellList.RemoveAt(RowCount - 1);
        }
        public void RemoveLastColumn()
        {
            if (ColumnCount == 1)
                throw new Exception("Last column"); // TODO: use logs

            int columnCount = ColumnCount;
            for (int i = 0; i < RowCount; i++)
            {
                cellList[i].RemoveAt(ColumnCount - 1);
            }
        }

        public void Resize(int newSizeX, int newSizeY)
        {
            if (newSizeX < 1 || newSizeY < 1)
                return;

            while (RowCount > newSizeY)
                RemoveLastRow();
            while (RowCount < newSizeY)
                AddRow();

            while (ColumnCount > newSizeX)
                RemoveLastColumn();
            while (ColumnCount < newSizeX)
                AddColumn();

            //SetBoundaryCondition();
        }

        public void RollRandomCells(int numberOfCells)
        {
            int attempts = 0;
            int i = 1;
            while (i <= numberOfCells && attempts < RANDOM_ROLL_ATTEMPTS)
            {
                int x = RandomDevice.Next(ColumnCount);
                int y = RandomDevice.Next(RowCount);

                Cell cell = GetCell(row: y, column: x);
                if (cell.Id == 0)
                {
                    cell.SetId(i);
                    cell.SetColor(Color.FromArgb(RandomDevice.Next(1, 255), RandomDevice.Next(1, 255), RandomDevice.Next(1, 255)));
                    i++;
                    attempts = 0;
                }
                attempts++;
            }

            if (i < numberOfCells + 1)
            {
                int successfulRolls = i - 1;
                Logs.Log("RANDOM: Could not assign the random cells. " + successfulRolls + "/" + numberOfCells + " rolled.", Logs.LogLevel.Warning);
            }
        }

    }
}
