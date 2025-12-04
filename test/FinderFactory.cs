using FinalAssignment_Algorithms.Algorithms;

namespace FinalAssignment_Algorithms
{
    internal static class FinderFactory
    {
        public static PathFinderInterface Create(string name)
        {
            switch (name)
            {
                case "BFS": 
                    return new BFS();

                case "DFS":
                    return new DFS();

                case "HillClimb":
                    return new HillClimbing();

                case "BestFirst":
                    return new BestFirst();




            }


            return null;
        }
    }
}
