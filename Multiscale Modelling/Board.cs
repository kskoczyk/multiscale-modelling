using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Convert;


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
        public override string ToString() // used for exporting to a .txt file
        {
            int uniquePhases = cellList.SelectMany(x => x).Select(x => x.Phase).Distinct().Count();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{ColumnCount} {RowCount} {uniquePhases}\n");
            foreach (List<Cell> row in cellList)
                foreach (Cell cell in row)
                    stringBuilder.Append($"{cell.Position.X} {cell.Position.Y} {cell.Phase} {cell.Id}\n");
            return stringBuilder.ToString();
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

        public Cell GetMostDominantCell(IEnumerable<Cell> cells)
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

        public void AddInclusions(int number, int radius, InclusionType inclusionsType)
        {
            if (!RollRandomInclusions(number, radius, inclusionsType))
                Logs.Log("Could not set all inclusions", Logs.LogLevel.Warning);
        }

        public bool RollRandomInclusions(int number, double radius, InclusionType inclusionsType)
        {
            int successfulInclusions = 0;
            int attempts = 0;
            while (successfulInclusions < number)
            {
                if (attempts > RANDOM_ROLL_ATTEMPTS)
                    return false;

                bool isFailed = false;
                int rowIndex = RandomDevice.Next(RowCount);
                int columnIndex = RandomDevice.Next(ColumnCount);

                if (cellList[rowIndex][columnIndex].Id == -1)
                {
                    isFailed = true;
                    attempts++;
                    continue;
                }
                // additionally check if cell is on nucleation border if needed
                else if (inclusionsType == InclusionType.Border
                    && cellList[rowIndex][columnIndex].Neighbors.Where(c => c is Cell && c?.Id != -1 && c?.Id != 0).Select(c => c.Id).Distinct().Count() < 2)
                {
                    isFailed = true; // not on border (only 1 type of neighbor - self)
                    attempts++;
                    continue;
                }

                // prevent inclusion overlapping
                GetIndicesInsideCircle(cellList[rowIndex][columnIndex], radius, out IEnumerable<int> xIndices, out IEnumerable<int> yIndices);
                foreach (int i in yIndices)
                {
                    foreach (int j in xIndices)
                    {
                        if (cellList[i][j].Id == -1)
                        {
                            isFailed = true;
                            attempts++;
                        }
                    }
                }

                if (!isFailed)
                {
                    SetInclusion(cellList[rowIndex][columnIndex], radius);
                    attempts = 0;
                    successfulInclusions++;
                }
            }

            return true;
        }

        public void GetIndicesInsideCircle(Cell center, double radius, out IEnumerable<int> xIndices, out IEnumerable<int> yIndices)
        {
            int r = ToInt32(Math.Ceiling(radius));
            xIndices = new List<int>();
            yIndices = new List<int>();

            if (BoundaryCondition == Bc.Absorbing)
            {
                int xMin = Math.Max(center.Position.X - r, 0);
                int xMax = Math.Min(center.Position.X + r, ColumnCount - 1);

                int yMin = Math.Max(center.Position.Y - r, 0);
                int yMax = Math.Min(center.Position.Y + r, RowCount - 1);

                xIndices = Enumerable.Range(xMin, xMax - xMin + 1);
                yIndices = Enumerable.Range(yMin, yMax - yMin + 1);

            }
            else if (BoundaryCondition == Bc.Periodic)
            {
                int xMin = Math.Max(center.Position.X - r, 0);
                int xMax = Math.Min(center.Position.X + r, ColumnCount - 1);

                int xOverflow = Math.Min(ColumnCount - center.Position.X - r - 1, 0);       // sign "-" if found
                int xLack = Math.Min(center.Position.X - r, 0);                              // sign "-" if found


                int yMin = Math.Max(center.Position.Y - r, 0);
                int yMax = Math.Min(center.Position.Y + r, RowCount - 1);

                int yOverflow = Math.Min(RowCount - center.Position.Y - r - 1, 0);          // sign "-" if found
                int yLack = Math.Min(center.Position.Y - r, 0);                              // sign "-" if found


                xIndices = Enumerable.Range(xMin, xMax - xMin + 1).Concat(Enumerable.Range(0, Math.Abs(xOverflow))).Concat(Enumerable.Range(ColumnCount - Math.Abs(xLack), Math.Abs(xLack)));
                yIndices = Enumerable.Range(yMin, yMax - yMin + 1).Concat(Enumerable.Range(0, Math.Abs(yOverflow))).Concat(Enumerable.Range(RowCount - Math.Abs(yLack), Math.Abs(yLack)));
            }
        }

        public void SetInclusion(Cell center, double radius)
        {
            GetIndicesInsideCircle(center, radius, out IEnumerable<int> xIndices, out IEnumerable<int> yIndices);

            Parallel.ForEach(yIndices, i =>
            {
                Parallel.ForEach(xIndices, j =>
                {
                    if (IsInRadius(center.Position.X, center.Position.Y, cellList[i][j].Position.X, cellList[i][j].Position.Y, radius))
                    {
                        cellList[i][j].SetColor(Color.Black);
                        cellList[i][j].SetId(-1);
                    }
                });
            });
        }

        public bool IsInRadius(double x1, double y1, double x2, double y2, double radius)
        {
            if (BoundaryCondition == Bc.Absorbing)
                return Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) <= radius * radius;
            else if (BoundaryCondition == Bc.Periodic)
            {
                if (Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) <= radius * radius)                                     // Absorbing
                    return true;
                else if (Math.Pow(Math.Abs(x2 - x1) - ColumnCount, 2) + Math.Pow(y2 - y1, 2) <= radius * radius)       // <--- / --->
                    return true;
                else if (Math.Pow(x2 - x1, 2) + Math.Pow(Math.Abs(y2 - y1) - RowCount, 2) <= radius * radius)          // ^ / v
                    return true;
                else if (Math.Pow(Math.Abs(x2 - x1) - ColumnCount, 2) + Math.Pow(Math.Abs(y2 - y1) - RowCount, 2) <= radius * radius) // <--- / ---> & ^ / v
                    return true;
                else
                    return false;
            }
            else
                throw new Exception();
        }
        public Bitmap ToBitmap(int cellBmpSize)
        {
            Bitmap bitmap = new Bitmap(ColumnCount * cellBmpSize, RowCount * cellBmpSize);
            Graphics graphics = Graphics.FromImage(bitmap);

            for (int i = 0; i < cellList.Count; i++)
                for (int j = 0; j < cellList[i].Count; j++)
                    graphics.FillRectangle(new SolidBrush(cellList[i][j].Color), j * cellBmpSize, i * cellBmpSize, cellBmpSize, cellBmpSize);

            // TODO: add metadata
            return bitmap;
        }
    }
}
