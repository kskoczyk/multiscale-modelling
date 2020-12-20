using System;
using System.Collections.Concurrent;
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
        private const int RANDOM_ROLL_ATTEMPTS = 1000;
        private List<List<Cell>> cellList;
        private ConcurrentDictionary<long, Cell> newCells = new ConcurrentDictionary<long, Cell>();
        public INeighborhood NeighborRule { get; set; }
        private Bc _boundaryContition;
        public Bc BoundaryCondition
        {
            get => _boundaryContition;
            set
            {
                if (_boundaryContition != value)
                {
                    _boundaryContition = value;
                    SetBoundaryConditions();
                }
            }
        }

        public int RowCount => cellList.Count;
        public int ColumnCount => cellList.ElementAtOrDefault(0)?.Count ?? 0;

        public Board()
        {
            cellList = new List<List<Cell>>();
            NeighborRule = new MooreNeighborhood();
        }

        public Cell GetCell(int row, int column)
        {
            return cellList[row][column];
        }

        public IEnumerable<Cell> GetAllCells()
        {
            return cellList.SelectMany(x => x);
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

        public void Clear()
        {
            for (int i = 0; i < cellList.Count; i++)
            {
                for (int j = 0; j < cellList[i].Count; j++)
                {
                    cellList[i][j].SetId(0);
                    cellList[i][j].SetColor(Color.White);
                }
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

            SetBoundaryConditions();
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
                Logs.Log("RANDOM: Could not assign random cells. " + successfulRolls + "/" + numberOfCells + " rolled.", Logs.LogLevel.Warning);
            }
        }
        public void SetBoundaryConditions()
        {
            if (BoundaryCondition == Bc.Absorbing)
                SetBoundaryAbsorbing();
            else if (BoundaryCondition == Bc.Periodic)
                SetBoundaryPeriodic();
        }

        private void SetBoundaryAbsorbing()
        {
            /* X X X
             * 1 2 3
             * 8 c 4
             * 7 6 5
             */

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    Cell cell = GetCell(row: i, column: j);

                    // 1
                    if (NeighborRule.GetNeighborhood().ToArray()[0] == 1 && i + 1 < RowCount && j + 1 < ColumnCount)
                        cell.Neighbors[0] = cellList[i + 1][j + 1];
                    else
                        cell.Neighbors[0] = null;

                    // 2
                    if (NeighborRule.GetNeighborhood().ToArray()[1] == 1 && i + 1 < RowCount)
                        cell.Neighbors[1] = cellList[i + 1][j];
                    else
                        cell.Neighbors[1] = null;

                    // 3
                    if (NeighborRule.GetNeighborhood().ToArray()[2] == 1 && i + 1 < RowCount && j - 1 >= 0)
                        cell.Neighbors[2] = cellList[i + 1][j - 1];
                    else
                        cell.Neighbors[2] = null;

                    // 4
                    if (NeighborRule.GetNeighborhood().ToArray()[3] == 1 && j - 1 >= 0)
                        cell.Neighbors[3] = cellList[i][j - 1];
                    else
                        cell.Neighbors[3] = null;

                    // 5
                    if (NeighborRule.GetNeighborhood().ToArray()[4] == 1 && i - 1 >= 0 && j - 1 >= 0)
                        cell.Neighbors[4] = cellList[i - 1][j - 1];
                    else
                        cell.Neighbors[4] = null;

                    // 6
                    if (NeighborRule.GetNeighborhood().ToArray()[5] == 1 && i - 1 >= 0)
                        cell.Neighbors[5] = cellList[i - 1][j];
                    else
                        cell.Neighbors[5] = null;

                    // 7
                    if (NeighborRule.GetNeighborhood().ToArray()[6] == 1 && i - 1 >= 0 && j + 1 < ColumnCount)
                        cell.Neighbors[6] = cellList[i - 1][j + 1];
                    else
                        cell.Neighbors[6] = null;

                    // 8
                    if (NeighborRule.GetNeighborhood().ToArray()[7] == 1 && j + 1 < ColumnCount)
                        cell.Neighbors[7] = cellList[i][j + 1];
                    else
                        cell.Neighbors[7] = null;
                }
            }
        }

        private void SetBoundaryPeriodic()
        {
            /* O O O
             * 1 2 3
             * 8 c 4
             * 7 6 5
             */

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    Cell cell = GetCell(row: i, column: j);

                    // 1
                    if (NeighborRule.GetNeighborhood().ToArray()[0] == 1)
                    {
                        if (i + 1 < RowCount && j + 1 < ColumnCount)
                            cell.Neighbors[0] = cellList[i + 1][j + 1];
                        else if (i + 1 < RowCount && j + 1 >= ColumnCount)
                            cell.Neighbors[0] = cellList[i + 1][0];
                        else if (i + 1 >= RowCount && j + 1 < ColumnCount)
                            cell.Neighbors[0] = cellList[0][j + 1];
                        else
                            cell.Neighbors[0] = cellList[0][0];
                    }
                    else
                        cell.Neighbors[0] = null;

                    // 2
                    if (NeighborRule.GetNeighborhood().ToArray()[1] == 1)
                    {
                        if (i + 1 < RowCount)
                            cell.Neighbors[1] = cellList[i + 1][j];
                        else
                            cell.Neighbors[1] = cellList[0][j];
                    }
                    else
                        cell.Neighbors[1] = null;

                    // 3
                    if (NeighborRule.GetNeighborhood().ToArray()[2] == 1)
                    {
                        if (i + 1 < RowCount && j - 1 >= 0)
                            cell.Neighbors[2] = cellList[i + 1][j - 1];
                        else if (i + 1 < RowCount && j - 1 < 0)
                            cell.Neighbors[2] = cellList[i + 1][ColumnCount - 1];
                        else if (i + 1 >= RowCount && j - 1 >= 0)
                            cell.Neighbors[2] = cellList[0][j - 1];
                        else
                            cell.Neighbors[2] = cellList[0][ColumnCount - 1];
                    }
                    else
                        cell.Neighbors[2] = null;

                    // 4
                    if (NeighborRule.GetNeighborhood().ToArray()[3] == 1)
                    {
                        if (j - 1 >= 0)
                            cell.Neighbors[3] = cellList[i][j - 1];
                        else
                            cell.Neighbors[3] = cellList[i][ColumnCount - 1];
                    }
                    else
                        cell.Neighbors[3] = null;

                    // 5
                    if (NeighborRule.GetNeighborhood().ToArray()[4] == 1)
                    {
                        if (i - 1 >= 0 && j - 1 >= 0)
                            cell.Neighbors[4] = cellList[i - 1][j - 1];
                        else if (i - 1 >= 0 && j - 1 < 0)
                            cell.Neighbors[4] = cellList[i - 1][ColumnCount - 1];
                        else if (i - 1 < 0 && j - 1 >= 0)
                            cell.Neighbors[4] = cellList[RowCount - 1][j - 1];
                        else
                            cell.Neighbors[4] = cellList[RowCount - 1][ColumnCount - 1];
                    }
                    else
                        cell.Neighbors[4] = null;

                    // 6
                    if (NeighborRule.GetNeighborhood().ToArray()[5] == 1)
                    {
                        if (i - 1 >= 0)
                            cell.Neighbors[5] = cellList[i - 1][j];
                        else
                            cell.Neighbors[5] = cellList[RowCount - 1][j];
                    }
                    else
                        cell.Neighbors[5] = null;

                    // 7
                    if (NeighborRule.GetNeighborhood().ToArray()[6] == 1)
                    {
                        if (i - 1 >= 0 && j + 1 < ColumnCount)
                            cell.Neighbors[6] = cellList[i - 1][j + 1];
                        else if (i - 1 >= 0 && j + 1 >= ColumnCount)
                            cell.Neighbors[6] = cellList[i - 1][0];
                        else if (i - 1 < 0 && j + 1 < ColumnCount)
                            cell.Neighbors[6] = cellList[RowCount - 1][j + 1];
                        else
                            cell.Neighbors[6] = cellList[RowCount - 1][0];
                    }
                    else
                        cell.Neighbors[6] = null;

                    // 8
                    if (NeighborRule.GetNeighborhood().ToArray()[7] == 1)
                    {
                        if (j + 1 < ColumnCount)
                            cell.Neighbors[7] = cellList[i][j + 1];
                        else
                            cell.Neighbors[7] = cellList[i][0];
                    }
                    else
                        cell.Neighbors[7] = null;
                }
            }
        }
        public void InitializeCalculations()
        {
            newCells.Clear();
            for (int i = 0; i < cellList.Count; i++)
            {
                for (int j = 0; j < cellList[i].Count; j++)
                {
                    if (cellList[i][j].Id > 0)
                        TryAddNewCells(cellList[i][j].Neighbors);
                }
            }
        }

        public void TryAddNewCells(IEnumerable<Cell> cells)
        {
            foreach (Cell n in cells.Where(c => c is Cell && c.NewId == 0)) // add neighbors that can be changed
                newCells.TryAdd(n.CellId, n);
        }

        public LinkedList<Cell> CalculateNextGeneration()
        {
            ConcurrentQueue<Cell> newColored = new ConcurrentQueue<Cell>();
            Parallel.ForEach(newCells.Keys, i =>
            {
                Cell cell = newCells[i];
                Cell mostDominantCell = GetMostDominantCell(cell.Neighbors);
                cell.NewId = mostDominantCell.Id;
                cell.NewColor = mostDominantCell.Color;
                if (cell.NewId > 0)
                    newColored.Enqueue(cell);
            });

            LinkedList<Cell> listToReturn = new LinkedList<Cell>();
            while (newColored.Count > 0)
            {
                if (newColored.TryDequeue(out Cell c))
                {
                    c.UpdateId();
                    TryAddNewCells(c.Neighbors);

                    newCells.TryRemove(c.CellId, out Cell value);
                    listToReturn.AddLast(c);
                }
            }

            return listToReturn;
        }

        private Cell GetMostDominantCell(IEnumerable<Cell> cells)
        {
            IEnumerable<Cell> notNullCells = cells.Where(c => c?.Id >= 0);
            Cell cell = notNullCells.First();

            IEnumerable<IGrouping<int, Cell>> groups = notNullCells.Where(x => x.Id > 0).GroupBy(c => c.Id).OrderByDescending(x => x.Count());
            if (groups.Count() > 0)
            {
                IEnumerable<IGrouping<int, Cell>> max = groups.Where(x => x.Count() == groups.First().Count());
                cell = max.ElementAt(RandomDevice.Next(max.Count())).First();
            }

            return cell;
        }

    }
}
