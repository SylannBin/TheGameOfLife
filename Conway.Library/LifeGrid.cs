using System;
using System.Collections.Generic;

namespace Conway.Library
{
    public class LifeGrid
    {
        public CellState[,] CurrentState;
        private CellState[,] nextState;

        public int GridHeight { get; set; }
        public int GridWidth { get; set; }


        /// <summary>
        /// Default Constructor
        /// </summary>
        public LifeGrid(int GridHeight, int GridWidth)
        {
            this.GridWidth = GridWidth;
            this.GridHeight = GridHeight;
            CurrentState = new CellState[GridHeight, GridWidth];
            nextState = new CellState[GridHeight, GridWidth];

            for (int row = 0; row < GridHeight; row++)
                for (int col = 0; col < GridWidth; col++)
                {
                    CurrentState[row, col] = CellState.Dead;
                }
        }

        /// <summary>
        /// Updates state of each cell on the game.
        /// </summary>
        public void UpdateState()
        {
            for (int row = 0; row < GridHeight; row++)
                for (int col = 0; col < GridWidth; col++)
                {
                    var liveNeighbours = GetLiveNeighbours(row, col);
                    nextState[row, col] = LifeRules.GetNewState(CurrentState[row, col], liveNeighbours);
                }

            CurrentState = nextState;
            nextState = new CellState[GridHeight, GridWidth];
        }

        /// <summary>
        /// Get the number of Alive neighbour to the reference cell.
        /// Exclude both reference cell and grid's outside positions.
        /// </summary>
        /// <param name="posX">ref cell row position</param>
        /// <param name="posY">ref cell col position</param>
        /// <returns></returns>
        private int GetLiveNeighbours(int posX, int posY)
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
                    int neighborX = posX + row;
                    int neighborY = posY + col;
                    // exclude positions outside of LifeGrid
                    if (neighborX < 0 || neighborX >= GridWidth
                    ||  neighborY < 0 || neighborY >= GridHeight)
                        continue;
                    // if neighbor is alive increment liveNeibours
                    if (CurrentState[neighborX, neighborY] == CellState.Alive)
                        liveNeighbours++;
                }
            return liveNeighbours;
        }

        public enum HorizPos
        {
            Left = -1,
            same = 0,
            Right = 1
        }

        public enum VertiPos
        {
            Up = -1,
            same = 0,
            Down = 1
        }

        public class Cell
        {
            int PositionX;
            int PositionY;
        
            // -1,-1  0,-1  1,-1
            // -1, 0        1, 0
            // -1, 1  0, 1  1, 1
        }
    }
}
