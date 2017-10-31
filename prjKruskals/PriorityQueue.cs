using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjKruskals
{
    public class PriorityQueue
    {
        private QueueNode front;
        public PriorityQueue()
        {
            front = null;
        }
        public void InsertEdge(Edge e)
        {

            QueueNode temp, p;

            temp = new QueueNode(e);
            if (IsEmpty() || e._wt < front.info._wt)
            {
                temp.link = front;
                front = temp;
            }
            else
            {
                p = front;
                while (p.link != null && p.link.info._wt <= e._wt)
                {
                    p = p.link;
                }
                temp.link = p.link;
                p.link = temp;
            }
        }
        public Edge Delete()
        {
            Edge e;
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue underflow");
            }
            else
            {
                e = front.info;
                front = front.link;
            }
            return e;
        }
        public bool IsEmpty()
        {
            return front == null;
        }

    }
}
