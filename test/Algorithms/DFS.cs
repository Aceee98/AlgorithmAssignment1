using FinalAssignment_Algorithms.Structures;
using FinalAssignment_Algorithms.OOP;

namespace FinalAssignment_Algorithms.Algorithms
{
    internal class DFS : PathFinderInterface
    {
        public bool FindPath(int[,] map, Coord start, Coord goal, ref LinkedList<Coord> path)
        {
            //////////// LAST IN FIRST OUT ////////////
            Stack<Coord> OpenList = new Stack<Coord>();
            LinkedList<Coord> ClosedList = new LinkedList<Coord>();

            int rows = map.GetLength(0);
            int cols = map.GetLength(1);
            int depthLimit = rows * cols * 5;
            int depth = 0;

            Coord[,] parent = new Coord[rows, cols];


            OpenList.Push(start);

            while (!OpenList.IsEmpty())
            {
                if (depth++ > depthLimit) // so it wont keep going forever and ever
                    return false;

                Coord current = OpenList.Pop();

                if (current.Row == goal.Row && current.Col == goal.Col)
                {
                    path = BuildPath(parent, start, goal);
                    return true;
                }

                int[,] directions = new int[,]
                {
                    {  0, -1 }, // W
                    {  1,  0 }, // S
                    {  0,  1 }, // E
                    { -1,  0 }  // N
                };

                for (int i = 0; i < 4; i++)
                {
                    int nr = current.Row + directions[i, 0];
                    int nc = current.Col + directions[i, 1];

                    // wall
                    if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                        continue;

                    // wall
                    if (map[nr, nc] == 0)
                        continue;
                    Coord next = new Coord(nr, nc);

                    // visited 
                    if (ListHas(ClosedList, next))
                        continue;

                    if (StackHas(OpenList, next))
                        continue;

                    parent[nr, nc] = current;

                    OpenList.Push(next);
                }
                ClosedList.AddLast(current);
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

        private bool StackHas(Stack<Coord> stack, Coord c)
        {
            var list = stack.GetList();
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
