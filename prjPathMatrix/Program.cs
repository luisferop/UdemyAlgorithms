using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPathMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedGraph g1 = new DirectedGraph();
            g1.InserVertex("Zero");
            g1.InserVertex("One");
            g1.InserVertex("Two");
            g1.InserVertex("Three");

            g1.InsertEdge("Zero", "One");
            g1.InsertEdge("Zero", "Three");
            g1.InsertEdge("One", "Two");
            g1.InsertEdge("One", "Three");
            g1.InsertEdge("Three", "Two");
            g1.FindPathMatrix();

            Console.WriteLine();
            Console.WriteLine();

            DirectedGraph g2 = new DirectedGraph();
            g2.InserVertex("Zero");
            g2.InserVertex("One");
            g2.InserVertex("Two");
            g2.InserVertex("Three");

            g2.InsertEdge("Zero", "One");
            g2.InsertEdge("Zero", "Three");
            g2.InsertEdge("One", "Two");
            g2.InsertEdge("One", "Three");
            g2.InsertEdge("Two", "Zero");
            g2.InsertEdge("Three", "Two");
            g2.FindPathMatrix();

            Console.ReadLine();
        }
    }
}
