using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjKruskals
{
    public class UndirectedWeightedGraph
    {
        public readonly int MAX_VERTICES = 30;
        int n;
        int e;
        int[,] adj;
        Vertex[] vertexList;
        private readonly int NIL = -1;
        public UndirectedWeightedGraph()
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

        public void Kruskals()
        {
            PriorityQueue pq = new PriorityQueue();
            int u, v;
            for (u = 0; u < n; u++)
            {
                for (v = 0; v < u; v++)
                {
                    if (adj[u, v] != 0)
                    {
                        pq.InsertEdge(new Edge(u, v, adj[u, v]));
                    }
                }
            }
            for (v = 0; v < n; v++)
            {
                vertexList[v].Father = NIL;
            }
            int v1, v2, r1 = NIL, r2 = NIL;
            int edgesInTree = 0;
            int wtTree = 0;

            while (!pq.IsEmpty() && edgesInTree < n - 1)
            {
                Edge edge = pq.Delete();
                v1 = edge._u;
                v2 = edge._v;
                v = v1;
                while (vertexList[v].Father != NIL)
                {
                    v = vertexList[v].Father;
                }
                r1 = v;

                v = v2;
                while (vertexList[v].Father != NIL)
                {
                    v = vertexList[v].Father;
                }
                r2 = v;
                if (r1 != r2) //Edge (v1,v2) is included
                {
                    edgesInTree++;
                    Console.WriteLine(vertexList[v1].Name + "->" + vertexList[v2].Name);
                    wtTree += edge._wt;
                    vertexList[r2].Father = r1;
                }

            }
            if (edgesInTree < n - 1)
            {
                Console.WriteLine("Graph is not connected , no spanning tree possible!");
            }
            else
            {
                Console.WriteLine($"Weight of Minimum spanning tree is '{wtTree}'");
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

    }
}
