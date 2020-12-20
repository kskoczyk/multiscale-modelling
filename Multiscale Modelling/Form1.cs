using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            Task.Run(() =>
            {
                Logs.Log("Run task started", Logs.LogLevel.Info);
                try
                {
                    bool isAnimated = checkBoxAnimate.Checked;
                    if (boardControl1.Board.GetAllCells().Where(c => c.Id != 0 && c.Id != -1).FirstOrDefault() is Cell) // get only mutable cells
                    {
                        boardControl1.Board.InitializeCalculations();
                        while (boardControl1.Board.GetAllCells().Where(c => c.Id == 0).FirstOrDefault() is Cell)
                        {
                            LinkedList<Cell> cellsToDraw = boardControl1.Board.CalculateNextGeneration();
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
                boardControl1.Board.AddInclusions(ToInt32(numericUpDownInclusionsNumber.Value), ToInt32(numericUpDownInclusionsRadius.Value), InclusionType.Border);
                boardControl1.Draw();
            }
            else if (!isAnyCellFilled)
            {
                boardControl1.Board.AddInclusions(ToInt32(numericUpDownInclusionsNumber.Value), ToInt32(numericUpDownInclusionsRadius.Value), InclusionType.Random);
                boardControl1.Draw();
            }
            else
            {
                Logs.Log("INCLUSION: Cannot add inclusions. The board is only partially filled.", Logs.LogLevel.Error);
            }

        }
    }
}
