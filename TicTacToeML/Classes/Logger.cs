using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeML.Classes
{
    static class Logger
    {
        public static void Log(string source, object message)
        {
            Console.WriteLine("[{0}]\t{1} : {2}",DateTime.Now,source,message.ToString());
        }
    }
}
