/* This program reads an XML document and creates a graph from the information.
 * Then it creates an adjacency matrix and performs a depth-first and breadth first traversal.
 * It also creates a minimum spanning tree and performs Dijkstra's shortest path after asking
 * for a source node from the user.
 * Walt Wood
 * 29 April 2021
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace GraphsImplementation
{
    class Program
    {
       static void Main(string[] args)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(@"C:\Users\Walt\OneDrive\Desktop\School\Old Classes\Algorithms\Homework\GraphsImplementation\GraphsImplementation\GraphXML.xml");

                Graph g = new Graph();

                XmlNodeList vertexList = xmlDoc.GetElementsByTagName("vertex");
                for (int i = 0; i < vertexList.Count; i++)
                {
                    XmlNode vertex = vertexList.Item(i);
                    XmlElement element = (XmlElement)vertex;

                    _ = ((i == 0) ? g.CreateRoot(element.GetAttribute("name")) : g.CreateNode(element.GetAttribute("name")));

                }

                // Process edge elements
                XmlNodeList edgeList = xmlDoc.GetElementsByTagName("edge");
                List<Node> nodeList = g.AllNodes;
                // edgeList is not iterable, so we are using for loop  
                for (int i = 0; i < edgeList.Count; i++)
                {
                    XmlNode node = edgeList.Item(i);
                    if (node.NodeType == XmlNodeType.Element)
                    {
                        XmlElement eElement = (XmlElement)node;
                        Node n = g.AllNodes.Find(z => z.Name == eElement.GetElementsByTagName("srcNode")[0].InnerText);
                        n.AddEdge(g.AllNodes.Find(y => y.Name == eElement.GetElementsByTagName("destNode")[0].InnerText), Int32.Parse(eElement.GetElementsByTagName("edgeWeight")[0].InnerText));
                    }
                }

                int?[,] adj = g.CreateAdjMatrix();
                PrintMatrix(ref adj, g.AllNodes.Count);
                List<Node> visit = new List<Node>();
                List<Node> mark = new List<Node>();

                Console.Write("Deapth-First Traversal: ");
                DepthFirstTraversal(g, g.AllNodes.First(), visit, mark);
                Console.WriteLine();
                Console.Write("Breadth-First Traversal: ");
                BreadthFirstTraversal(g, g.AllNodes.First());
                Console.Write("\nDepth-First Traversal(Matrix): ");
                DFTAdjMatrix(adj, 3, new bool[adj.Length]);
                Console.Write("\nBreadth-First Traversal(Matrix): ");
                BFTAdjMatrix(adj, 0);
                Console.WriteLine("\n\nMinimum Spanning Tree");
                MSTPrim(adj);
                int source = GetSourceNode();
                Console.WriteLine("\nDijkstra's Shortest Path");
                DijkstrasShortestPath(adj, source);
                Console.ReadKey();

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }            
        }

        private static int GetSourceNode()
        {
            string[] c = new string[7] { "A", "B", "C", "D", "E", "F", "G" };
            string input = String.Empty; 
            bool validInput = false;
            while (!validInput)
            {
                Console.Write("\nEnter A, B, C, D, E, F, or G for the source node: ");
                input = Console.ReadLine();
                if(c.Contains(input))
                    validInput = true;
            }
            int source = -1;
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == input)
                    source = i;
            }
            return source;
        }
        
        private static void DijkstrasShortestPath(int?[,] adj, int source)
        {
            int verticesCount = (int)Math.Sqrt(adj.Length);
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinKey(adj, distance, shortestPathTreeSet);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                {
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(adj[u, v]) && distance[u] != int.MaxValue && distance[u] + adj[u, v] < distance[v])
                        distance[v] = distance[u] + int.Parse(adj[u, v].ToString());                    
                }
            }

            PrintShortestPath(distance, verticesCount, source);
        }

        private static void PrintShortestPath(int[] dist, int n, int source)
        {
            string[] c = new string[7] { "A", "B", "C", "D", "E", "F", "G" };
            Console.Write(String.Format("Destination     Distance "
                      + "from Source({0})\n", c[source]));
            for (int i = 0; i < n; i++)
                Console.Write(c[i] + " \t\t " + dist[i] + "\n");
        }

        private static void MSTPrim(int?[,] adj)
        {
            int numVert = (int)Math.Sqrt(adj.Length);
            int[] parent = new int[numVert];

            int[] key = new int[numVert];

            bool[] mstSet = new bool[numVert];

            for (int i = 0; i < numVert; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < numVert - 1; count++)
            {
                int u = MinKey(adj, key, mstSet);
                mstSet[u] = true;
                for (int v = 0; v < numVert; v++)
                {
                    if (adj[u, v] != 0 && mstSet[v] == false && adj[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = int.Parse(adj[u, v].ToString());
                    }
                }
            }
            PrintMST(adj, parent);
        }

        private static int MinKey(int?[,] adj, int[] key, bool[] mstSet)
        {
            int min = int.MaxValue, minIndex = -1;

            for (int i = 0; i < Math.Sqrt(adj.Length); i++)
            {
                if (mstSet[i] == false && key[i] < min)
                {
                    min = key[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
        private static void PrintMST(int?[,] adj, int[] parent)
        {
            string[] c = new string[7] { "A", "B", "C", "D", "E", "F", "G" };
            Console.WriteLine("Edge \tWeight");
            for (int i = 1; i < Math.Sqrt(adj.Length); i++)
                Console.WriteLine(c[parent[i]] + " - " + c[i] + "\t" + adj[i, parent[i]]);
        }

        private static void DFTAdjMatrix(int?[,] adj, int start, bool[] visit)
        {
            string[] c = new string[7] { "A", "B", "C", "D", "E", "F", "G" };
            Console.Write(c[start] + " ");
            visit[start] = true;
            for(int i = 0; i < Math.Sqrt(adj.Length); i++)
            {
                if (adj[start, i] >= 1 && !visit[i])
                    DFTAdjMatrix(adj, i, visit);
            }
        }

        private static void BFTAdjMatrix(int?[,] adj, int start)
        {
            bool[] visit = new bool[(int)Math.Sqrt(adj.Length)];
            string[] c = new string[7] { "A", "B", "C", "D", "E", "F", "G" };
            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            visit[start] = true;
            int vis;
            while(q.Count > 0)
            {
                vis = q.Peek();
                Console.Write(c[vis] + " ");
                q.Dequeue();

                for(int i = 0; i < Math.Sqrt(adj.Length); i++)
                {
                    if (adj[vis, i] >= 1 && (!visit[i]))
                    {
                        q.Enqueue(i);
                        visit[i] = true;
                    }
                }
            }
        }

        private static void DepthFirstTraversal(Graph g, Node n, List<Node> visit, List<Node> mark)
        {
            visit.Add(n);
            Console.Write(n.Name + " ");
            mark.Add(n);
            foreach(Edge e in n.Edges)
            {
                if (!mark.Contains(e.Child))
                {
                    DepthFirstTraversal(g, e.Child, visit, mark);
                }
            }
        }

        private static void BreadthFirstTraversal(Graph g, Node n)
        {
            List<Node> visit = new List<Node>(), mark = new List<Node>();
            Queue<Node> queue = new Queue<Node>();
            visit.Add(n);
            Console.Write(n.Name + " ");
            mark.Add(n);
            queue.Enqueue(n);

            while (queue.Count > 0)
            {
                Node m = queue.Dequeue();
                foreach(Edge e in m.Edges)
                {
                    if (!mark.Contains(e.Child))
                    {
                        visit.Add(e.Child);
                        Console.Write(e.Child.Name + " ");
                        mark.Add(e.Child);
                        queue.Enqueue(e.Child);
                    }
                }
            }
        }

        private static void PrintMatrix(ref int?[,] matrix, int Count)
        {
            Console.Write("       ");
            for (int i = 0; i < Count; i++)
            {
                Console.Write("{0}  ", (char)('A' + i));
            }

            Console.WriteLine();

            for (int i = 0; i < Count; i++)
            {
                Console.Write("{0} | [ ", (char)('A' + i));

                for (int j = 0; j < Count; j++)
                {
                    if (i == j)
                    {
                        Console.Write(" &,");
                    }
                    else if (matrix[i, j] == null)
                    {
                        Console.Write(" .,");
                    }
                    else
                    {
                        Console.Write(" {0},", matrix[i, j]);
                    }
                }
                Console.Write(" ]\r\n");
            }
            Console.Write("\r\n");
        }
    }
}
