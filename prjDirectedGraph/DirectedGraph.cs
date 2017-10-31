using System;

namespace prjDirectedGraph
{
    public class DirectedGraph
    {
        public readonly int MAX_VERTICES = 30;
        int n;
        int e;
        bool[,] adj;
        Vertex[] vertexList;
        public DirectedGraph()
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
        public void InserVertex(string name)
        {
            vertexList[n++] = new Vertex(name);
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
                e--;
            }
        }
        public int OutDegree(string s)
        {
            int u = GetIndex(s);

            int outd = 0;
            for (int v = 0; v < n; v++)
            {
                if (adj[u,v])
                {
                    outd++;
                }
            }
            return outd;
        }
        public int InDegree(string s)
        {
            int u = GetIndex(s);
            int ind = 0;
            for (int v = 0; v < n; v++)
            {
                if (adj[v,u])
                {
                    ind++;
                }
            }
            return ind;
        }
    }
}
