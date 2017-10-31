using System;

namespace prjUndirectedGraph
{
    public  class UndirectedGraph
    {
        public readonly int MAX_VERTICES = 30;
        int n;
        int e;
        bool[,] adj;
        Vertex[] vertexList;
        public UndirectedGraph()
        {
            adj = new bool[MAX_VERTICES, MAX_VERTICES];
            vertexList = new Vertex[MAX_VERTICES];
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
                adj[v,u] = true;
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
