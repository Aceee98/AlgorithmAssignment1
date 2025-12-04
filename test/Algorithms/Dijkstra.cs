using FinalAssignment_Algorithms.Structures;
using FinalAssignment_Algorithms.OOP;
using System;

namespace FinalAssignment_Algorithms.Algorithms
{
    internal class Dijkstra : PathFinderInterface
    {
        public bool FindPath(int[,] map, Coord start, Coord end, ref LinkedList<Coord> path)
        {
            PriorityQueue<Coord> OpenList = new PriorityQueue<Coord>();
            LinkedList<Coord> ClosedList = new LinkedList<Coord>();

            int rows = map.GetLength(0);
            int cols = map.GetLength(1);

            Coord[,] parent = new Coord[rows, cols];
            int[,] distance = new int[rows, cols];

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    distance[r, c] = int.MaxValue;

            distance[start.Row, start.Col] = 0;
            OpenList.Enqueue(start, 0);

            while (!OpenList.IsEmpty())
            {
                // lowest cost node
                Coord current = OpenList.Dequeue();

                // hit end
                if (current.Row == end.Row && current.Col == end.Col)
                {
                    path = BuildPath(parent, start, end);
                    return true;
                }

                ClosedList.AddLast(current);
                int[,] directions =
                {
                    { -1, 0 }, // N
                    {  0, 1 }, // E
                    {  1, 0 }, // S
                    {  0,-1 }  // W
                };
                for (int i = 0; i < 4; i++)
                {
                    int nr = current.Row + directions[i, 0];
                    int nc = current.Col + directions[i, 1];

                    // bounds
                    if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                        continue;

                    // wall
                    if (map[nr, nc] == 0)
                        continue;

                    Coord next = new Coord(nr, nc);

                    // visited?
                    if (ListHas(ClosedList, next))
                        continue;

                    int terrainCost = map[nr, nc];
                    int newCost = distance[current.Row, current.Col] + terrainCost;

                    // checks for if theres a cheaper poath
                    if (newCost < distance[nr, nc])
                    {
                        distance[nr, nc] = newCost;
                        parent[nr, nc] = current;

                        OpenList.Enqueue(next, newCost);
                    }
                }
            }

            return false; // no path 
        }


        private bool ListHas(LinkedList<Coord> list, Coord c)
        {
            var node = list.Head;
            while (node != null)
            {
                if (node.Value.Row == c.Row && node.Value.Col == c.Col)
                    return true;
                node = node.Next;
            }
            return false;
        }

        private LinkedList<Coord> BuildPath(Coord[,] parent, Coord start, Coord end)
        {
            LinkedList<Coord> result = new LinkedList<Coord>();
            Coord current = end;

            while (!(current.Row == start.Row && current.Col == start.Col))
            {
                result.AddLast(current);
                current = parent[current.Row, current.Col];
            }

            result.AddLast(start);
            return result;
        }
    }
}
