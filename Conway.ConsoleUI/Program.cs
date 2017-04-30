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
        /// <summary>
        /// Main entry point.
        /// Executes the program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var grid = new LifeGrid();
            grid.CurrentState[1, 2] = CellState.Alive;
            grid.CurrentState[2, 2] = CellState.Alive;
            grid.CurrentState[3, 2] = CellState.Alive;

            ShowGrid(grid.CurrentState);

            while (Console.ReadLine() != "q")
            {
                grid.UpdateState();
                ShowGrid(grid.CurrentState);
            }
        }

        /// <summary>
        /// Clears console.
        /// Prints out the LifeGrid in the console.
        /// Each dead cell is a '.', each alive cell is a '0'
        /// </summary>
        /// <param name="currentState"></param>
        private static void ShowGrid(CellState[,] currentState)
        {
            Console.Clear();
            int x = 0;
            int rowLength = 5;

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
    }
}
