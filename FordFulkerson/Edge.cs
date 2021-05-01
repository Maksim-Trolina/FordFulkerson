

namespace FordFulkerson
{
    public class Edge
    {
        public Node To { get; set; }
        public int Capacity { get; set; }

        public int Size { get; set; }

        public bool Used { get; set; }

        public Edge BackEdge { get; set; }
    }
}
