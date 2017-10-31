using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBFSConnected
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
        public bool IsConnected()
        {
            for (int v = 0; v < n; v++)
            {
                vertexList[v].State = INITIAL;
            }

            int cN = 1;
            BFS_C(0, cN);
            for (int v = 0; v < n; v++)
            {
                if (vertexList[v].State == INITIAL)
                {
                    cN++;
                    BFS_C(v, cN);
                }
            }
            if (cN == 1)
            {
                Console.WriteLine("Graph is connected!");
                return true;
            }
            else
            {
                Console.WriteLine("Graph is not connected, it has " + cN + " connected componentes");
                for (int v = 0; v < n; v++)
                {
                    Console.WriteLine(vertexList[v].Name + " - " + vertexList[v].ComponentNumber);
                    
                }
                return false;
            }
        }

        private void BFS_C(int v, int cN)
        {
            Queue<int> que = new Queue<int>();
            vertexList[v].State = WAITING;

            while (que.Count != 0)
            {
                v = que.Dequeue();
                vertexList[v].State = VISITED;
                vertexList[v].ComponentNumber = cN;
                for (int i = 0; i < n; i++)
                {
                    if (isAdjacent(v, i) && vertexList[i].State == INITIAL)
                    {
                        que.Enqueue(i);
                        vertexList[i].State = WAITING;
                    }
                }
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
