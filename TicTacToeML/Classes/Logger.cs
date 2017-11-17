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

        public static void SetForColGreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }      
       
        public static void SetBackBlue()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
        }

        public static void SetBackRed()
        {
            Console.BackgroundColor = ConsoleColor.Red;
        }

        public static void Reset()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ConsoleUpdate(string win, string lose, string draw, int games, int knowledge)
        {
            Console.Title = String.Format("win={0} ;lose={1} ;draw={2};\tgames={3};Knowledge={4}",win,lose,draw,games,knowledge);
        }
    }
}
