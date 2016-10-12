using System;
using System.Collections.Generic;
using System.Text;

namespace TestSearchSolution {
    class TestSearchSolution {
        public static void TestInitialize() {
            if (SearchSolution.HierachyBuilder.RootNodes == null) {
                Console.WriteLine("RootNodes should not have zero length");
            }
            Console.WriteLine("RootNodes length is (" + SearchSolution.HierachyBuilder.RootNodes.Length + ")");
            if (SearchSolution.HierachyBuilder.RootNodes[0].Connections == null) {
                Console.WriteLine("NextDestinations should not be null");
            }
            else {
                Console.WriteLine("NextDestinations length is(" +
                    SearchSolution.HierachyBuilder.RootNodes[0].Connections.Length + ")");
            }
            if (SearchSolution.HierachyBuilder.RootNodes[0].Connections[0].Connections == null) {
                Console.WriteLine("NextDestinations[ 0].NextDestinations should not be null");
            }
        }
        public static void TestSearch() {
            SearchSolution.DepthFirstSearch cls =
                new SearchSolution.DepthFirstSearch(
                    SearchSolution.HierachyBuilder.RootNodes, 
                    SearchSolution.HierachyBuilder.GetMaxPossibleDestinationsArraySize());
            SearchSolution.Node[] foundRoute = cls.FindRoute("Montreal", "Seattle");
            for (int c1 = 0; c1 < foundRoute.Length; c1++) {
                if (foundRoute[c1] != null) {
                    Console.WriteLine("City (" + foundRoute[c1].CityName + ")");
                }
            }
            if (foundRoute.Length != 2) {
                Console.WriteLine("Incorrect route as route has two legs");
            }
            if (foundRoute[0].CityName.CompareTo("Los Angeles") != 0) {
                Console.WriteLine("Incorrect as first leg is Los Angeles");
            }
        }
        public static void Run() {
            //TestInitialize();
            TestSearch();
        }
    }
}
