using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game 
    {
        public Board MyBoard { get; set; }
        
        public Game()
        {
            MyBoard = new Board() { PlayerName = "Player 1", Status = "Play", BoardArray = new string[3, 3] };
        }
        internal bool IsValidMove(Value value)
        {
            if (MyBoard.BoardArray[value.Xc, value.Yc] == null)
                return true;
            return false;
        }

        internal void Add(Value value)
        {
            if(MyBoard.PlayerName.Equals("Player 1"))
                MyBoard.BoardArray[value.Xc, value.Yc] = "X";
            else
                MyBoard.BoardArray[value.Xc, value.Yc] = "O";
        }

        internal bool CheckIfWon()
        {
            if (CheckRows())
                return true;
            if (CheckColumns())
                return true;
            if (CheckDiagonals())
                return true;
            return false;
        }

        private bool CheckDiagonals()
        {
            if (!String.IsNullOrEmpty(MyBoard.BoardArray[0, 0]) && !String.IsNullOrEmpty(MyBoard.BoardArray[1, 1]) && !String.IsNullOrEmpty(MyBoard.BoardArray[2, 2]))
                if (MyBoard.BoardArray[0, 0].Equals(MyBoard.BoardArray[1, 1]) && MyBoard.BoardArray[1, 1].Equals(MyBoard.BoardArray[2, 2]))
                return true;
            if (!String.IsNullOrEmpty(MyBoard.BoardArray[0, 2]) && !String.IsNullOrEmpty(MyBoard.BoardArray[1, 1]) && !String.IsNullOrEmpty(MyBoard.BoardArray[2, 0]))
                if (MyBoard.BoardArray[0, 2].Equals(MyBoard.BoardArray[1, 1]) && MyBoard.BoardArray[1, 1].Equals(MyBoard.BoardArray[2, 0]))
                return true;
            return false;
        }

        internal void ChangePlayer()
        {
            if (MyBoard.PlayerName.Equals("Player 1"))
                MyBoard.PlayerName = "Player 2";
            else
                MyBoard.PlayerName = "Player 1";
            MyBoard.Status = "Play";
        }

        private bool CheckColumns()
        {
            for (int i = 0; i < 3; i++)
            {
                if(!String.IsNullOrEmpty(MyBoard.BoardArray[0, i])&& !String.IsNullOrEmpty(MyBoard.BoardArray[1, i])&& !String.IsNullOrEmpty(MyBoard.BoardArray[2, i]))
                    if (MyBoard.BoardArray[0, i].Equals(MyBoard.BoardArray[1, i]) && MyBoard.BoardArray[1, i].Equals(MyBoard.BoardArray[2, i]))
                    return true;
            }
            return false;
        }

        private bool CheckRows()
        {
            for (int i = 0; i < 3; i++)
            {
                if (!String.IsNullOrEmpty(MyBoard.BoardArray[i,0]) && !String.IsNullOrEmpty(MyBoard.BoardArray[i,1]) && !String.IsNullOrEmpty(MyBoard.BoardArray[i,2]))
                    if (MyBoard.BoardArray[i, 0].Equals(MyBoard.BoardArray[i, 1]) && MyBoard.BoardArray[i, 1].Equals(MyBoard.BoardArray[i, 2]))
                    return true;
            }
            return false;
        }

        internal Board ShowWinner()
        {
            MyBoard.Status = "Hurrah you WON";
            return MyBoard;
        }

        internal bool CheckIfTie()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (MyBoard.BoardArray[i, j] == null)
                        return false;
                }
            }
            return true;
        }

        internal Board ShowTie()
        {
            MyBoard.Status = "Tie";
            return MyBoard;
        }
    }
}
