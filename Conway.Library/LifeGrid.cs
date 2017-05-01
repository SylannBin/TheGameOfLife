using System;
using System.Collections.Generic;

namespace Conway.Library
{
    public class LifeGrid
    {
        #region Members

        /// <summary>
        /// Simplified mechanic for the moment.
        /// Gets the next state after updating state with <see cref="UpdateState"/>.
        /// </summary>
        public CellState[,] NextState;

        /// <summary>
        /// Current state of the game (i.e. the Grid).
        /// Indicates the <see cref="CellState"/> of each <see cref="Cell"/>.
        /// </summary>
        public CellState[,] CurrentState;

        #endregion

        #region Public Properties

        /// <summary>
        /// The number of <see cref="Cell"/>s in a column of the <see cref="LifeGrid"/>.
        /// </summary>
        public int GridHeight { get; }

        /// <summary>
        /// The number of <see cref="Cell"/>s in a row of the <see cref="LifeGrid"/>.
        /// </summary>
        public int GridWidth { get; }

        #endregion
        
        #region Constructor

        /// <summary>
        /// Default Constructor.
        /// Creates a grid which dimesnsions are <see cref="GridHeight"/> and <see cref="GridWidth"/>.
        /// Cells are Dead per default.
        /// </summary>
        public LifeGrid(int GridHeight, int GridWidth)
        {
            // Dimensions
            this.GridWidth = GridWidth;
            this.GridHeight = GridHeight;
            // Content
            CurrentState = new CellState[GridHeight, GridWidth];
            NextState = new CellState[GridHeight, GridWidth];
            // Default State is CellState.Dead
            for (int row = 0; row < GridHeight; row++)
                for (int col = 0; col < GridWidth; col++)
                {
                    CurrentState[row, col] = CellState.Dead;
                    NextState[row, col] = CellState.Dead;
                }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Updates state of each cell on the game.
        /// </summary>
        public void UpdateState()
        {
            // calculate results of life for each Cell of the LifeGrid (nextState)
            for (int row = 0; row < GridHeight; row++)
                for (int col = 0; col < GridWidth; col++)
                {
                    var liveNeighbours = GetLiveNeighbours(row, col);
                    NextState[row, col] = LifeRules.GetNewState(CurrentState[row, col], liveNeighbours);
                }
            // Updates CurrentState
            CurrentState = NextState;
            // Reset nextState
            NextState = new CellState[GridHeight, GridWidth];
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get the number of Alive neighbours to the reference cell.
        /// Exclude both reference cell and grid's outside positions.
        /// </summary>
        /// <param name="posY">ref cell row position</param>
        /// <param name="posX">ref cell col position</param>
        /// <returns></returns>
        private int GetLiveNeighbours(int posY, int posX)
        {
            int liveNeighbours = 0;
            // for each cell in 3x3 square (direct neighbours)
            for (int row = -1; row <= 1; row++)
                for (int col = -1; col <= 1; col++)
                {
                    // exclude middle position (ref cell position)
                    if (row == 0 && col == 0)
                        continue;
                    // define neighbor position
                    int neighborX = posX + col;
                    int neighborY = posY + row;
                    // exclude positions outside of LifeGrid
                    if (neighborX < 0 || neighborX >= GridWidth
                    || neighborY < 0 || neighborY >= GridHeight)
                        continue;
                    // if neighbor is alive increment liveNeibours
                    if (CurrentState[neighborY, neighborX] == CellState.Alive)
                        liveNeighbours++;
                }
            return liveNeighbours;
        }

        #endregion
    }
}
