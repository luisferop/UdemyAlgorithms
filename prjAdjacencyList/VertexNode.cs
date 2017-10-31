namespace prjAdjacencyList
{
    public class VertexNode
    {
        public string Name;
        public VertexNode nextVertex;
        public EdgeNode firstEdge;

        public VertexNode(string name)
        {
            Name = name;
        }
    }

}
