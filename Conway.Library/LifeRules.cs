using System;

namespace Conway.Library
{
    public enum CellState
    {
        Alive,
        Dead
    }

    public class LifeRules
    {
        public static CellState GetNewState(CellState currentState, int liveNeighbours)
        {
            if (!Enum.IsDefined(typeof(CellState), currentState))
                throw new ArgumentOutOfRangeException(nameof(currentState));

            if (liveNeighbours < 0 || liveNeighbours > 8)
                throw new ArgumentOutOfRangeException(nameof(liveNeighbours));

            switch (currentState)
            {
                case CellState.Alive:
                    if (liveNeighbours < 2 || liveNeighbours > 3)
                        return CellState.Dead;
                    break;
                case CellState.Dead:
                    if (liveNeighbours == 3)
                        return CellState.Alive;
                    break;
            }
            return currentState;
        }
    }
}
