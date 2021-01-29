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
        private Color selectionColor = Color.Yellow;
        public INeighborhood NeighborRule { get; set; }
        public List<IRule> ShapeControlRules = new List<IRule>(new IRule[] { 
            new FullMoore(), 
            new NearestMoore(), 
            new FurtherMoore(), 
            new ProbabilityChoice() 
        });
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
        public E_SimulationType SimulationType { get; set; }
        public E_InclusionType InclusionType { get; set; }
        public int Probability { get; set; }
        public bool IsAnyGrainSelected = false;
        public int RowCount => cellList.Count;
        public int ColumnCount => cellList.ElementAtOrDefault(0)?.Count ?? 0;
        public bool IsSimulationFinished => GetAllCells().Where(c => c.Id == 0).FirstOrDefault() is null;

        public Board()
        {
            cellList = new List<List<Cell>>();
            NeighborRule = new MooreNeighborhood();
        }
        public override string ToString() // used for exporting to a .txt file
        {
            int uniquePhases = cellList.SelectMany(x => x).Select(x => x.Phase).Distinct().Count(); // TODO: use GetAllCells()
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

            int columnCount = ColumnCount; // prevent overwrite when removing from row [0]
            for (int i = 0; i < RowCount; i++)
            {
                cellList[i].RemoveAt(columnCount - 1);
            }
        }

        public void Clear()
        {
            for (int i = 0; i < cellList.Count; i++)
            {
                for (int j = 0; j < cellList[i].Count; j++)
                {
                    //cellList[i][j].SetId(0);
                    //cellList[i][j].IsSelected = false;
                    //cellList[i][j].Phase = 0;
                    //cellList[i][j].SetColor(Color.White);
                    cellList[i][j].Clear();
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

        public void RollRandomCells(int numberOfCells, int minRangeX = 0, int minRangeY = 0, int? maxRangeX = null, int? maxRangeY = null)
        {
            int attempts = 0;
            int i = 0;

            //IEnumerable<Cell> zeroCells = cellList.SelectMany(x => x).Where(c => c.Id == 0).ToList();
            //int minX = zeroCells.Min(c => c.Position.X);
            //int maxX = zeroCells.Max(c => c.Position.X) + 1;
            //int minY = zeroCells.Min(c => c.Position.Y);
            //int maxY = zeroCells.Max(c => c.Position.Y) + 1;

            maxRangeX = maxRangeX ?? ColumnCount;
            maxRangeY = maxRangeY ?? RowCount;

            while (i < numberOfCells && attempts < RANDOM_ROLL_ATTEMPTS)
            {
                int x = RandomDevice.Next(minRangeX, maxRangeX.Value);
                int y = RandomDevice.Next(minRangeY, maxRangeY.Value);

                //int x = RandomDevice.Next(minX, maxX);
                //int y = RandomDevice.Next(minY, maxY);

                Cell cell = GetCell(row: y, column: x);
                if (cell.Id == 0)
                {
                    //cell.SetId(i);
                    cell.NewId = Cell.UniqueSeeds;
                    cell.SetColor(Color.FromArgb(RandomDevice.Next(1, 255), RandomDevice.Next(1, 255), RandomDevice.Next(1, 255)));
                    cell.UpdateId();
                    i++;
                    Cell.UniqueSeeds++;
                    attempts = 0;
                }
                attempts++;
            }

            if (i < numberOfCells)
            {
                int successfulRolls = i;
                Logs.Log($"RANDOM: Could not assign random cells. {successfulRolls}/{numberOfCells} rolled.", Logs.LogLevel.Warning);
                List<Cell> zeroCells = cellList.SelectMany(x => x).Where(c => c.Id == 0).ToList();

                if (zeroCells.Count() > 0) // failsafe in case of random failing to meet the quota
                {
                    _ = 9;
                    Logs.Log("Attempting to fill remaining cells sequentially...", Logs.LogLevel.Info);

                    //List<Cell> list = zeroCells.ToList();
                    for (int it = 0; it < zeroCells.Count() && i < numberOfCells; it++)
                    {
                        Cell cell = zeroCells[it];
                        cell.NewId = Cell.UniqueSeeds;
                        cell.SetColor(Color.FromArgb(RandomDevice.Next(1, 255), RandomDevice.Next(1, 255), RandomDevice.Next(1, 255)));
                        cell.UpdateId();
                        i++;
                        Cell.UniqueSeeds++;
                    }

                    Logs.Log($"Assigned {i - successfulRolls} more cells ({i}/{numberOfCells})", Logs.LogLevel.Info);
                }
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
        public void InitializeCalculations() // TODO: less effective in 2nd phase (adding cells on border too fast)
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

        public LinkedList<Cell> CalculateNextGeneration(bool secondPhase = false)
        {
            ConcurrentQueue<Cell> newColored = new ConcurrentQueue<Cell>();
            Parallel.ForEach(newCells.Keys, i =>
            //foreach(int i in newCells.Keys)
            {
                Cell cell = newCells[i];
                Cell mostDominantCell = null;
                Cell[] neighbors = null;

                if (!secondPhase)
                    neighbors = cell.Neighbors;
                else
                    neighbors = cell.GetNeighborsByPreviousId(cell.PreviousId);

                if (SimulationType == E_SimulationType.Simple)
                    mostDominantCell = GetMostDominantCell(neighbors);
                else
                {
                    foreach (IRule rule in ShapeControlRules)
                    {
                        mostDominantCell = rule.GetDominantCell(neighbors, Probability);

                        if (mostDominantCell is Cell)
                            break;
                    }
                }

                if (mostDominantCell is Cell)
                {
                    cell.NewId = mostDominantCell.Id;
                    cell.NewColor = mostDominantCell.Color;
                    if (cell.NewId > 0)
                        newColored.Enqueue(cell);
                }
            });

            LinkedList<Cell> listToReturn = new LinkedList<Cell>();
            while (newColored.Count > 0)
            {
                if (newColored.TryDequeue(out Cell c))
                {
                    c.UpdateId();
                    if (!secondPhase)
                        TryAddNewCells(c.Neighbors);
                    else
                        TryAddNewCells(c.GetNeighborsByPreviousId(c.PreviousId));

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
            if (groups.Any())
            {
                IEnumerable<IGrouping<int, Cell>> max = groups.Where(x => x.Count() == groups.First().Count());
                cell = max.ElementAt(RandomDevice.Next(max.Count())).First();
            }

            return cell;
        }

        public void AddInclusions(int number, int radius, E_InclusionType inclusionsType)
        {
            if (!RollRandomInclusions(number, radius, inclusionsType))
                Logs.Log("Could not set all inclusions", Logs.LogLevel.Warning);
        }

        public bool RollRandomInclusions(int number, double radius, E_InclusionType inclusionsType)
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
                else if (inclusionsType == E_InclusionType.Border
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
                int xMax = Math.Min(center.Position.X + r, ColumnCount - 1); // bug: the board shrunk affecting ColumnCount but the leftover cells weren't cleared
                // happens when a cell's position's outisde the board
                int yMin = Math.Max(center.Position.Y - r, 0);
                int yMax = Math.Min(center.Position.Y + r, RowCount - 1);

                xIndices = Enumerable.Range(xMin, xMax - xMin + 1); // TODO bug: 10x10, 30 radius 0 and set to full, then 5x5, 30 radius 0 inclusions
                yIndices = Enumerable.Range(yMin, yMax - yMin + 1);

            }
            else if (BoundaryCondition == Bc.Periodic)
            {
                int xMin = Math.Max(center.Position.X - r, 0);
                int xMax = Math.Min(center.Position.X + r, ColumnCount - 1);

                int xOverflow = Math.Min(ColumnCount - center.Position.X - r - 1, 0);
                int xLack = Math.Min(center.Position.X - r, 0);


                int yMin = Math.Max(center.Position.Y - r, 0);
                int yMax = Math.Min(center.Position.Y + r, RowCount - 1);

                int yOverflow = Math.Min(RowCount - center.Position.Y - r - 1, 0);
                int yLack = Math.Min(center.Position.Y - r, 0);


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
                    if (InclusionType == E_InclusionType.Circle && IsInRadius(center.Position.X, center.Position.Y, cellList[i][j].Position.X, cellList[i][j].Position.Y, radius))
                    {
                        cellList[i][j].Clear();
                        cellList[i][j].SetColor(Color.Black);
                        cellList[i][j].SetId(-1);
                    }
                    else if (InclusionType == E_InclusionType.Square)
                    {
                        cellList[i][j].Clear();
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
                if (Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) <= radius * radius)
                    return true;
                else if (Math.Pow(Math.Abs(x2 - x1) - ColumnCount, 2) + Math.Pow(y2 - y1, 2) <= radius * radius)
                    return true;
                else if (Math.Pow(x2 - x1, 2) + Math.Pow(Math.Abs(y2 - y1) - RowCount, 2) <= radius * radius)
                    return true;
                else if (Math.Pow(Math.Abs(x2 - x1) - ColumnCount, 2) + Math.Pow(Math.Abs(y2 - y1) - RowCount, 2) <= radius * radius)
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
            SolidBrush brush = null;

            for (int i = 0; i < cellList.Count; i++)
            {
                for (int j = 0; j < cellList[i].Count; j++)
                {
                    Cell cell = cellList[i][j];

                    if (cell.Phase > 0)
                        brush = new SolidBrush(Color.FromArgb(255 - cell.Phase, cell.Color.R, cell.Color.G, cell.Color.B)); // retain phase information in alpha channel
                    else
                        brush = new SolidBrush(cell.Color);

                    graphics.FillRectangle(brush, j * cellBmpSize, i * cellBmpSize, cellBmpSize, cellBmpSize);
                }
            }

            return bitmap;
        }

        public IEnumerable<Cell> ShiftPhase(Cell selectedCell)
        {
            if (selectedCell.Id <= 0)
                return null;

            IEnumerable<Cell> cellsToShift = GetAllCells().Where(c => c.Id == selectedCell.Id);

            Parallel.ForEach(cellsToShift, cell =>
            {
                cell.Phase = 1 - cell.Phase; // 0 - 1 toggle
            });

            return cellsToShift;
        }

        public IEnumerable<IGrouping<int, Cell>> GetPhaseOneGroups()
        {
            return GetAllCells().Where(c => c.Phase == 0 && c.Id > 0).GroupBy(c => c.Id);
        }

        public IEnumerable<IGrouping<int, Cell>> GetPhaseOneSelectedGroup() // TODO: multiple selected groups?
        {
            return GetAllCells().Where(c => c.Phase == 0 && c.IsSelected == true).GroupBy(c => c.Id);
        }

        public void ClearGroup(IGrouping<int, Cell> group)
        {

            Parallel.ForEach(group, cell =>
            {
                //cell.SetId(0);
                cell.Clear();
                cell.SetColor(selectionColor);
            });
        }

        public (Point minRange, Point maxRange) GetGroupRange(IGrouping<int, Cell> group)
        {
            int minX = group.Min(c => c.Position.X);
            int maxX = group.Max(c => c.Position.X);
            int minY = group.Min(c => c.Position.Y);
            int maxY = group.Max(c => c.Position.Y);

            return (new Point(minX, minY), new Point(maxX, maxY));
        }

        public IEnumerable<Cell> Select(int id)
        {
            DeselectAll();

            if (id <= 0)
                return null;

            IEnumerable<Cell> cellsToSelect = GetAllCells().Where(c => c.Id == id);

            foreach (Cell cell in cellsToSelect)
            {
                cell.IsSelected = true;
            }

            IsAnyGrainSelected = true;

            return cellsToSelect;
        }

        public IEnumerable<Cell> DeselectAll()
        {
            IEnumerable<Cell> cellsToDeselect = GetAllCells().Where(c => c.IsSelected == true);

            foreach (Cell cell in cellsToDeselect)
            {
                cell.IsSelected = false;
            }

            IsAnyGrainSelected = false;

            return cellsToDeselect;
        }

        public void SetBorderCells(int thickness, int? cellId = null)
        {
            if (thickness < 1)
            {
                Logs.Log("Thickness cannot be less than 1", Logs.LogLevel.Error);
                return;
            }

            // TODO: clear all when null

            Action<int, int, Cell> actionMoreThan = new Action<int, int, Cell>((direction, size, cell) =>
            {
                if (size == 0)
                    return;

                Cell c = cell.Neighbors[direction];
                if (c is Cell && ((cellId == null && cell.Id > c.Id)
                    || (cellId is int && cell.Id > c.Id && (c.Id == cellId || cell.Id == cellId))))
                {

                    if (!cell.IsOnBorder)
                        cell.IsOnBorder = true;

                    int i = 0;
                    while (i < size && c.Neighbors[(direction + 4) % 8] is Cell ce)
                    {
                        c = ce;
                        i++;
                        if (!c.IsOnBorder)
                            c.IsOnBorder = true;
                    }
                }
            });

            Action<int, int, Cell> actionLessThan = new Action<int, int, Cell>((direction, size, cell) =>
            {
                if (size == 0)
                    return;

                Cell c = cell.Neighbors[direction];
                if (c is Cell && ((cellId == null && cell.Id < c.Id)
                    || (cellId is int && cell.Id < c.Id && (c.Id == cellId || cell.Id == cellId))))
                {

                    if (!cell.IsOnBorder)
                        cell.IsOnBorder = true;

                    int i = 0;
                    while (i < size && c.Neighbors[(direction + 4) % 8] is Cell ce)
                    {
                        c = ce;
                        i++;
                        if (!c.IsOnBorder)
                            c.IsOnBorder = true;
                    }
                }
            });

            var actions = new Action<int, int, Cell>[] { actionMoreThan, actionLessThan };

            int floor = ToInt32(Math.Floor((1.0 * thickness) / 2));
            int celing = ToInt32(Math.Ceiling((1.0 * thickness) / 2));

            for (int i = 0; i < thickness; i++)
            {
                foreach (Cell cell in cellList.SelectMany(x => x))
                {
                    int x = i % 2 == 0 ? celing : floor;

                    actions[i % 2].Invoke(1, x, cell);
                    actions[i % 2].Invoke(3, x, cell);
                    actions[i % 2].Invoke(5, x, cell);
                    actions[i % 2].Invoke(7, x, cell);
                }
            }

            return;
        }

        public void ClearPhases()
        {
            IEnumerable<Cell> cellsToReset = GetAllCells().Where(c => c.Phase == 1).ToList();

            foreach (Cell cell in cellsToReset)
            {
                cell.Phase = 0;
            }
        }

        public void ClearBorders()
        {
            IEnumerable<Cell> cellsToReset = GetAllCells().Where(c => c.IsOnBorder).ToList();

            foreach (Cell cell in cellsToReset)
            {
                cell.IsOnBorder = false;
            }
        }

    }
}
