using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBFSTreeEdges
{
    public class DirectedGraph
    {
        public readonly int MAX_VERTICES = 30;
        int n;
        int e;
        bool[,] adj;
        Vertex[] vertexList;
        private readonly int INITIAL = 0;
        private readonly int WAITING = 1;
        private readonly int VISITED = 2;

        private readonly int NIL = -1;
        private readonly int INFINITE = 99999;
        public DirectedGraph()
        {
            adj = new bool[MAX_VERTICES, MAX_VERTICES];
            vertexList = new Vertex[MAX_VERTICES];
        }
        public void BFSTreeEdges()
        {
            int v;
            for (v = 0; v < n; v++)
            {
                vertexList[v].State = INITIAL;
            }
            Console.WriteLine("Enter starting vertex for Breadth First Search : ");
            string s = Console.ReadLine();

            BFSTree(GetIndex(s));

            for (v = 0;  v < n; v++)
            {
                if(vertexList[v].State == INITIAL)
                    BFSTree(v);
            }
        }

        private void BFSTree(int v)
        {
            Queue<int> qu = new Queue<int>();
            qu.Enqueue(v);
            vertexList[v].State = VISITED;
            while (qu.Count != 0)
            {
                v = qu.Dequeue();
                vertexList[v].State = VISITED;
                for (int i = 0; i < n; i++)
                {
                    if (IsAdjacent(v, i) && vertexList[i].State == INITIAL)
                    {
                        qu.Enqueue(i);
                        vertexList[i].State = WAITING;
                        Console.WriteLine("Tree Edge : (" + vertexList[v].Name + "," + vertexList[i].Name + ")");
                    }
                }
            }
            Console.WriteLine();
        }

        private int GetIndex(string s)
        {
            for (int i = 0; i < n; i++)
            {
                if (s.Equals(vertexList[i].Name))
                {
                    return i;
                }
            }
            throw new InvalidOperationException("Invalid Vertex");
        }

        private bool IsAdjacent(int u, int v)
        {
            return adj[u, v];
        }
        public void InserVertex(string name)
        {
            vertexList[n++] = new Vertex(name);
        }

        public void InsertEdge(string s1, string s2)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);

            if (u == v)
            {
                throw new InvalidOperationException("not a valid edge");
            }

            if (adj[u, v])
            {
                Console.WriteLine("Edge already exists");
            }
            else
            {
                adj[u, v] = true;
                e++;
            }
        }
    }
}
