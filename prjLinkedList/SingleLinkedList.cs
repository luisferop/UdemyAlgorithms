using System;

namespace prjLinkedList
{
    public class SingleLinkedList
    {
        private Node start;
        public SingleLinkedList()
        {
            start = null;
        }
        public void CreateList()
        {
            int i, n, data;
            Console.Write("Enter the number of the nodes");
            n = Convert.ToInt32(Console.ReadLine());
            if (n == 0)
            {
                return;
            }
            for (i = 0; i < n; i++)
            {
                Console.Write("Enter the element to be inserted: ");
                data = Convert.ToInt32(Console.ReadLine());
                InsertAtEnd(data);
            }
        }
        public void DisplayList()
        {
            Node p;
            if (start == null)
            {
                Console.WriteLine("List is empty");
            }
            Console.Write("List is : ");
            p = start;
            while (p != null)
            {
                Console.Write(p.info + " ");
                p = p.link;

            }
            Console.WriteLine();
        }
        public void CountNodes()
        {
            int n = 0;
            Node p = start;
            while (p != null)
            {
                n++;
                p = p.link;
            }
            Console.WriteLine("Number of nodes in the list: " + n.ToString());
        }
        public bool Search(int data)
        {
            int position = 1;
            Node p = start;
            while (p != null)
            {
                if (p.info == data)
                {
                    break;
                }
                position++;
                p = p.link;
            }
            if (p == null)
            {
                Console.WriteLine(data.ToString() + " not found in list");
                return false;
            }
            else
            {
                Console.WriteLine(data.ToString() + " is at position " + position.ToString());
                return true;
            }

        }
        public void InsertInBeginning(int data)
        {
            Node temp = new Node(data);
            temp.link = start;
            start = temp;
        }
        public void InsertAtEnd(int data)
        {
            Node p;
            Node temp = new Node(data);
            if (start == null)
            {
                start = temp;
                return;
            }
            p = start;
            while (p.link != null)
            {
                p = p.link;
            }
            p.link = temp;
        }
        public void InsertAfter(int data, int x)
        {
            Node p = start;
            while (p != null)
            {
                if (p.info == x)
                {
                    break;
                }
                p = p.link;
            }
            if (p == null)
            {
                Console.WriteLine(x + " not present in the list");
            }
            else
            {
                Node temp = new Node(data);
                temp.link = p.link;
                p.link = temp;
            }
        }
        public void InsertBefore(int data, int x)
        {
            Node temp;
            /*If the list is empty*/
            if (start == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            /*x is in first node, new node is to be inserted before first node*/
            if (x == start.info)
            {
                temp = new Node(data);
                temp.link = start;
                start = temp;
            }
            /*Finding reference to predecessor of the node containing x*/
            Node p = start;
            while (p.link != null)
            {
                if (p.link.info == x)
                {
                    break;
                }
                p = p.link;  
            }
            if (p.link == null)
            {
                Console.WriteLine(x + " not present in the list");
            }
            else
            {
                temp = new Node(data);
                temp.link = p.link;
                p.link = temp;
            }
        }
        public void InsertAtPosition(int data, int pos)
        {
            Node temp;
            int i;

            if (pos == 1)
            {
                temp = new Node(data);
                temp.link = start;
                start = temp;
                return;
            }
            Node p = start;
            for (i = 1; i < pos-1 && p != null; i++)/*find a reference to k-1 node*/
            {
                p = p.link;
            }
            if (p == null)
            {
                Console.WriteLine("you can insert only up to " + i + "th position");
            }
            else
            {
                temp = new Node(data);
                temp.link = p.link;
                p.link = temp;
            }
        }
        public void DeleteFirstNode() {
            if (start == null)
            {
                return;
            }
            start = start.link;
        }
        public void DeleteLastNode() {
            if (start == null)
            {
                return;
            }
            if (start.link == null)
            {
                start = null;
                return;
            }
            Node p = start;
            while (p.link.link != null)
            {
                p = p.link;
            }
            p.link = null;
        }
        public void DeleteNode(int x)
        {
            if (start == null)
            {
                Console.WriteLine("The List is empty");
                return;
            }
            /*
             Deletion of first node
             */
            if (start.info == x)
            {
                start = start.link;
                return;    
            }
            /*Deletion in between or at the end*/
            Node p = start;
            while (p.link != null)
            {
                if (p.link.info == x)
                {
                    break;
                }
                p = p.link;
            }
            if (p.link == null)
            {
                Console.WriteLine("Element " + x + " not in the list");
            }
            else
            {
                p.link = p.link.link;
            }
        }
        public void ReverseList() {
            Node prev, p, next;
            prev = null;
            p = start;
            while (p != null)
            {
                next = p.link;
                p.link = prev;
                prev = p;
                p = next;
            }
            start = prev;
        }
        public void BubbleSortExData() {
            Node end, p, q;
            for (end = null; end != start.link; end = p)
            {
                for (p = start; p.link != end; p = p.link)
                {
                    q = p.link;
                    if (p.info > q.info)
                    {
                        int temp = p.info;
                        p.info = q.info;
                        q.info = temp;
                    } 
                }
            }
        }
        public void BubbleSortExLinks() {

            Node end, r, p, q, temp;
            for (end = null; end != start.link; end = p)
            {
                for (r = p = start; p.link != end; r =p, p = p.link)
                {
                    q = p.link;
                    if (p.info > q.info)
                    {
                        p.link = q.link;
                        q.link = p;
                        if (p != start) {
                            r.link = q;
                        }
                        else
                        {
                            start = q;
                        }
                        temp = p;
                        p = q;
                        q = temp;   
                    } 
                }
            }
        }
        public void MergeSort()
        {
            start = MergeSortRec(start);
        }
        private Node MergeSortRec(Node listStart)
        {
            if (listStart == null || listStart.link == null) /*If list emp or has only one node*/
                return listStart;

            /*if more than one element*/
            Node start1 = listStart;
            Node start2 = DivideList(listStart);
            start1 = MergeSortRec(start1);
            start2 = MergeSortRec(start2);
            Node startM = Merge2(start1, start2);
            return startM;
        }
        private Node DivideList(Node p)
        {
            Node q = p.link.link;
            while (q != null && q.link != null)
            {
                p = p.link;
                q = q.link.link;
            }
            Node start2 = p.link;
            p.link = null;
            return start2;
        }
        #region mergesort generate new SingleLinkedList
        public SingleLinkedList Merge1(SingleLinkedList list)
        {
            SingleLinkedList mergeList = new SingleLinkedList();
            mergeList.start = Merge1(start, list.start);
            return mergeList;
        }
        private Node Merge1(Node p1, Node p2)
        {
            Node startM;
            if (p1.info <= p2.info)
            {
                startM = new Node(p1.info);
                p1 = p1.link;
            }
            else
            {
                startM = new Node(p2.info);
                p2 = p2.link;
            }
            Node pM = startM;
            while (p1 != null && p2 != null)
            {
                if (p1.info <= p2.info)
                {
                    pM.link = new Node(p1.info);
                    p1 = p1.link;
                }
                else
                {
                    pM.link = new Node(p2.info);
                    p2 = p2.link;
                }
                pM = pM.link;
            }
            /*If second list has finished and elements left in first list*/
            while (p1 != null)
            {
                pM.link = new Node(p1.info);
                p1 = p1.link;
                pM = pM.link;
            }
            /*If first list has finished and elements left in second list*/
            while (p2 != null)
            {
                pM.link = new Node(p2.info);
                p2 = p2.link;
                pM = pM.link;
            }
            return startM;
        }
        #endregion
        #region MergeSort join the two lists
        public SingleLinkedList Merge2(SingleLinkedList list)
        {
            SingleLinkedList mergeList = new SingleLinkedList();
            mergeList.start = Merge2(start, list.start);
            return mergeList;
        }
        private Node Merge2(Node p1, Node p2)
        {
            Node startM;
            if (p1.info <= p2.info)
            {
                startM = p1;
                p1 = p1.link;
            }
            else
            {
                startM = p2;
                p2 = p2.link;
            }
            Node pM = startM;

            while (p1 != null && p2 != null)
            {
                if (p1.info <= p2.info)
                {
                    pM.link = p1;
                    pM = pM.link;
                    p1 = p1.link;
                }
                else
                {
                    pM.link = p2;
                    pM = pM.link;
                    p2 = p2.link;
                }
            }
            if (p1 == null)
            {
                pM.link = p2;
            }
            else
            {
                pM.link = p1;
            }
            return startM;
        }
        #endregion
       
        
        public void MergeSortTwoLists() {
            SingleLinkedList list1 = new SingleLinkedList();
            SingleLinkedList list2 = new SingleLinkedList();
            list1.CreateList();
            list2.CreateList();
            list1.BubbleSortExData();
            list2.BubbleSortExData();

            Console.WriteLine("First List - ");
            list1.DisplayList();
            Console.WriteLine("Second List - ");
            list2.DisplayList();

            SingleLinkedList list3 = list1.Merge1(list2);
            Console.WriteLine("Merged List - ");
            list3.DisplayList();
            Console.WriteLine("First List - ");
            list1.DisplayList();
            Console.WriteLine("Second List - ");
            list2.DisplayList();

            list3 = list1.Merge2(list2);
            Console.WriteLine("Merged List - ");
            list3.DisplayList();
            Console.WriteLine("First List - ");
            list1.DisplayList();
            Console.WriteLine("Second List - ");
            list2.DisplayList();

        }
        public void InsertCycle(int data) { }
        public bool HasCycle() { return true; }
        public void RemoveCycle() { }
    }
}
