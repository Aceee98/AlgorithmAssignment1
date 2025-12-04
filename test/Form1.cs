using FinalAssignment_Algorithms.Algorithms;
using FinalAssignment_Algorithms.Map;
using FinalAssignment_Algorithms.Structures;
using System;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FinalAssignment_Algorithms
{
    public partial class Form1 : Form
    {
        private MapGrid currentMap;

        // saves path so it can bre drawn
        private LinkedList<Coord> pathToDraw;

        private LinkedList<Coord> oldPathToDraw;

        private string currentMapName = "";



        public Form1()
        {
            InitializeComponent();


            // to make sure dropdown has a base value
            AlgorithmDropDown.SelectedIndex = 0;
        }

        private void LoadMapButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileManagerShow = new OpenFileDialog();
            fileManagerShow.Filter = "Text Files (*.txt)|*.txt";

            if (fileManagerShow.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    currentMap = LoadMap.Load(fileManagerShow.FileName);
                    currentMapName = System.IO.Path.GetFileNameWithoutExtension(fileManagerShow.FileName);


                    pathToDraw = null;     // clear old path
                    MapPanel.Invalidate(); // redraw map
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Failed to load map: " + exception.Message);
                }
            }
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            if (currentMap == null)
            {
                MessageBox.Show("Load a map first");
                return;
            }


            if (AlgorithmDropDown.SelectedItem == null)
            {
                MessageBox.Show("An error has occured. Please Enter a valid algortihm.");
                return;
            }

            string algorithmUsed = AlgorithmDropDown.SelectedItem.ToString();




            // get the algorihtm from the factory
            PathFinderInterface finder = FinderFactory.Create(algorithmUsed);
            if (finder == null)
            {
                // precautionary incase something unexpected happens
                MessageBox.Show("Algorithm not found.");
                return;
            }

            LinkedList<Coord> path = null;

            // get the map info
            bool found = finder.FindPath(
                currentMap.Terrain,
                currentMap.Start,
                currentMap.Goal,
                ref path
            );

            if (!found)
            {
                MessageBox.Show("No path found.");
                return;
            }

            // store the new path for painting
            pathToDraw = path;

            string algorithmName_XXX = algorithmUsed;
            string outputName = currentMapName + "Path_" + algorithmName_XXX + ".txt";

            SavePath(outputName, pathToDraw);

            // optional but nice
            MessageBox.Show("Path saved to: " + outputName);


            MessageBox.Show("Path found with " + path.Count + " steps.");

            MapPanel.Invalidate(); // redraw map but with the path
        }

        private void MapPanel_Paint(object sender, PaintEventArgs e)
        {
            if (currentMap == null)
                return;

            Graphics graphics_ = e.Graphics;
            int cellSize = 20;

            // draw terrain grid
            for (int row = 0; row < currentMap.Rows; row++)
            {
                for (int column = 0; column < currentMap.Cols; column++)
                {
                    int val = currentMap.Terrain[row, column];
                    Brush brush;

                    switch (val)
                    {
                        case 0: brush = Brushes.Black; break;
                        case 1: brush = Brushes.White; break;
                        case 2: brush = Brushes.Green; break;
                        case 3: brush = Brushes.Blue; break;
                        default: brush = Brushes.White; break;
                    }

                    graphics_.FillRectangle(brush, column * cellSize, row * cellSize, cellSize, cellSize);
                    graphics_.DrawRectangle(Pens.White, column * cellSize, row * cellSize, cellSize, cellSize);
                }
            }

            // drawing the path 
            if (pathToDraw != null)
            {
                var node = pathToDraw.Head;

                while (node != null)
                {
                    Coord step = node.Value;

                    graphics_.FillRectangle(
                        Brushes.Pink,
                        step.Col * cellSize,
                        step.Row * cellSize,
                        cellSize,
                        cellSize
                    );

                    node = node.Next;
                }
            }

            // draw start + goal on top
            int startingPart1 = currentMap.Start.Col * cellSize;
            int startingPart2 = currentMap.Start.Row * cellSize;
            graphics_.FillRectangle(Brushes.Yellow, startingPart1, startingPart2, cellSize, cellSize);

            int endPart1 = currentMap.Goal.Col * cellSize;
            int endPart2 = currentMap.Goal.Row * cellSize;
            graphics_.FillRectangle(Brushes.Red, endPart1, endPart2, cellSize, cellSize);
        }

        private void SavePath(string fileName, LinkedList<Coord> path)
        {
            // streamwriter weird, file in /bin somewhere 
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                var node = path.Head;

                while (node != null)
                {
                    sw.WriteLine(node.Value.Row + " " + node.Value.Col);
                    node = node.Next;
                }
            }
        }

        private void AlgorithmDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
