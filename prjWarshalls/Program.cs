using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWarshalls
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
            g1.InsertEdge("Two", "One");
            g1.InsertEdge("Three", "Zero");
            g1.InsertEdge("Three", "Two");
            g1.Warshalls();

            Console.WriteLine();
           

            Console.ReadLine();
        }
    }
}
