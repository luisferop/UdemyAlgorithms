using System;

namespace prjDirectedWeightedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedWeightedGraph dg = new DirectedWeightedGraph();
            int choice;
            string s1, s2;
            while (true)
            {
                Console.WriteLine("1 - Display Adjacency Matrix");
                Console.WriteLine("2 - Insert a Vertex");
                Console.WriteLine("3 - Insert an Edge");
                Console.WriteLine("4 - Delete an Edge");
                Console.WriteLine("5 - Display InDegree and OutDegree of a Vertex");
                Console.WriteLine("6 - Check if there is an Edge between two Vertices");
                Console.WriteLine("7 - Exit");
                Console.WriteLine("Enter your choice :");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 7)
                {
                    break;
                }
                switch (choice)
                {
                    case 1:
                        {
                            dg.Display();
                            Console.WriteLine("Number of Vertices : " + dg.Vertices());
                            Console.WriteLine("Number of Edges : " + dg.Edges());
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Insert a Vertex : ");
                            dg.InserVertex(Console.ReadLine());
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter start and end vertices and weight : ");
                            s1 = Console.ReadLine();
                            s2 = Console.ReadLine();
                            int wt = Convert.ToInt32(Console.ReadLine());
                            dg.InsertEdge(s1, s2,wt);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter start and end vertices : ");
                            s1 = Console.ReadLine();
                            s2 = Console.ReadLine();
                            dg.DeleteEdge(s1, s2);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter a vertex : ");
                            s1 = Console.ReadLine();
                            Console.WriteLine("InDegree is :" + dg.InDegree(s1));
                            Console.WriteLine("OutDegree is :" + dg.OutDegree(s1));
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter two vertices : ");
                            s1 = Console.ReadLine();
                            s2 = Console.ReadLine();
                            if (dg.EdgeExists(s1, s2))
                            {
                                Console.WriteLine("There is an Edge from " + s1 + " to " + s2);
                            }
                            else
                            {
                                Console.WriteLine("There is no Edge from " + s1 + " to " + s2);
                            }

                            if (dg.EdgeExists(s2, s1))
                            {
                                Console.WriteLine("There is an Edge from " + s2 + " to " + s1);
                            }
                            else
                            {
                                Console.WriteLine("There is no Edge from " + s2 + " to " + s1);
                            }
                            break;
                        }
                }
            }
        }
    }
}
