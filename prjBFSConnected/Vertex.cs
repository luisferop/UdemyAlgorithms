using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBFSConnected
{
    public class Vertex
    {
        public string Name;
        public int State;
        public int ComponentNumber;
        public Vertex(string _name)
        {
            Name = _name;
        }
    }
}
