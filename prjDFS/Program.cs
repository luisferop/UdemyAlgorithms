using System;

namespace prjDFS
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedGraph g = new DirectedGraph();

            g.InserVertex("zero");
            g.InserVertex("one");
            g.InserVertex("two");
            g.InserVertex("three");
            g.InserVertex("four");
            g.InserVertex("five");
            g.InserVertex("six");
            g.InserVertex("seven");
            g.InserVertex("eight");
            g.InserVertex("nine");
            g.InserVertex("ten");
            g.InserVertex("eleven");

            g.InsertEdge("zero", "one");
            g.InsertEdge("zero", "three");
            g.InsertEdge("one", "two");
            g.InsertEdge("one", "four");
            g.InsertEdge("one", "five");
            g.InsertEdge("two", "five");
            g.InsertEdge("two", "seven");
            g.InsertEdge("three", "six");
            g.InsertEdge("four", "three");
            g.InsertEdge("five", "three");
            g.InsertEdge("five", "six");
            g.InsertEdge("five", "eight");
            g.InsertEdge("seven", "eight");
            g.InsertEdge("seven", "ten");
            g.InsertEdge("eight", "eleven");
            g.InsertEdge("nine", "six");
            g.InsertEdge("eleven", "nine");

            g.DFSTraversal();
            g.DFSTraversal_All();
            Console.ReadLine();
        }
    }
}
