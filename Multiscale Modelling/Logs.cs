using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiscale_Modelling
{
    public static class Logs
    {
        public enum LogLevel
        {
            Error = 0,
            Warning = 1,
            Info = 2,
            Other = 3
        }

        public static (string, Color) getPrefix(LogLevel logLevel)
        {
            string prefix = "";
            Color color = new Color();

            switch (logLevel)
            {
                case LogLevel.Error:
                    {
                        prefix = "[ERROR] " + DateTime.Now.ToString("HH:mm:ss.fff") + ": ";
                        color = Color.Red;
                        break;
                    }
                case LogLevel.Warning:
                    {
                        prefix = "[WARN] " + DateTime.Now.ToString("HH:mm:ss.fff") + ": ";
                        color = Color.DarkGoldenrod;
                        break;
                    }
                case LogLevel.Info:
                    {
                        prefix = "[INFO] " + DateTime.Now.ToString("HH:mm:ss.fff") + ": ";
                        color = Color.Blue;
                        break;
                    }
                case LogLevel.Other:
                    {
                        prefix = "[OTHER] " + DateTime.Now.ToString("HH:mm:ss.fff") + ": ";
                        color = Color.Black;
                        break;
                    }
            }

            return (prefix, color);
        }
    }
}
