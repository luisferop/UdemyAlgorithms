using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjDjikstraShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedWeightedGraph g = new DirectedWeightedGraph();
            g.InserVertex("zero");
            g.InserVertex("one");
            g.InserVertex("two");
            g.InserVertex("three");
            g.InserVertex("four");
            g.InserVertex("five");
            g.InserVertex("six");
            g.InserVertex("seven");
            g.InserVertex("eight");

            g.InsertEdge("zero", "three",2);
            g.InsertEdge("zero", "one", 5);
            g.InsertEdge("zero", "four", 8);
            g.InsertEdge("one", "four", 2);
            g.InsertEdge("two", "one", 3);
            g.InsertEdge("two", "five", 4);
            g.InsertEdge("three", "four", 7);
            g.InsertEdge("three", "six", 8);
            g.InsertEdge("four", "five", 9);
            g.InsertEdge("four", "seven", 4);
            g.InsertEdge("five", "one", 6);
            g.InsertEdge("six", "seven", 9);
            g.InsertEdge("seven", "three", 5);
            g.InsertEdge("seven", "five", 3);
            g.InsertEdge("seven", "eight", 5);
            g.InsertEdge("eight", "five", 3);

            g.FindPaths("zero");

            Console.ReadLine();
        }
    }
}
