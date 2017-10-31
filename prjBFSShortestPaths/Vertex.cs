namespace prjBFSShortestPaths
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
