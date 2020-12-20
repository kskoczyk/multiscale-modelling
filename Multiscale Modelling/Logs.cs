using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Multiscale_Modelling
{
    public static class Logs
    {
        private static RichTextBox _rtb;

        public static void SetLogRichTextBox(RichTextBox rtb)
        {
            _rtb = rtb;
        }

        public enum LogLevel
        {
            Error = 0,
            Warning = 1,
            Info = 2,
            Other = 3
        }

        public static void Log(string message, Logs.LogLevel logLevel)
        {
            Action writeLog = new Action(() =>
            {
                getPrefix(logLevel, out string prefix, out Color color);
                _rtb.AppendText((prefix, color));
                _rtb.AppendText(message + "\n");
            });

            if (_rtb.InvokeRequired) // provide thread safety
                _rtb.Invoke(writeLog);
            else
                writeLog.Invoke();
        }

        public static void getPrefix(LogLevel logLevel, out string prefix, out Color color)
        {
            prefix = string.Empty;
            color = new Color();

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

            return;
        }
    }
}
