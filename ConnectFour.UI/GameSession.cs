using ConnectFour.Logic;
using System;

namespace ConnectFour.UI
{
    public class GameSession
    {
        Board board = new Board();
        public void Start()
        {
            while (!board.PlayerHasWon() || board.BoardIsFull())
            {
                try
                {
                    byte column = this.GetColumnInput();
                    this.board.AddStone(column);
                    this.printBoard();
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("Gratulation! Player " + board.GetPreviousPlayer() + " wins");
        }

        private byte GetColumnInput()
        {
            byte column;
            string input = "";
            while (!Byte.TryParse(input, out column))
            {
                Console.Write("Player " + board.GetCurrentPlayer() + " please enter the column: ");
                input = Console.ReadLine();
            }
            return column;
        }

        private void printBoard()
        {
            for (int row = 5; row >= 0; row--)
            {
                for (int column = 0; column < 7; column++)
                {
                    if (this.board.GetBoard()[column, row] != 0)
                    {
                        Console.Write("#" + this.board.GetBoard()[column, row] + "#\t");
                    }
                    else
                    {
                        Console.Write(this.board.GetBoard()[column, row] + "\t");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");
        }
    }
}
