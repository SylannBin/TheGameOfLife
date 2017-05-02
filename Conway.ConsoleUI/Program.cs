using Conway.Library;
using System;
using System.Text;

namespace Conway.ConsoleUI
{
    class Program
    {
        #region Private Members

        /// <summary>
        /// The Grid containing all cells of the Universe!!!
        /// </summary>
        private static LifeGrid MyGrid;

        #endregion

        #region Main

        /// <summary>
        /// Main entry point.
        /// Executes the program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Prepare game
            InitGame();

            // Show grid for the first time
            ShowGrid(MyGrid.CurrentState);

            // Start updating on player demand
            while (Console.ReadLine() != "q")
            {
                MyGrid.UpdateState();
                ShowGrid(MyGrid.CurrentState);
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Initializes the game's state
        /// </summary>
        static void InitGame()
        {
            // Generate the grid
            MyGrid = new LifeGrid(45, 80);

            // Set the Alive cells (Cells are Dead by default)
            //MyGrid.GenerateLife();
            InitGosperglidergun();
            //MyGrid.CurrentState[1, 2] = CellState.Alive;
            //MyGrid.CurrentState[2, 2] = CellState.Alive;
            //MyGrid.CurrentState[3, 2] = CellState.Alive;
        }

        /// <summary>
        /// Draws A Gosper Glider Gun on the grid
        /// </summary>
        static void InitGosperglidergun()
        {
            // first square
            MyGrid.CurrentState[15, 11] = CellState.Alive;
            MyGrid.CurrentState[16, 11] = CellState.Alive;
            MyGrid.CurrentState[15, 12] = CellState.Alive;
            MyGrid.CurrentState[16, 12] = CellState.Alive;
            // Circle
            MyGrid.CurrentState[15, 21] = CellState.Alive;
            MyGrid.CurrentState[16, 21] = CellState.Alive;
            MyGrid.CurrentState[17, 21] = CellState.Alive;
            MyGrid.CurrentState[14, 22] = CellState.Alive;
            MyGrid.CurrentState[18, 22] = CellState.Alive;
            MyGrid.CurrentState[13, 23] = CellState.Alive;
            MyGrid.CurrentState[19, 23] = CellState.Alive;
            MyGrid.CurrentState[13, 24] = CellState.Alive;
            MyGrid.CurrentState[19, 24] = CellState.Alive;
            MyGrid.CurrentState[16, 25] = CellState.Alive;
            MyGrid.CurrentState[14, 26] = CellState.Alive;
            MyGrid.CurrentState[18, 26] = CellState.Alive;
            MyGrid.CurrentState[15, 27] = CellState.Alive;
            MyGrid.CurrentState[16, 27] = CellState.Alive;
            MyGrid.CurrentState[17, 27] = CellState.Alive;
            MyGrid.CurrentState[16, 28] = CellState.Alive;
            // Triangle
            MyGrid.CurrentState[13, 31] = CellState.Alive;
            MyGrid.CurrentState[14, 31] = CellState.Alive;
            MyGrid.CurrentState[15, 31] = CellState.Alive;
            MyGrid.CurrentState[13, 32] = CellState.Alive;
            MyGrid.CurrentState[14, 32] = CellState.Alive;
            MyGrid.CurrentState[15, 32] = CellState.Alive;
            MyGrid.CurrentState[12, 33] = CellState.Alive;
            MyGrid.CurrentState[16, 33] = CellState.Alive;
            MyGrid.CurrentState[11, 35] = CellState.Alive;
            MyGrid.CurrentState[12, 35] = CellState.Alive;
            MyGrid.CurrentState[16, 35] = CellState.Alive;
            MyGrid.CurrentState[17, 35] = CellState.Alive;
            // last square
            MyGrid.CurrentState[13, 45] = CellState.Alive;
            MyGrid.CurrentState[14, 45] = CellState.Alive;
            MyGrid.CurrentState[13, 46] = CellState.Alive;
            MyGrid.CurrentState[14, 46] = CellState.Alive;
        }

        /// <summary>
        /// Clears console.
        /// Prints out the LifeGrid in the console.
        /// Each dead cell is a '.', each alive cell is a '0'.
        /// Shortcuts the 2d array mess by inserting linefeeds
        /// </summary>
        /// <param name="currentState"></param>
        static void ShowGrid(CellState[,] currentState)
        {
            Console.Clear();
            int x = 0;
            int rowLength = MyGrid.GridWidth;
            var output = new StringBuilder();
            foreach (var state in currentState)
            {
                output.Append(state == CellState.Alive ? "O" : " ");
                if (++x == rowLength)
                {
                    x = 0;
                    output.AppendLine();
                }
            }
            Console.Write(output.ToString());
        }

        #endregion
    }
}
