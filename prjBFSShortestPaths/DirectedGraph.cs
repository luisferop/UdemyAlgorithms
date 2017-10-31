using System;
using System.Collections.Generic;

namespace prjBFSShortestPaths
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
        public void FindShortestPath(string s)
        {
            for (int v = 0; v < n; v++)
            {
                vertexList[v].State = INITIAL;
                vertexList[v].Predecessor = NIL;
                vertexList[v].Distance = INFINITE;
            }
            BFS(GetIndex(s));

            for (int v = 0; v < n; v++)
            {
                if (vertexList[v].Distance == INFINITE)
                {
                    Console.WriteLine();
                    Console.WriteLine("No path from vertex " + s + " to vertex " + vertexList[v].Name);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Shortest distance from vertex " + s + " to vertex " + vertexList[v].Name + " is " + vertexList[v].Distance);

                    int[] path = new int[n];
                    int count = 0;
                    int x, y = v;
                    while (y != NIL)
                    {
                        count++;
                        path[count] = y;
                        x = vertexList[y].Predecessor;
                        y = x;
                    }
                    Console.WriteLine("Shortest path is: ");
                    int i;
                    for (i = count; i > 1; i--)
                    {
                        Console.Write(vertexList[path[i]].Name + " -> ");
                    }
                    Console.Write(vertexList[path[i]].Name);
                }
            }
        }
        private void BFS(int v)
        {
            Queue<int> qu = new Queue<int>();
            qu.Enqueue(v);
            vertexList[v].State = WAITING;
            vertexList[v].Distance = 0;
            vertexList[v].Predecessor = NIL;
            while (qu.Count != 0)
            {
                v = qu.Dequeue();
                Console.WriteLine(vertexList[v].Name + " ");
                vertexList[v].State = VISITED;

                for (int i = 0; i < n; i++)
                {
                    if (IsAdjacent(v, i) && vertexList[i].State == INITIAL)
                    {
                        qu.Enqueue(i);
                        vertexList[i].State = WAITING;
                        vertexList[i].Predecessor = v;
                        vertexList[i].Distance = vertexList[v].Distance + 1;
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
