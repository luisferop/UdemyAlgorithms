namespace prjAdjacencyList
{
    public class EdgeNode
    {
        public VertexNode endVertex;
        public EdgeNode nextEdge;
        public EdgeNode(VertexNode v)
        {
            endVertex = v;
        }
    }
}
