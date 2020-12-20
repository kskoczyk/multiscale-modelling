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

    public static class RandomDevice
    {
        private static readonly object randomLock = new object(); // provide multithread safety
        private readonly static Random Random = new Random();

        public static int Next()
        {
            lock (randomLock)
            {
                return Random.Next();
            }
        }

        public static int Next(int maxValue)
        {
            lock (randomLock)
            {
                return Random.Next(maxValue);
            }
        }

        public static int Next(int minValue, int maxValue)
        {
            lock (randomLock)
            {
                return Random.Next(minValue, maxValue);
            }
        }
    }

    public enum Bc
    {
        Absorbing,
        Periodic
    }

    public enum InclusionType
    {
        Random, // on empty board
        Border
    }

    public static class EnumToString
    {
        public static Dictionary<Bc, string> BoundaryCondition = new Dictionary<Bc, string>()
        {
            { Bc.Absorbing, "Absorbing" },
            { Bc.Periodic, "Periodic" }
        };
    }

}
