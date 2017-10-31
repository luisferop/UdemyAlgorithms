using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjKruskals
{
    public class QueueNode
    {
        public Edge info;
        public QueueNode link;
        public QueueNode(Edge e)
        {
            info = e;
            link = null;
        }
    }
}
