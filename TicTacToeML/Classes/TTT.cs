using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeML.Classes
{
    class TTT
    {
        public bool checkwin(string[,] board)
        {
            for (int i = 0; i < 3; i++)
                if ((board[i, 0] == board[i, 1]) && (board[i, 0] == board[i, 2]) && (board[i, 0] != "")) // xxx
                    return true;
            for (int i = 0; i < 3; i++)
                if ((board[0, i] == board[1, i]) && (board[0, i] == board[2, i]) && (board[0, i] != "")) // x/x/x
                    return true;
            if ((board[0, 0] == board[1, 1]) && (board[0, 0] == board[2, 2]) && (board[0, 0] != ""))// x diag l>r
                return true;
            if ((board[2, 0] == board[1, 1]) && (board[2, 0] == board[0, 2]) && (board[2, 0] != ""))// x diag r>l
                return true;
            return false;
        }
    }
}
