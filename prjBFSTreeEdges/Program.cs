using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBFSTreeEdges
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedGraph gr = new DirectedGraph();
            gr.InserVertex("0");
            gr.InserVertex("1");
            gr.InserVertex("2");
            gr.InserVertex("3");
            gr.InserVertex("4");
            gr.InserVertex("5");
            gr.InserVertex("6");
            gr.InserVertex("7");
            gr.InserVertex("8");
            gr.InserVertex("9");

            gr.InsertEdge("0", "1");
            gr.InsertEdge("0", "3");
            gr.InsertEdge("1", "2");
            gr.InsertEdge("1", "4");
            gr.InsertEdge("1", "5");
            gr.InsertEdge("2", "3");
            gr.InsertEdge("2", "5");
            gr.InsertEdge("3", "6");
            gr.InsertEdge("4", "5");
            gr.InsertEdge("4", "7");
            gr.InsertEdge("5", "6");
            gr.InsertEdge("5", "8");
            gr.InsertEdge("6", "8");
            gr.InsertEdge("6", "9");
            gr.InsertEdge("7", "8");
            gr.InsertEdge("8", "9");

            gr.BFSTreeEdges();

            Console.ReadLine();
        }
    }
}
