using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBFSUndirected
{
    public class UndirectedGraph
    {
        public readonly int MAX_VERTICES = 30;
        int n;
        int e;
        bool[,] adj;
        Vertex[] vertexList;
        private readonly int INITIAL = 0;
        private readonly int WAITING = 1;
        private readonly int VISITED = 2;
        public UndirectedGraph()
        {
            adj = new bool[MAX_VERTICES, MAX_VERTICES];
            vertexList = new Vertex[MAX_VERTICES];
        }

        public void BFSTraversal()
        {
            int v;
            for (v = 0; v < n; v++)
            {
                vertexList[v].state = INITIAL;
            }
            Console.Write("Enter starting vertex for BFS : ");
            BFS(GetIndex(Console.ReadLine()));
        }

        private void BFS(int v)
        {
            Queue<int> qu = new Queue<int>();
            qu.Enqueue(v);
            vertexList[v].state = WAITING;
            while (qu.Count != 0)
            {
                v = qu.Dequeue();
                Console.Write(vertexList[v].Name + " ");
                vertexList[v].state = VISITED;
                for (int i = 0; i < n; i++)
                {
                    if (isAdjacent(v, i) && vertexList[i].state == INITIAL)
                    {
                        qu.Enqueue(i);
                        vertexList[i].state = WAITING;

                    }
                }
            }
            Console.WriteLine();

        }
        public void BFSTraversal_All()
        {
            int v;
            for (v = 0;  v < n; v++)
            {
                vertexList[v].state = INITIAL;
            }
            Console.Write("Enter starting vertex from BFS :");
            BFS(GetIndex(Console.ReadLine()));
            for (v = 0; v < n; v++)
            {
                if (vertexList[v].state == INITIAL)
                    BFS(v);
            }
        }

        public int Vertices()
        {
            return n;
        }
        public int Edges()
        {
            return e;
        }
        public void Display()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (adj[i, j])
                    {
                        Console.WriteLine("1");
                    }
                    else
                    {
                        Console.WriteLine("0");
                    }

                }
            }
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
        public void InserVertex(string name)
        {
            vertexList[n++] = new Vertex(name);
        }
        private bool isAdjacent(int u, int v)
        {
            return adj[u, v];
        }
        public bool EdgeExists(string s1, string s2)
        {
            return isAdjacent(GetIndex(s1), GetIndex(s2));
        }

        public void InsertEdge(string s1, string s2)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);

            if (adj[u, v])
            {
                Console.WriteLine("Edge already exists");
            }
            else
            {
                adj[u, v] = true;
                adj[v, u] = true;
                e++;
            }
        }
        public void DeleteEdge(string s1, string s2)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);

            if (!adj[u, v])
            {
                Console.WriteLine("Edge not present in the graph");
            }
            else
            {
                adj[u, v] = false;
                adj[v, u] = false;
                e--;
            }
        }
        public int Degree(string s)
        {
            int u = GetIndex(s);
            int deg = 0;
            for (int v = 0; v < n; v++)
            {
                if (adj[u, v])
                {
                    deg++;
                }
            }
            return deg;
        }
    }
}
