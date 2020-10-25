using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiscale_Modelling
{
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, (string text, Color color) parameters)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = parameters.color;
            box.AppendText(parameters.text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
