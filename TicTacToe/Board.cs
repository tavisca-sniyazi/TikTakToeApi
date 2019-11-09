using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {
        public string Status { get; set; }
        public string PlayerName { get; set; }
        public string[,] BoardArray { get; set; }
    }
}
