using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiscale_Modelling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            boardControl1.Log = AddLog;
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
            //Board.DrawBoard(pictureBoxBoard);
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
            //boardControl1.
        }
    }
}
