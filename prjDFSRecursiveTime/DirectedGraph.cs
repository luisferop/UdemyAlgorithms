﻿using System;

namespace prjDFSRecursiveTime
{
    public class DirectedGraph
    {

        public readonly int MAX_VERTICES = 30;
        int n;
        int e;
        bool[,] adj;
        Vertex[] vertexList;
        private static int time;
        private readonly int INITIAL = 0;
        private readonly int VISITED = 1;
        private readonly int FINISHED = 2;
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
        public void DFSTraversal()
        {
            for (int v = 0; v < n; v++)
            {
                vertexList[v].State = INITIAL;
            }
            time = 0;
            Console.WriteLine("Enter starting vertex for Depth First Search");
            string s = Console.ReadLine();
            DFS(GetIndex(s));
            Console.WriteLine();
            for (int v = 0; v < n; v++)
            {
                Console.WriteLine("Vertex : " + vertexList[v].Name);
                Console.Write("Discovery time : " + vertexList[v].DiscoveryTime);
                Console.WriteLine("Finishing Time : " + vertexList[v].FinishingTime);
            }
        }
        private void DFS(int v)
        {
            
            vertexList[v].State = VISITED;
            vertexList[v].DiscoveryTime = ++time;
            for (int i = 0; i < n; i++)
            {
                if (IsAdjacent(v, i) && vertexList[i].State == INITIAL)
                {
                    DFS(i);
                }
            }
            vertexList[v].State = FINISHED;
            vertexList[v].FinishingTime = ++time;
        }
        public void DFSTraversal_All()
        {
            int v;
            for (v = 0; v < n; v++)
            {
                vertexList[v].State = INITIAL;
            }
            time = 0;
            Console.Write("Enter starting vertex for Depth First Search");
            string s = Console.ReadLine();
            DFS(GetIndex(s));
            for (v = 0; v < n; v++)
            {
                if (vertexList[v].State == INITIAL)
                    DFS(v);
            }
            Console.WriteLine();
            for (v = 0; v < n; v++)
            {
                Console.WriteLine("Vertex : " + vertexList[v].Name);
                Console.Write("Discovery time : " + vertexList[v].DiscoveryTime);
                Console.WriteLine("Finishing Time : " + vertexList[v].FinishingTime);
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
