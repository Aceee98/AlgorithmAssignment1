using System;
using System.IO;
using FinalAssignment_Algorithms.Structures;

namespace FinalAssignment_Algorithms.Map
{
    internal static class LoadMap
    {
        public static MapGrid Load(string filePath)
        {
            // gets the file path and sets it into lines
            string[] lines = File.ReadAllLines(filePath);

            // gets the num of rows and columns
            string[] dims = lines[0].Split(' ');
            int rows = int.Parse(dims[0]);
            int cols = int.Parse(dims[1]);

            // gets where to start
            string[] startParts = lines[1].Split(' ');
            Coord start = new Coord(
                int.Parse(startParts[0]),
                int.Parse(startParts[1])
            );

            // gets where it all ends
            string[] goalParts = lines[2].Split(' ');
            Coord goal = new Coord(
                int.Parse(goalParts[0]),
                int.Parse(goalParts[1])
            );

            // makes the grid as 2d array so its easier to paint
            int[,] terrain = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                string[] rowParts = lines[r + 3].Split(' ');
                for (int c = 0; c < cols; c++)
                {
                    terrain[r, c] = int.Parse(rowParts[c]);
                }
                // Console.WriteLine(string.Join(" ", rowParts)); /////////// for testing
            }

            // makes mapgrid to hold the info
            MapGrid grid = new MapGrid();
            grid.Rows = rows;
            grid.Cols = cols;
            grid.Start = start;
            grid.Goal = goal;
            grid.Terrain = terrain;

            return grid;
        }
    }
}
