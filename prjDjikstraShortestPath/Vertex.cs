using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjDjikstraShortestPath
{
    public class Vertex
    {
        public string Name;
        public int Status;
        public int Predecessor;
        public int PathLength;
        public Vertex(string name)
        {
            this.Name = name;
        }
    }
}
