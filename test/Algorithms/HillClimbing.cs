using FinalAssignment_Algorithms.Structures;
using FinalAssignment_Algorithms.OOP;
using System;

namespace FinalAssignment_Algorithms.Algorithms
{
    internal class HillClimbing : PathFinderInterface
    {
        public bool FindPath(int[,] map, Coord start, Coord end, ref LinkedList<Coord> path)
        {
            ////////////// LAST IN FIRST OUT ////////////////
            Stack<Coord> OpenList = new Stack<Coord>();
            LinkedList<Coord> ClosedList = new LinkedList<Coord>();
            LinkedList<Coord> TempList = new LinkedList<Coord>();

            int rows = map.GetLength(0);
            int cols = map.GetLength(1);
            int depthLimit = rows * cols * 5;
            int depth = 0;
            Coord[,] parent = new Coord[rows, cols];


            OpenList.Push(start);
            while (!OpenList.IsEmpty())
            {
                if (depth++ > depthLimit)
                    return false;

                // remove first
                Coord current = OpenList.Pop();
                // check if at end
                if (current.Row == end.Row && current.Col == end.Col)
                {
                    path = BuildPath(parent, start, end);
                    return true;
                }

                TempList = new LinkedList<Coord>(); // temp list to reset w 

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

                    if (map[nr, nc] == 0) // hit wall
                        continue;

                    Coord next = new Coord(nr, nc);

                    if (ListContains(ClosedList, next))
                        continue;

                    if (DoesStackHave(OpenList, next))
                        continue;

                    TempList.AddLast(next);
                    parent[nr, nc] = current;
                }

                // using heuristics !!!!!!!!!! (but in c#)
                LinkedList<Coord> SortedTmp = SortList(TempList, end);
                ReversePush(SortedTmp, OpenList);
                ClosedList.AddLast(current);
            }

            return false;
        }


        // for sorting
        private int SortHelper(Coord a, Coord b)
        {
            return Math.Abs(a.Row - b.Row) + Math.Abs(a.Col - b.Col);
        }

        private bool ListContains(LinkedList<Coord> list, Coord c)
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

        private bool DoesStackHave(Stack<Coord> stack, Coord c)
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

        private LinkedList<Coord> SortList(LinkedList<Coord> list, Coord goal)
        {
            // make into array so its easier to sort
            System.Collections.Generic.List<(Coord c, int h)> items =
                new System.Collections.Generic.List<(Coord, int)>();

            var node = list.Head;
            while (node != null)
            {
                int h = SortHelper(node.Value, goal);
                items.Add((node.Value, h));
                node = node.Next;
            }

            items.Sort((a, b) => a.h.CompareTo(b.h));

            // make into linked list again
            LinkedList<Coord> sorted = new LinkedList<Coord>();
            foreach (var item in items)
                sorted.AddLast(item.c);

            return sorted;
        }

        private void ReversePush(LinkedList<Coord> list, Stack<Coord> stack)
        {
            // reverse 
            System.Collections.Generic.List<Coord> temp =
                new System.Collections.Generic.List<Coord>();

            var node = list.Head;
            while (node != null)
            {
                temp.Add(node.Value);
                node = node.Next;
            }

            for (int i = temp.Count - 1; i >= 0; i--)
                stack.Push(temp[i]);
        }

        private LinkedList<Coord> BuildPath(Coord[,] parent, Coord start, Coord goal)
        {
            LinkedList<Coord> result = new LinkedList<Coord>();
            Coord cur = goal;

            while (!(cur.Row == start.Row && cur.Col == start.Col))
            {
                result.AddLast(cur);
                cur = parent[cur.Row, cur.Col];
            }

            result.AddLast(start);
            return result;
        }
    }
}
