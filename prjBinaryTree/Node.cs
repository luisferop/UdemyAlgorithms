namespace prjBinaryTree
{
    public class Node
    {
        public Node lChild;
        public Node rChild;
        public char info;
        public Node(char n)
        {
            info = n;
            lChild = null;
            rChild = null;
        }     
    }
}
