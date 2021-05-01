using System;
using System.Collections.Generic;
using System.IO;
using FordFulkerson.Map;

namespace FordFulkerson
{
    public static class FileHandler
    {
        public static AVLTree<string, Node> GetTree(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                throw new Exception("No such file exists");
            }

            var tree = new AVLTree<string, Node>(new StrComparer());

            using (var sr = new StreamReader(pathToFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    AddEdge(line, tree);
                }
            }

            return tree;
        }

        private static void AddEdge(string line, AVLTree<string, Node> tree)
        {
            var parameters = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parameters.Length != 3)
            {
                throw new Exception("Invalid data format");
            }

            var cityName1 = parameters[0];

            var cityName2 = parameters[1];

            var weight = parameters[2];

            var capacity = int.Parse(weight);

            Node city1, city2;

            try
            {
                city1 = tree.Find(cityName1);
            }
            catch
            {
                city1 = new Node
                {
                    Name = cityName1,
                    Edges = new List<Edge>()
                };

                tree.Insert(cityName1, city1);
            }

            try
            {
                city2 = tree.Find(cityName2);
            }
            catch
            {
                city2 = new Node
                {
                    Name = cityName2,
                    Edges = new List<Edge>()
                };

                tree.Insert(cityName2, city2);
            }

            var city1ToCity2 = new Edge
            {
                Capacity = capacity,
                To = city2
            };

            var city2ToCity1 = new Edge
            {
                Capacity = capacity,
                To = city1
            };

            city2ToCity1.BackEdge = city1ToCity2;

            city1ToCity2.BackEdge = city2ToCity1;

            city1.Edges.Add(city1ToCity2);

            city2.Edges.Add(city2ToCity1);
        }
    }
}
