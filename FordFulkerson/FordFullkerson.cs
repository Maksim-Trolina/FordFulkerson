using System;
using FordFulkerson.Map;

namespace FordFulkerson
{
    public static class FordFullkerson
    {
        static public int GetMaxFlow(AVLTree<string, Node> tree, string start, string end)
        {
            int flow;

            int maxFlow = 0;

            var source = tree.Find(start);

            do
            {
                flow = DFS(source, int.MaxValue, end);

                Fill(tree);

                maxFlow += flow;

            } while (flow > 0);

            return maxFlow;
        }

        static private void Fill(AVLTree<string, Node> tree)
        {
            var nodes = tree.GetItems();

            foreach (var node in nodes)
            {
                node.Visited = false;
            }
        }

        static private int DFS(Node node, int Cmin, string end)
        {
            if (node.Name == end)
            {
                return Cmin;
            }

            node.Visited = true;

            foreach (var edge in node.Edges)
            {
                var to = edge.To;

                if (!to.Visited && edge.Size < edge.Capacity)
                {
                    var delta = DFS(edge.To, Math.Min(Cmin, edge.Capacity - edge.Size), end);

                    if (delta > 0)
                    {
                        edge.Size += delta;

                        edge.BackEdge.Size -= delta;

                        return delta;
                    }
                }
            }

            return 0;
        }
    }
}
