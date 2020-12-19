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
        public Form1()
        {
            InitializeComponent();

            boardControl1.Log = AddLog;
            Logs.SetLogRichTextBox(this.richTextBoxLog);

            // initialize first board (1x1)
            numericUpDownX_Leave(null, null);
            numericUpDownY_Leave(null, null);

            Logs.Log("Program start", Logs.LogLevel.Other);
        }
        public static IEnumerable<T> GetForms<T>() where T : Form // gimmick - for getting Form1 instance from other classes
        {
            foreach (Form form in Application.OpenForms)
                if (form.GetType() == typeof(T))
                    yield return (T)form;
        }

        public void AddLog(string message, Logs.LogLevel logLevel)
        {
            richTextBoxLog.AppendText(Logs.getPrefix(logLevel));
            richTextBoxLog.AppendText(message + "\n");
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            AddLog("Run clicked", Logs.LogLevel.Info);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: import
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: export
        }

        private void checkBoxDisplayGrid_CheckedChanged(object sender, EventArgs e)
        {
            boardControl1.IsGridEnabled = checkBoxDisplayGrid.Checked;

        }

        private void buttonSetBoard_Click(object sender, EventArgs e)
        {
            int xSize = (int)numericUpDownX.Value;
            int ySize = (int)numericUpDownY.Value;
            AddLog("Setting the board to X: " + xSize.ToString() + ", Y: " + ySize.ToString(), Logs.LogLevel.Info);

            //clear
            //add cells
            //draw grid
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
            buttonRandom.Enabled = false;

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
                        buttonRandom.Enabled = true;
                    }));
                }
            });

        }

        private void richTextBoxLog_TextChanged(object sender, EventArgs e)
        {
            // automatically scroll to bottom when new log appears
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            richTextBoxLog.ScrollToCaret();

            // TODO: save logs to a file
        }
    }
}
