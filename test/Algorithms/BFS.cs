using FinalAssignment_Algorithms.Structures;
using FinalAssignment_Algorithms.OOP;

namespace FinalAssignment_Algorithms.Algorithms
{
    internal class BFS : PathFinderInterface
    {
        public bool FindPath(int[,] map, Coord start, Coord goal, ref LinkedList<Coord> path)
        {
            ////////////////////////// FIRST IN FIRST OUT //////////////////////////////////
            Queue<Coord> OpenList = new Queue<Coord>();

            // visited
            LinkedList<Coord> ClosedList = new LinkedList<Coord>();

            // parent map cuz its more efficient (memory-wise) and easier backtracking
            Coord[,] parent = new Coord[map.GetLength(0), map.GetLength(1)];

            OpenList.AddToTheQueue(start);

            while (!OpenList.Empty_())
            {
                // get first from openlist
                Coord current = OpenList.Dequeue();

                // when the goal is there
                if (current.Row == goal.Row && current.Col == goal.Col)
                {
                    path = BuildPath(parent, start, goal);
                    return true;
                }

                // the directions
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

                    // black squares/the walls - nono areas
                    if (nr < 0 || nr >= map.GetLength(0)) continue;
                    if (nc < 0 || nc >= map.GetLength(1)) continue;
                    if (map[nr, nc] == 0) continue;

                    Coord next = new Coord(nr, nc);

                    // is it in closed(/open) list?
                    if (ClosedListGot(ClosedList, next)) continue;
                    
                    if (OpenListGot(OpenList, next)) continue;

                    parent[nr, nc] = current;
                    OpenList.AddToTheQueue(next);
                }

                // add current to closed list
                ClosedList.AddLast(current);
            }

            return false;
        }

        private bool ClosedListGot(LinkedList<Coord> list, Coord c)
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

        private bool OpenListGot(Queue<Coord> queue, Coord c)
        {
            
            var node = queue.GetOtherList().Head;
            while (node != null)
            {
                if (node.Value.Row == c.Row && node.Value.Col == c.Col)
                    return true;
                node = node.Next;
            }
            return false;
        }

        private LinkedList<Coord> BuildPath(Coord[,] parent, Coord start, Coord goal)
        {
            LinkedList<Coord> result = new LinkedList<Coord>();
            Coord current = goal;

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
