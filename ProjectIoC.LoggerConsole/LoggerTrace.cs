using ProjectIoC.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIoC.LoggerConsole
{
    public class LoggerDebugTrace : ILogger
    {
        private string _source;

        public LoggerDebugTrace()
        {
        }
        public LoggerDebugTrace(string source)
        {
            _source = source != null && source.Length > 12 ? source.Substring(0, 12) : source;
        }

        public void Log(string message)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0,-12}: {1}", _source, message));
        }
    }
}
