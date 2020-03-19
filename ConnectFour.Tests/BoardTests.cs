using ConnectFour.Logic;
using System;
using Xunit;

namespace ConnectFour.Tests
{
    public class BoardTests
    {
        [Fact]
        public void AddWithInvalidColumnIndex()
        {
            var b = new Board();

            Assert.Throws<ArgumentOutOfRangeException>(() => b.AddStone(7));
        }

        [Fact]
        public void StonesAreSetCorrectly()
        {
            var b = new Board();

            b.AddStone(1);
            b.AddStone(2);
            b.AddStone(2);
            b.AddStone(1);

            Assert.True(b.GetBoard()[1, 0] == 1);
            Assert.True(b.GetBoard()[2, 0] == 2);
            Assert.True(b.GetBoard()[2, 1] == 1);
            Assert.True(b.GetBoard()[1, 1] == 2);
        }

        [Fact]
        public void PlayerChangesWhenAddingStone()
        {
            var b = new Board();

            var oldPlayer = b.Player;
            b.AddStone(0);

            // Verify that player has changed
            Assert.NotEqual(oldPlayer, b.Player);
        }

        [Fact]
        public void AddingTooManyStonesToARow()
        {
            var b = new Board();

            for (var i = 0; i < 6; i++)
            {
                b.AddStone(0);
            }

            var oldPlayer = b.Player;
            Assert.Throws<InvalidOperationException>(() => b.AddStone(0));
            Assert.Equal(oldPlayer, b.Player);
        }

        [Fact]
        public void GameEndsHorizontalWin()
        {
            var b = new Board();

            b.AddStone(2);
            b.AddStone(1);
            b.AddStone(3);
            b.AddStone(1);
            b.AddStone(4);
            b.AddStone(1);
            b.AddStone(5);

            Assert.True(b.PlayerHasWon());
        }

        [Fact]
        public void GameEndsVerticalWin()
        {
            var b = new Board();

            b.AddStone(1);
            b.AddStone(2);
            b.AddStone(1);
            b.AddStone(2);
            b.AddStone(1);
            b.AddStone(2);
            b.AddStone(1);

            Assert.True(b.PlayerHasWon());
        }

        [Fact]
        public void GameEndsLowerLeftUpperRightWin()
        {
            var b = new Board();

            b.AddStone(1);
            b.AddStone(2);
            b.AddStone(2);
            b.AddStone(3);
            b.AddStone(3);
            b.AddStone(4);
            b.AddStone(3);
            b.AddStone(4);
            b.AddStone(4);
            b.AddStone(6);
            b.AddStone(4);

            Assert.True(b.PlayerHasWon());
        }

        [Fact]
        public void GameEndsUpperLeftLowerRightWin()
        {
            var b = new Board();

            b.AddStone(1);
            b.AddStone(1);
            b.AddStone(1);
            b.AddStone(1);
            b.AddStone(2);
            b.AddStone(2);
            b.AddStone(3);
            b.AddStone(2);
            b.AddStone(6);
            b.AddStone(3);
            b.AddStone(6);
            b.AddStone(4);

            Assert.True(b.PlayerHasWon());
        }

        [Fact]
        public void GameEndsBoardFull()
        {
            var b = new Board();

            b.AddStone(0);
            b.AddStone(0);
            b.AddStone(0);
            b.AddStone(0);
            b.AddStone(0);
            b.AddStone(0);

            b.AddStone(1);
            b.AddStone(1);
            b.AddStone(1);
            b.AddStone(1);
            b.AddStone(1);
            b.AddStone(1);

            b.AddStone(2);
            b.AddStone(2);
            b.AddStone(2);
            b.AddStone(2);
            b.AddStone(2);
            b.AddStone(2);

            b.AddStone(6);

            b.AddStone(3);
            b.AddStone(3);
            b.AddStone(3);
            b.AddStone(3);
            b.AddStone(3);
            b.AddStone(3);


            b.AddStone(4);
            b.AddStone(4);
            b.AddStone(4);
            b.AddStone(4);
            b.AddStone(4);
            b.AddStone(4);

            b.AddStone(5);
            b.AddStone(5);
            b.AddStone(5);
            b.AddStone(5);
            b.AddStone(5);
            b.AddStone(5);

            b.AddStone(6);
            b.AddStone(6);
            b.AddStone(6);
            b.AddStone(6);
            b.AddStone(6);

            Assert.True(b.BoardIsFull());
        }
    }
}
