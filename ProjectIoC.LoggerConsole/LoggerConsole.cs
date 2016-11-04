using ProjectIoC.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIoC.LoggerConsole
{
    public class LoggerConsole : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
