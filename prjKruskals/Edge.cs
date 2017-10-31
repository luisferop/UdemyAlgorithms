using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjKruskals
{
    public class Edge
    {
        public int _u;
        public int _v;
        public int _wt;
        public Edge(int u, int v, int wt)
        {
            _u = u;
            _v = v;
            _wt = wt;
        }
    }
}
