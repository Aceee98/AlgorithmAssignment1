using FinalAssignment_Algorithms.Structures;

namespace FinalAssignment_Algorithms.Map
{

    // struct to store the map grid info
    internal class MapGrid{
        public int Rows;
        public int Cols;

        public Coord Start;
        public Coord Goal;

        public int[,] Terrain;
    }
}
