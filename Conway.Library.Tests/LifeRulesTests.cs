using NUnit.Framework;
using System;

namespace Conway.Library.Tests
{
    // Any live cell with fewer than two live neighbours dies.
    // Any live cell with two or three live neighbours lives.
    // Any live cell with more than three live neighbours dies.
    // Any dead cell with exactly three live neighbours becomes a live cell.

    [TestFixture]
    public class LifeRulesTests
    {
        [Test]
        public void LiveCell_FewerThan2LiveNeighbours_Dies([Values(0, 1)] int liveNeighbours)
        {
            // Arrange
            var currentState = CellState.Alive;
            // Act
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbours);
            // Assert
            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void LiveCell_2Or3LiveNeighbours_Lives([Values(2, 3)] int liveNeighbours)
        {
            // Arrange
            var currentState = CellState.Alive;
            // Act
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbours);
            // Assert
            Assert.AreEqual(CellState.Alive, newState);
        }

        [Test]
        public void LiveCell_MoreThan3LiveNeighbours_Dies([Range(4, 8)] int liveNeighbours)
        {
            // Arrange
            var currentState = CellState.Alive;
            // Act
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbours);
            // Assert
            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void DeadCell_Exactly3LiveNeighbours_Lives()
        {
            // Arrange
            int liveNeighbours = 3;
            var currentState = CellState.Dead;
            // Act
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbours);
            // Assert
            Assert.AreEqual(CellState.Alive, newState);
        }

        [Test]
        public void DeadCell_FewerThan3LiveNeighbours_StaysDead([Range(0, 2)] int liveNeighbours)
        {
            // Arrange
            var currentState = CellState.Dead;
            // Act
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbours);
            // Assert
            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void DeadCell_MoreThan3LiveNeighbours_StaysDead([Range(4, 8)] int liveNeighbours)
        {
            // Arrange
            var currentState = CellState.Dead;
            // Act
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbours);
            // Assert
            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void CurrentState_UndefinedValue_ThrowsArgumentException([Values(-1, 2)] CellState currentState)
        {
            // Arrange
            int liveNeighbours = 0;
            // Act
            var e = Assert.Throws<ArgumentOutOfRangeException>(() => LifeRules.GetNewState(currentState, liveNeighbours));
            // Assert
            Assert.AreEqual(e.ParamName, nameof(currentState));
        }

        [Test]
        public void LiveNeighbours_InvalidValues_ThrowsArgumentException([Values(-1, 9)] int liveNeighbours)
        {
            // Arrange
            CellState currentState = CellState.Alive;
            // Assert
            Assert.Throws(Is.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo(nameof(liveNeighbours))
            // Act
                , () => LifeRules.GetNewState(currentState, liveNeighbours));
        }
    }
}
