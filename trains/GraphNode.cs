using System.Collections.Generic;

namespace trains
{
    public class GraphNode
    {
        private IList<GraphNode> nodes;

        public IList<GraphNode> Nodes { get { return nodes ?? (nodes = new List<GraphNode>()); } }

        public char Id { get; private set; }

        public GraphNode(char id)
        {
            this.Id = id;
        }
    }
}
