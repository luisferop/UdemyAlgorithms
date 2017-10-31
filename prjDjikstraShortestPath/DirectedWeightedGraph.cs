using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjDjikstraShortestPath
{
    public class DirectedWeightedGraph
    {
        public readonly int MAX_VERTICES = 30;
        int n, e;
        int[,] adj;
        Vertex[] vertexList;

        private readonly int TEMPORARY = 1;
        private readonly int PERMANENT = 2;
        private readonly int NIL = -1;
        private readonly int INFINITY = 99999;

        public DirectedWeightedGraph()
        {
            adj = new int[MAX_VERTICES, MAX_VERTICES];
            vertexList = new Vertex[MAX_VERTICES];
        }

        private void Dijkstra(int s)
        {
            int v, c;
            for (v = 0; v < n; v++)
            {
                vertexList[v].Status = TEMPORARY;
                vertexList[v].PathLength = INFINITY;
                vertexList[v].Predecessor = NIL;
            }
            vertexList[s].PathLength = 0;
            while (true)
            {
                c = TempVertexMinPL();

                if (c == NIL)
                    return;

                vertexList[c].Status = PERMANENT;

                for (v = 0; v < n; v++)
                {
                    if (isAdjacent(c, v) && vertexList[v].Status == TEMPORARY)
                    {
                        if (vertexList[c].PathLength + adj[c, v] < vertexList[v].PathLength)
                        {
                            vertexList[v].Predecessor = c;
                            vertexList[v].PathLength = vertexList[c].PathLength + adj[c, v];
                        }
                    }
                }

            }
        }

        private int TempVertexMinPL()
        {
            int min = INFINITY;
            int x = NIL;
            for (int v = 0; v < n; v++)
            {
                if (vertexList[v].Status == TEMPORARY && vertexList[v].PathLength < min)
                {
                    min = vertexList[v].PathLength;
                    x = v;
                }
            }
            return x;
        }
        public void FindPaths(string source)
        {
            int s = GetIndex(source);
            Dijkstra(s);

            Console.WriteLine("Source Vertex : " + source + "\n");

            for (int v = 0; v < n; v++)
            {
                Console.WriteLine("Destination Vertex : " + vertexList[v].Name);
                if (vertexList[v].PathLength == INFINITY)
                {
                    Console.WriteLine("There is no path from " + source + " to vertex" + vertexList[v].Name);
                }
                else
                {
                    FindPath(s, v);
                }
            }
        }

        private void FindPath(int s, int v)
        {
            int i, u;
            int[] path = new int[n];
            int sd = 0;
            int count = 0;
            while (v != s)
            {
                count++;
                path[count] = v;
                u = vertexList[v].Predecessor;
                sd += adj[u, v];
                v = u;
            }
            count++;
            path[count] = s;
            Console.Write("Shortest path is : ");
            for (i = count; i >= 1; i--)
            {
                Console.Write(path[i] + " -> ");
            }
            Console.WriteLine("Shortest distance is : " + sd + "\n");
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
            return adj[u, v] != 0;
        }
        public bool EdgeExists(string s1, string s2)
        {
            return isAdjacent(GetIndex(s1), GetIndex(s2));
        }
        public void InsertEdge(string s1, string s2, int value)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);

            if (u == v)
            {
                throw new InvalidOperationException("not a valid edge");
            }

          
            adj[u, v] = value;
            e++;
        }
    }
}
