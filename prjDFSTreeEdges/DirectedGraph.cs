using System;
using System.Collections.Generic;

namespace prjDFSTreeEdges
{
    public class DirectedGraph
    {
        public readonly int MAX_VERTICES = 30;
        int n;
        int e;
        bool[,] adj;
        Vertex[] vertexList;

        private readonly int INITIAL = 0;
        private readonly int VISITED = 1;
        private readonly int NIL = -1;

        public DirectedGraph()
        {
            adj = new bool[MAX_VERTICES, MAX_VERTICES];
            vertexList = new Vertex[MAX_VERTICES];
        }
        public void DFSTreeEdges()
        {
            int v;
            for (v = 0; v < n; v++)
            {
                vertexList[v].State = INITIAL;
                vertexList[v].Predecessor = NIL;
            }
            Console.WriteLine("Enter starting vertex for DFS :");
            string s = Console.ReadLine();
            DFSTree(GetIndex(s));

            for (v = 0; v < n; v++)
            {
                if (vertexList[v].State == INITIAL)
                {
                    DFSTree(v);
                }
            }
            Console.WriteLine("Tree Edges :");
            int u;
            for (v = 0; v < n; v++)
            {
                u = vertexList[v].Predecessor;
                if (u != NIL)
                {
                    Console.WriteLine("(" + vertexList[u].Name + "," + vertexList[v].Name + ")");
                }
            }

        }

        private void DFSTree(int v)
        {
            Stack<int> st = new Stack<int>();
            st.Push(v);
            while (st.Count != 0)
            {
                v = st.Pop();
                if (vertexList[v].State == INITIAL)
                {
                    Console.WriteLine(vertexList[v].Name + " ");
                    vertexList[v].State = VISITED;
                }
                for (int i = n-1; i >= 0; i--)
                {
                    if (IsAdjacent(v, i) && vertexList[i].State == INITIAL)
                    {
                        st.Push(i);
                        vertexList[i].Predecessor = v;
                    }
                }
            }
            Console.WriteLine();
        }
        public void DFSTraversal()
        { }
        public int Vertices()
        {
            return n;
        }
        public int Edges()
        {
            return e;
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
