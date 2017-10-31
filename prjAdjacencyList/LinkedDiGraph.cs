using System;

namespace prjAdjacencyList
{
    public class LinkedDiGraph
    {
        VertexNode start;
        int n;
        int e;
        public int Vertices()
        {
            return n;
        }
        public int Edges()
        {
            return e;
        }
        public void InsertVertex(string s)
        {
            VertexNode temp = new VertexNode(s);
            if (start == null)
            {
                start = temp;
            }
            else
            {
                VertexNode p = start;
                while (p.nextVertex != null)
                {
                    if (p.Name.Equals(s))
                    {
                        Console.WriteLine("Vertex already present");
                        return;
                    }
                    p = p.nextVertex;
                   
                }
                if (p.Name.Equals(s))
                {
                    Console.WriteLine("Vertex already present");
                    return;
                }
                p.nextVertex = temp;
                n++;
            }
        }
        public void DeleteVertex(string s)
        {
            DeleteFromEdgeLists(s);
            DeleteFromVertexLists(s);
        }

        private void DeleteFromVertexLists(string s)
        {
            if (start == null)
            {
                Console.WriteLine("No vertices to be deleted.");
                return;
            }
            if (start.Name.Equals(s))//Vertex to be deleted is the first vertex of the list
            {
                for (EdgeNode q = start.firstEdge;q != null;q = q.nextEdge)
                {
                    e--;
                }
                start = start.nextVertex;
                n--;
            }
            else
            {
                VertexNode p = start;
                while (p.nextVertex != null)
                {
                    if (p.nextVertex.Name.Equals(s))
                    {
                        break;
                    }
                    p = p.nextVertex;
                    if (p.nextVertex == null)
                    {
                        Console.WriteLine("Vertex not found.");
                        return;
                    }
                    else
                    {
                        for (EdgeNode q = p.nextVertex.firstEdge; q != null; q = q.nextEdge)
                        {
                            e--;
                        }
                        p.nextVertex = p.nextVertex.nextVertex;
                        n--;
                    }
                }
            }
        }

        private void DeleteFromEdgeLists(string s)
        {
            for (VertexNode p = start; p != null; p = p.nextVertex)
            {
                if (p.firstEdge == null)
                {
                    continue;
                }
                if (p.firstEdge.endVertex.Name.Equals(s))
                {
                    p.firstEdge = p.firstEdge.nextEdge;
                    e--;
                }
                else
                {
                    EdgeNode q = p.firstEdge;
                    while (q.nextEdge != null)
                    {
                        if (q.nextEdge.endVertex.Name.Equals(s))
                        {
                            q.nextEdge = q.nextEdge.nextEdge;
                            e--;
                            break;
                        }
                        q = q.nextEdge;
                    }
                }
            }
        }

        private VertexNode FindVertex(string s)
        {
            VertexNode p = start;
            while (p != null)
            {
                if (p.Name.Equals(s))
                {
                    return p;
                }
                p = p.nextVertex;
            }
            return null;
        }
        public void InsertEdge(string s1, string s2)
        {
            if (s1.Equals(s2))
            {
                Console.WriteLine("Invalid Edge : Start and End vertices are the same");
                return;
            }
            VertexNode u = FindVertex(s1);
            VertexNode v = FindVertex(s2);
            if (u == null)
            {
                Console.WriteLine("Start vertex not found. Please insert vertex " + s1);
                return;
            }
            if (v == null)
            {
                Console.WriteLine("End vertex not found. Please insert vertex " + s2);
                return;
            }

            EdgeNode temp = new EdgeNode(v);
            if (u.firstEdge == null)
            {
                u.firstEdge = temp;
                e++;
            }
            else
            {
                EdgeNode p = u.firstEdge;
                while (p.nextEdge != null)
                {
                    if (p.endVertex.Name.Equals(s2))
                    {
                        Console.WriteLine("Edge already present");
                        return;
                    }
                    p = p.nextEdge;

                }
                if (p.endVertex.Name.Equals(s2))
                {
                    Console.WriteLine("Edge already present");
                    return;
                }
                p.nextEdge = temp;
                e++;
            }
        }
        public void DeleteEdge(string s1, string s2)
        {
            VertexNode u = FindVertex(s1);
            if (u == null)
            {
                Console.WriteLine("Start Vertex not present");
                return;
            }
            if (u.firstEdge == null)
            {
                Console.WriteLine("Edge not present");
                return;
            }
            if (u.firstEdge.endVertex.Name.Equals(s2))
            {
                u.firstEdge = u.firstEdge.nextEdge;
                e--;
                return;
            }
            EdgeNode q = u.firstEdge;
            while (q.nextEdge != null)
            {
                if (q.nextEdge.endVertex.Name.Equals(s2))
                {
                    q.nextEdge = q.nextEdge.nextEdge;
                    e--;
                    return;
                }
                q = q.nextEdge;
            }
            Console.WriteLine("Edge not present");

        }
        public void Display()
        {
            EdgeNode q;
            for (VertexNode p = start; p != null; p = p.nextVertex)
            {
                Console.Write(p.Name + " -> ");
                for (q = p.firstEdge; q != null; q = q.nextEdge)
                {
                    Console.Write(" " + q.endVertex.Name);
                }
                Console.WriteLine();

            }
        }
        public bool EdgeExists(string s1, string s2)
        {
            VertexNode u = FindVertex(s1);
            EdgeNode q = u.firstEdge;
            while (q != null)
            {
                if (q.endVertex.Name.Equals(s2))
                {
                    return true;
                }
                q = q.nextEdge;
            }
            return false;
        }
        public int OutDegree(string s)
        {
            VertexNode u = FindVertex(s);
            if (u == null)
            {
                throw new InvalidOperationException("Vertex not present");
            }

            int outd = 0;

            EdgeNode q = u.firstEdge;
            while (q != null)
            {
                q = q.nextEdge;
                outd++;
            }
            return outd;
        }
        public int InDegree(string s)
        {
            VertexNode u = FindVertex(s);
            if (u == null)
            {
                throw new InvalidOperationException("Vertex not present");
            }
            int ind = 0;
            for (VertexNode p = start; p != null; p = p.nextVertex)
            {
                for (EdgeNode q = p.firstEdge; q != null; q = q.nextEdge)
                {
                    if (q.endVertex.Name.Equals(s))
                    {
                        ind++;
                    }
                }
            }
            return ind;
        }
    }
}
