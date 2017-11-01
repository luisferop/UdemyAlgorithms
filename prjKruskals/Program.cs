using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjKruskals
{
    class Program
    {
        static void Main(string[] args)
        {
            UndirectedWeightedGraph graph = new UndirectedWeightedGraph();
            graph.InserVertex("Zero");
            graph.InserVertex("One");
            graph.InserVertex("Two");
            graph.InserVertex("Three");
            graph.InserVertex("Four");
            graph.InserVertex("Five");
            graph.InserVertex("Six");
            graph.InserVertex("Seven");
            graph.InserVertex("Eight");
            graph.InserVertex("Nine");

            graph.InsertEdge("Zero", "One", 19);
            graph.InsertEdge("Zero", "Three", 14);
            graph.InsertEdge("Zero", "Four", 12);
            graph.InsertEdge("One", "Two", 20);
            graph.InsertEdge("One", "Four", 18);
            graph.InsertEdge("Two", "Four", 17);
            graph.InsertEdge("Two", "Five", 15);
            graph.InsertEdge("Two", "Nine", 29);
            graph.InsertEdge("Three", "Four", 13);
            graph.InsertEdge("Three", "Six", 28);
            graph.InsertEdge("Four", "Five", 16);
            graph.InsertEdge("Four", "Six", 21);
            graph.InsertEdge("Four", "Seven", 22);
            graph.InsertEdge("Four", "Eight", 24);
            graph.InsertEdge("Five", "Eight", 26);
            graph.InsertEdge("Five", "Nine", 27);
            graph.InsertEdge("Six", "Seven", 23);
            graph.InsertEdge("Seven", "Eight", 30);
            graph.InsertEdge("Eight", "Nine", 35);

            graph.Kruskals();

            Console.ReadLine();

        }
    }
}
