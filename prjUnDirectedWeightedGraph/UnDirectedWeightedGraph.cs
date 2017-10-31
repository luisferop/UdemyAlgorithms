using System;

namespace prjUnDirectedWeightedGraph
{
    public class UnDirectedWeightedGraph
    {
        public readonly int MAX_VERTICES = 30;
        int n;
        int e;
        int[,] adj;
        Vertex[] vertexList;
        public UnDirectedWeightedGraph()
        {
            adj = new int[MAX_VERTICES, MAX_VERTICES];
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
                    Console.Write(adj[i, j] + " ");
                }
                Console.WriteLine();
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
        public bool EdgeExists(string s1, string s2)
        {
            return isAdjacent(GetIndex(s1), GetIndex(s2));
        }
        private bool isAdjacent(int u, int v)
        {
            return adj[u, v] != 0;
        }
        public void InsertEdge(string s1, string s2, int wt)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);

            if (adj[u, v] != 0)
            {
                Console.WriteLine("Edge already exists");
            }
            else
            {
                adj[u, v] = wt;
                adj[v, u] = wt;
                e++;
            }
        }
        public void DeleteEdge(string s1, string s2)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);

            if (adj[u, v] == 0)
            {
                Console.WriteLine("Edge not present in the graph");
            }
            else
            {
                adj[u, v] = 0;
                adj[v, u] = 0;
                e--;
            }
        }
        public int Degree(string s)
        {
            int u = GetIndex(s);
            int deg = 0;
            for (int v = 0; v < n; v++)
            {
                if (adj[u, v] != 0)
                {
                    deg++;
                }
            }
            return deg;
        }
        
    }
}
