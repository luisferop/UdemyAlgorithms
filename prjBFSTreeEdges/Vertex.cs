using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBFSTreeEdges
{
    public class Vertex
    {
        public string Name;
        public int State;
        public int Predecessor;
        public int Distance;
        public Vertex(string name)
        {
            this.Name = name;
        }
    }
}
