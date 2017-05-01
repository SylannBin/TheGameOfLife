using Conway.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            MyGrid = new LifeGrid(20, 20);

            // Set the Alive cells (Cells are Dead by default)
            MyGrid.CurrentState[1, 2] = CellState.Alive;
            MyGrid.CurrentState[2, 2] = CellState.Alive;
            MyGrid.CurrentState[3, 2] = CellState.Alive;
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

            foreach (var state in currentState)
            {
                var output = state == CellState.Alive ? "0" : ".";
                Console.Write(output);
                x++;
                if (x >= rowLength)
                {
                    x = 0;
                    Console.WriteLine();
                }
            }
        }

        #endregion
    }
}
