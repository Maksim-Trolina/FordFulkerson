using System;

namespace FordFulkerson
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter path to file: ");

            var pathToFile = Console.ReadLine();

            try
            {
                var tree = FileHandler.GetTree(pathToFile);

                var startName = "S";

                var endName = "T";

                var maxFlow = FordFullkerson.GetMaxFlow(tree, startName, endName);

                Console.WriteLine($"Maximum flow: {maxFlow}"); ;

                var source = tree.Find(startName);

                WriteFlow(source);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void WriteFlow(Node node)
        {
            foreach (var edge in node.Edges)
            {
                var to = edge.To;

                if (edge.Size > 0 && !edge.Used)
                {
                    edge.Used = true;

                    Console.WriteLine($"Flow from {node.Name} to {to.Name}: {edge.Size}");

                    WriteFlow(to);
                }
            }
        }
    }
}
