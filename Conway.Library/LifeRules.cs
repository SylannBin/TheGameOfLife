using System;

namespace Conway.Library
{
    /// <summary>
    /// Possible States for a <see cref="Cell"/> in the game.
    /// </summary>
    public enum CellState
    {
        Alive,
        Dead
    }

    /// <summary>
    /// REVIEW: HorizPos enum
    /// </summary>
    public enum HorizPos
    {
        Left = -1,
        same = 0,
        Right = 1
    }

    /// <summary>
    /// REVIEW: VertiPos enum
    /// </summary>
    public enum VertiPos
    {
        Up = -1,
        same = 0,
        Down = 1
    }

    /// <summary>
    /// Possible positions for Neighbours to a reference cell.
    /// </summary>
    public enum Neighbours
    {
        // -1,-1
        TopLeft,
        //  0,-1
        Top,
        //  1,-1
        TopRight,
        // -1, 0  
        Left,
        //  1, 0
        Right,
        // -1, 1
        BottomLeft,
        //  0, 1
        Bottom,
        //  1, 1
        BottomRight
    }

    /// <summary>
    /// Rules of life. All the magic is happening here!
    /// </summary>
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
