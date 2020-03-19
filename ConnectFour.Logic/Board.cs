using System;

namespace ConnectFour.Logic
{
    public class Board
    {
        /// <summary>
        /// [Column, Row]
        /// </summary>
        private readonly byte[,] GameBoard = new byte[7, 6];

        internal int Player = 1;

        public void AddStone(byte column)
        {
            if (column > 6)
            {
                throw new ArgumentOutOfRangeException(nameof(column));
            }

            for (int row = 0; row < 6; row++)
            {
                var cell = GameBoard[column, row];

                if (cell == 0)
                {
                    GameBoard[column, row] = (byte)(Player);
                    Player = (Player + 2) % 2 + 1;
                    return;
                }
            }

            throw new InvalidOperationException("Column is full");
        }

        public int GetPreviousPlayer()
        {
            return (Player + 2) % 2 + 1;
        }

        public int GetCurrentPlayer()
        {
            return Player;
        }

        public bool PlayerHasWon()
        {
            // vertical
            for (int column = 0; column < 7; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (this.GameBoard[column, row] == this.GetPreviousPlayer() && this.GameBoard[column, row + 1] == this.GetPreviousPlayer() && this.GameBoard[column, row + 2] == this.GetPreviousPlayer() && this.GameBoard[column, row + 3] == this.GetPreviousPlayer())
                    {
                        return true;
                    }
                }
            }

            // horizontal
            for (int column = 0; column < 4; column++)
            {
                for (int row = 0; row < 6; row++)
                {
                    if (this.GameBoard[column, row] == this.GetPreviousPlayer() && this.GameBoard[column + 1, row] == this.GetPreviousPlayer() && this.GameBoard[column + 2, row] == this.GetPreviousPlayer() && this.GameBoard[column + 3, row] == this.GetPreviousPlayer())
                    {
                        return true;
                    }
                }
            }

            // left to right down / diagonal
            for (int column = 3; column < 7; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (this.GameBoard[column, row] == this.GetPreviousPlayer() && this.GameBoard[column - 1, row + 1] == this.GetPreviousPlayer() && this.GameBoard[column - 2, row + 2] == this.GetPreviousPlayer() && this.GameBoard[column - 3, row + 3] == this.GetPreviousPlayer())
                        return true;
                }
            }

            // left to right up / diagonal
            for (int column = 3; column < 7; column++)
            {
                for (int row = 3; row < 6; row++)
                {
                    if (this.GameBoard[column, row] == this.GetPreviousPlayer() && this.GameBoard[column - 1, row - 1] == this.GetPreviousPlayer() && this.GameBoard[column - 2, row - 2] == this.GetPreviousPlayer() && this.GameBoard[column - 3, row - 3] == this.GetPreviousPlayer())
                        return true;
                }
            }
            return false;
        }

        public byte[,] GetBoard()
        {
            return this.GameBoard;
        }

        public bool BoardIsFull()
        {
            for (int column = 0; column < 7; column++)
            {
                for (int row = 0; row < 6; row++)
                {
                    if (this.GameBoard[column, row] == 0)
                        return false;
                }
            }
            return true;
        }
    }
}
