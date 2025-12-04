using FinalAssignment_Algorithms.Structures;

namespace FinalAssignment_Algorithms
{
    internal interface PathFinderInterface
    {
        bool FindPath(int[,] map, Coord start, Coord goal, ref LinkedList<Coord> path);
    }
}
