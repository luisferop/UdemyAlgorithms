using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjKruskals
{
    public class Vertex
    {
        public string Name;
        public int Father;
        public Vertex(string name)
        {
            Name = name;
        }
    }
}
