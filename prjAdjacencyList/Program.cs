using System;

namespace prjAdjacencyList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedDiGraph g = new LinkedDiGraph();
            int choice;
            string s1, s2;
            while (true)
            {
                Console.WriteLine("1 - Display");
                Console.WriteLine("2 - Insert a Vertex");
                Console.WriteLine("3 - Delete a Vertex");
                Console.WriteLine("4 - Insert an Edge");
                Console.WriteLine("5 - Delete an Edge");
                Console.WriteLine("6 - Display Indegree and Outdegree of a vertex");
                Console.WriteLine("7 - Check if there is an edge between two vertices");
                Console.WriteLine("8 - Exit");
                Console.WriteLine("Enter you choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 8)
                {
                    break;
                }
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine();
                            g.Display();
                            Console.WriteLine("Vertices = " + g.Vertices());
                            Console.WriteLine("Edges = " + g.Edges());
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter a vertex to be inserted");
                            s1 = Console.ReadLine();
                            g.InsertVertex(s1);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter a vertex to be deleted");
                            s1 = Console.ReadLine();
                            g.DeleteVertex(s1);
                            break;
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter an edge to be inserted");
                            s1 = Console.ReadLine();
                            s2 = Console.ReadLine();
                            g.InsertEdge(s1, s2);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter an edge to be deleted");
                            s1 = Console.ReadLine();
                            s2 = Console.ReadLine();
                            g.DeleteEdge(s1, s2);
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter a vertex : ");
                            s1 = Console.ReadLine();
                            Console.WriteLine("InDegree is : " + g.InDegree(s1));
                            Console.WriteLine("OutDegree is : " + g.OutDegree(s1));
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Enter two vertices");
                            s1 = Console.ReadLine();
                            s2 = Console.ReadLine();
                            if (g.EdgeExists(s1, s2))
                            {
                                Console.WriteLine("Vertex " + s2 + " is adjacent to vertex " + s1);
                            }
                            else
                            {
                                Console.WriteLine("Vertex " + s2 + " is not adjacent to vertex " + s1);
                            }
                            if (g.EdgeExists(s2, s1))
                            {
                                Console.WriteLine("Vertex " + s1 + " is adjacent to vertex " + s2);
                            }
                            else
                            {
                                Console.WriteLine("Vertex " + s1 + " is not adjacent to vertex " + s2);
                            }
                            break;
                        }
                    default:
                        break;
                }

            }
        }
    }
}
