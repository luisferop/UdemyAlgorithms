namespace prjDFSRecursiveTime
{
    public class Vertex
    {
        public string Name;
        public int State;
        public int DiscoveryTime;
        public int FinishingTime;
        public Vertex(string name)
        {
            this.Name = name;
        }
    }
}
