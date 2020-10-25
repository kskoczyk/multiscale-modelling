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
        public Board Board { get; private set; } = new Board();
        public Form1()
        {
            InitializeComponent();
        }
        public static IEnumerable<T> GetForms<T>() where T : Form // for getting Form1 instance from other classes
        {
            foreach (Form form in Application.OpenForms)
                if (form.GetType() == typeof(T))
                    yield return (T)form;
        }

        public void addLog(string message, Logs.LogLevel logLevel)
        {
            richTextBoxLog.AppendText(Logs.getPrefix(logLevel));
            richTextBoxLog.AppendText(message + "\n");
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            addLog("Run clicked", Logs.LogLevel.Info);
            addLog("Test warn", Logs.LogLevel.Warning);
            addLog("Test other", Logs.LogLevel.Other);
            Board.DrawBoard(pictureBox1);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
