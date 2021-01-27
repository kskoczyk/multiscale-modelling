using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Convert;

namespace Multiscale_Modelling
{
    public partial class Form1 : Form
    {
        // TODO:
        // Handle set button in another thread (creation of large boards)
        // Handle resize when drawing
        private const int CELL_BITMAP_SIZE = 1;
        public Form1()
        {
            InitializeComponent();

            Logs.SetLogRichTextBox(this.richTextBoxLog);

            // initialize first board (1x1)
            numericUpDownX_Leave(null, null);
            numericUpDownY_Leave(null, null);

            /*
            Array a = Enum.GetValues(typeof(abc));
            IEnumerable<object> b = a.OfType<object>();
            IEnumerable<string> c = b.Select(x => x.ToString());
             */
            comboBoxBoundaryCondition.Items.AddRange(EnumToString.BoundaryCondition.Values.ToArray());
            comboBoxBoundaryCondition.SelectedItem = EnumToString.BoundaryCondition[Bc.Absorbing];

            comboBoxSimulationType.Items.AddRange(EnumToString.SimulationType.Values.ToArray());
            comboBoxSimulationType.SelectedItem = EnumToString.SimulationType[E_SimulationType.Simple];

            Logs.Log("Program start", Logs.LogLevel.Other);
        }
        public static IEnumerable<T> GetForms<T>() where T : Form // TESTING gimmick - for getting Form1 instance from other classes
        {
            foreach (Form form in Application.OpenForms)
                if (form.GetType() == typeof(T))
                    yield return (T)form;
        }

        private void ToggleSimulationControls(bool toggle)
        {
            buttonRun.Enabled = toggle;
            buttonClear.Enabled = toggle;
            buttonRandom.Enabled = toggle;
            buttonClear.Enabled = toggle;
            checkBoxDisplayGrid.Enabled = toggle; // TODO: pause when checked mid-animation or handle change mid-animation
            numericUpDownX.Enabled = toggle;
            numericUpDownY.Enabled = toggle;
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            ToggleSimulationControls(false);
            bool isSimulationFinished = boardControl1.Board.IsSimulationFinished;

            Task.Run(() =>
            {
                Logs.Log("Run task started", Logs.LogLevel.Info);
                try
                {
                    bool isAnimated = checkBoxAnimate.Checked;
                    boardControl1.Board.Probability = ToInt32(numericUpDownProbability.Value);
                    if(isSimulationFinished)
                    {
                        IEnumerable<IGrouping<int, Cell>> groupsToDraw = boardControl1.Board.GetPhaseOneGroups().ToList();

                        foreach(IGrouping<int, Cell> group in groupsToDraw)
                        {
                            boardControl1.Board.ClearGroup(group);
                            (Point minRange, Point maxRange) = boardControl1.Board.GetGroupRange(group);
                            boardControl1.Board.RollRandomCells(ToInt32(numericUpDownNucleiNumber.Value), minRange.X, minRange.Y, maxRange.X + 1, maxRange.Y + 1);
                            boardControl1.Draw();

                            boardControl1.Board.InitializeCalculations();
                            while (boardControl1.Board.GetAllCells().Where(c => c.Id == 0).FirstOrDefault() is Cell) // null = no more cells to draw
                            {
                                LinkedList<Cell> cellsToDraw = boardControl1.Board.CalculateNextGeneration(secondPhase: true);

                                if (cellsToDraw.Any())
                                {
                                    if (checkBoxAnimate.Checked && checkBoxAnimate.Checked == isAnimated)
                                    {
                                        boardControl1.Draw(cellsToDraw);
                                    }
                                    else if (checkBoxAnimate.Checked) // check whether board should be animated continously
                                    {
                                        boardControl1.Draw();
                                        isAnimated = checkBoxAnimate.Checked;
                                    }
                                    else
                                        isAnimated = checkBoxAnimate.Checked;
                                }
                            }
                        }
                        boardControl1.Draw();
                    }
                    else if (boardControl1.Board.GetAllCells().Where(c => c.Id != 0 && c.Id != -1).FirstOrDefault() is Cell) // if there are cells to grow
                    {
                        boardControl1.Board.InitializeCalculations();
                        while (boardControl1.Board.GetAllCells().Where(c => c.Id == 0).FirstOrDefault() is Cell) // null = no more cells to draw
                        {
                            //Enum.TryParse(comboBoxSimulationType.SelectedItem.ToString(), out E_SimulationType simulationType);
                            //LinkedList<Cell> cellsToDraw = boardControl1.Board.CalculateNextGeneration((E_SimulationType)Enum.Parse(typeof(E_SimulationType), comboBoxSimulationType.SelectedItem.ToString()));
                            LinkedList<Cell> cellsToDraw = boardControl1.Board.CalculateNextGeneration();

                            if (cellsToDraw.Any())
                            {
                                if (checkBoxAnimate.Checked && checkBoxAnimate.Checked == isAnimated)
                                {
                                    boardControl1.Draw(cellsToDraw);
                                }
                                else if (checkBoxAnimate.Checked) // check whether board should be animated continously
                                {
                                    boardControl1.Draw();
                                    isAnimated = checkBoxAnimate.Checked;
                                }
                                else
                                    isAnimated = checkBoxAnimate.Checked;
                            }
                        }
                        boardControl1.Draw();
                    }
                }
                finally
                {
                    buttonRun.Invoke(new Action(() =>
                    {
                        ToggleSimulationControls(true);
                    }));
                    Logs.Log("Finished calculations", Logs.LogLevel.Info);
                }
            });
        }

    private void checkBoxDisplayGrid_CheckedChanged(object sender, EventArgs e)
        {
            boardControl1.IsGridEnabled = checkBoxDisplayGrid.Checked;
        }

        private void buttonSetBoard_Click(object sender, EventArgs e)
        {
            numericUpDownX_Leave(null, null);
            numericUpDownY_Leave(null, null);
            // TODO: handle mousewheel and cursor leaving the control so this button can become redundant
        }

        private void numericUpDownX_Leave(object sender, EventArgs e)
        {
            boardControl1.CellNumberWidth = ToInt32(numericUpDownX.Value);
        }

        private void numericUpDownY_Leave(object sender, EventArgs e)
        {
            boardControl1.CellNumberHeight = ToInt32(numericUpDownY.Value);
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            ToggleSimulationControls(false);

            Task.Run(() =>
            {
                try
                {
                    boardControl1.Board.RollRandomCells(ToInt32(numericUpDownNucleiNumber.Value));
                    boardControl1.Draw();
                }
                catch (Exception ex)
                {
                    Logs.Log("RANDOM: An error has ocurred while trying to set random cells. Exception message: " + ex.Message, Logs.LogLevel.Error);
                }
                finally
                {
                    buttonRandom.Invoke(new Action(() =>
                    {
                        ToggleSimulationControls(true);
                    }));
                }
            });

        }

        private void richTextBoxLog_TextChanged(object sender, EventArgs e)
        {
            // automatically scroll to bottom when new log appears
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            richTextBoxLog.ScrollToCaret();

            try
            {
                richTextBoxLog.SaveFile("./log.rtf", RichTextBoxStreamType.RichText);
            }
            catch (Exception ex)
            {
                Logs.Log("LOGFILE: Could not create a log file. Exception message: " + ex.Message, Logs.LogLevel.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ToggleSimulationControls(false);

            Task.Run(() =>
            {
                try
                {
                    boardControl1.Board.Clear();
                    boardControl1.Draw();
                }
                finally
                {
                    buttonClear.Invoke(new Action(() =>
                    {
                        ToggleSimulationControls(true);
                    }));
                }
            });
        }

        private void comboBoxBoundaryCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBoundaryCondition.SelectedItem.ToString() == EnumToString.BoundaryCondition[Bc.Absorbing])
                boardControl1.Board.BoundaryCondition = Bc.Absorbing;
            else if (comboBoxBoundaryCondition.SelectedItem.ToString() == EnumToString.BoundaryCondition[Bc.Periodic])
                boardControl1.Board.BoundaryCondition = Bc.Periodic;
        }

        private void buttonAddInclusions_Click(object sender, EventArgs e)
        {
            bool isAnyCellEmpty = boardControl1.Board.GetAllCells().Where(c => c.Id == 0).FirstOrDefault() is Cell;
            bool isAnyCellFilled = boardControl1.Board.GetAllCells().Where(c => c.Id != 0 && c.Id != -1).FirstOrDefault() is Cell;

            if (!isAnyCellEmpty)
            {
                boardControl1.Board.AddInclusions(ToInt32(numericUpDownInclusionsNumber.Value), ToInt32(numericUpDownInclusionsRadius.Value), E_InclusionType.Border);
                boardControl1.Draw();
            }
            else if (!isAnyCellFilled)
            {
                boardControl1.Board.AddInclusions(ToInt32(numericUpDownInclusionsNumber.Value), ToInt32(numericUpDownInclusionsRadius.Value), E_InclusionType.Random);
                boardControl1.Draw();
            }
            else
            {
                Logs.Log("INCLUSION: Cannot add inclusions. The board is only partially filled.", Logs.LogLevel.Error);
            }

        }

        private void toBitmapbmpToolStripMenuItemExportBmp_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "BMP files (*.bmp)|*.bmp|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                boardControl1.Board.ToBitmap(CELL_BITMAP_SIZE).Save(saveFileDialog.FileName, ImageFormat.Bmp);
            else
                Logs.Log("EXPORT: Unable to show export dialog", Logs.LogLevel.Error);
        }

        private void toTextFiletxtToolStripMenuItemExportTxt_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    sw.Write(boardControl1.Board.ToString());
            else
                Logs.Log("EXPORT: Unable to show export dialog", Logs.LogLevel.Error);
        }

        private void toolStripMenuItemImportBmp_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "BMP files|*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                    boardControl1.LoadBoard(bitmap, CELL_BITMAP_SIZE);
                    numericUpDownY.Value = boardControl1.Board.RowCount;
                    numericUpDownX.Value = boardControl1.Board.ColumnCount;
                    boardControl1.Draw();
                }
                catch (Exception ex)
                {
                    Logs.Log("IMPORT: Unable to show import dialog. Exception message: " + ex.Message, Logs.LogLevel.Error);
                }
            }

        }

        private void fromTextFiletxtToolStripMenuItemImportTxt_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "TXT files|*.txt"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<(int Id, int Phase, int IndexX, int IndexY)> cells = new List<(int Id, int Phase, int IndexX, int IndexY)>();
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog.FileName);
                    string line;

                    sr.ReadLine(); // skip first txt line // TODO: use it to allocate resources beforehand
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(' ');
                        if (data.Length != 4)
                            continue;

                        if (!int.TryParse(data[0], out int indexX))
                            continue;
                        if (!int.TryParse(data[1], out int indexY))
                            continue;
                        if (!int.TryParse(data[2], out int phase))
                            continue;
                        if (!int.TryParse(data[3], out int id))
                            continue;

                        cells.Add((Id: id, Phase: phase, IndexX: indexX, IndexY: indexY));
                    }
                    boardControl1.LoadBoard(cells);
                    numericUpDownY.Value = boardControl1.Board.RowCount;
                    numericUpDownX.Value = boardControl1.Board.ColumnCount;
                    boardControl1.Draw();
                }
                catch (Exception ex)
                {
                    Logs.Log("IMPORT: Unable to show import dialog. Exception message: " + ex.Message, Logs.LogLevel.Error);
                }
            }

        }

        private void comboBoxSimulationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSimulationType.SelectedItem.ToString() == EnumToString.SimulationType[E_SimulationType.ShapeControl])
            {
                numericUpDownProbability.Enabled = true;
                //Enum.TryParse(comboBoxSimulationType.SelectedItem.ToString(), out SimulationType);
                boardControl1.Board.SimulationType = E_SimulationType.ShapeControl;
            }
            else if (comboBoxSimulationType.SelectedItem.ToString() == EnumToString.SimulationType[E_SimulationType.Simple])
            {
                numericUpDownProbability.Enabled = false;
                boardControl1.Board.SimulationType = E_SimulationType.Simple;
            }
        }

        private void numericUpDownProbability_Leave(object sender, EventArgs e)
        {
            boardControl1.Board.Probability = ToInt32(numericUpDownProbability.Value);
        }
    }
}
