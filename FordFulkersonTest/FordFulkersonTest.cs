using NUnit.Framework;
using FordFulkerson;
using FordFulkerson.Map;
using System.Collections.Generic;
using System;
using System.IO;

namespace FordFulkersonTest
{
    public class FordFulkersonTest

    {
        private AVLTree<string, Node> tree;

        private string sourceName = "Start";

        private string endName = "End";

        [SetUp]
        public void Setup()
        {
            var source = new Node
            {
                Name = "Start",
                Edges = new List<Edge>()
            };

            var cityA = new Node
            {
                Name = "A",
                Edges = new List<Edge>()
            };

            var cityB = new Node
            {
                Name = "B",
                Edges = new List<Edge>()
            };

            var end = new Node
            {
                Name = "End",
                Edges = new List<Edge>()
            };

            var sourceToA = new Edge
            {
                To = cityA,
                Capacity = 5
            };

            var aToSource = new Edge
            {
                To = source,
                Capacity = 5
            };

            sourceToA.BackEdge = aToSource;

            aToSource.BackEdge = sourceToA;

            var sourceToB = new Edge
            {
                To = cityB,
                Capacity = 6
            };

            var bTosource = new Edge
            {
                To = source,
                Capacity = 6
            };

            sourceToB.BackEdge = bTosource;

            bTosource.BackEdge = sourceToB;

            var AToB = new Edge
            {
                To = cityB,
                Capacity = 3
            };

            var bToA = new Edge
            {
                To = cityA,
                Capacity = 3
            };

            AToB.BackEdge = bToA;

            bToA.BackEdge = AToB;

            var AToEnd = new Edge
            {
                To = end,
                Capacity = 4
            };

            var endToA = new Edge
            {
                To = cityA,
                Capacity = 4
            };

            AToEnd.BackEdge = endToA;

            endToA.BackEdge = AToEnd;

            var BToEnd = new Edge
            {
                To = end,
                Capacity = 5
            };

            var endToB = new Edge
            {
                To = cityB,
                Capacity = 5
            };

            BToEnd.BackEdge = endToB;

            endToB.BackEdge = BToEnd;

            source.Edges.Add(sourceToA);

            source.Edges.Add(sourceToB);

            cityA.Edges.Add(AToB);

            cityA.Edges.Add(AToEnd);

            cityA.Edges.Add(aToSource);

            cityB.Edges.Add(BToEnd);

            cityB.Edges.Add(bToA);

            cityB.Edges.Add(bTosource);

            end.Edges.Add(endToA);

            end.Edges.Add(endToB);

            var comparer = new StrComparer();

            tree = new AVLTree<string, Node>(comparer);

            tree.Insert(source.Name, source);

            tree.Insert(cityA.Name, cityA);

            tree.Insert(cityB.Name, cityB);

            tree.Insert(end.Name, end);
        }

        [Test]
        public void GetMaxFlow_GraphOfFourVertex_MaxFlow()
        {
            var actual = FordFullkerson.GetMaxFlow(tree, sourceName, endName);

            var expected = 9;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAVLTree_NotExistFile_Exception()
        {
            var path = "NotExist";

            Assert.Throws<Exception>(() => FileHandler.GetTree(path));
        }
    }
}