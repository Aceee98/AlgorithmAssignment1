using FinalAssignment_Algorithms.Structures;
using FinalAssignment_Algorithms.OOP;
using System;

namespace FinalAssignment_Algorithms.Algorithms
{
    internal class BestFirst : PathFinderInterface
    {
        public bool FindPath(int[,] map, Coord start, Coord end, ref LinkedList<Coord> path)
        {
            PriorityQueue<Coord> OpenList = new PriorityQueue<Coord>();
            LinkedList<Coord> ClosedList = new LinkedList<Coord>();

            int rows = map.GetLength(0);
            int cols = map.GetLength(1);
            Coord[,] parent = new Coord[rows, cols];
            int StartWithHeuristics = Heuristic(start, end);
            OpenList.Enqueue(start, StartWithHeuristics);


            while (!OpenList.IsEmpty())
            {
                Coord current = OpenList.Dequeue();
                if (current.Row == end.Row && current.Col == end.Col)
                {
                    path = BuildPath(parent, start, end);
                    return true;
                }

                // directions
                int[,] directions = {
                    { -1, 0 }, // N
                    {  0, 1 }, // E
                    {  1, 0 }, // S
                    {  0,-1 }  // W
                };

                for (int i = 0; i < 4; i++)
                {
                    int nr = current.Row + directions[i, 0];
                    int nc = current.Col + directions[i, 1];

                    if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                        continue;

                    if (map[nr, nc] == 0)
                        continue;

                    Coord next = new Coord(nr, nc);

                    // visited?
                    if (ListHas(ClosedList, next))
                        continue;
                    if (PriorityHas(OpenList, next))
                        continue;

                    parent[nr, nc] = current;

                    int h = Heuristic(next, end);
                    OpenList.Enqueue(next, h);
                }

                ClosedList.AddLast(current);
            }

            return false; // no path
        }

        private int Heuristic(Coord a, Coord b)
        {
            return Math.Abs(a.Row - b.Row) + Math.Abs(a.Col - b.Col);
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

        private bool PriorityHas(PriorityQueue<Coord> PriorityQueue__, Coord c)
        {
            var list = PriorityQueue__.GetList();
            var node = list.Head;

            while (node != null)
            {
                if (node.Value.value.Row == c.Row && node.Value.value.Col == c.Col)
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
