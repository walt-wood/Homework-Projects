using System;
using System.Collections.Generic;
using System.Text;

namespace GraphsImplementation
{
    class Node
    {
        public string Name = String.Empty;
        public List<Edge> Edges = new List<Edge>();

        public Node(string name)
        {
            Name = name;
        }

        public Node AddEdge(Node child, int weight)
        {
            Edges.Add(new Edge { 
                Parent = this,
                Child = child,
                Weight = weight });
            
            return this;
        }
    }
}
