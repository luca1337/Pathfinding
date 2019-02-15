using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    public static class AStar
    {
        public static List<Node> ComputePath(Map Map, Vector2 Start, Vector2 End)
        {
            Node start, end;

            try
            {
                start = Map.GetNode((int)Start.X, (int)Start.Y);
                end = Map.GetNode((int)End.X, (int)End.Y);
            }
            catch (Exception e)
            {
                throw e;
            }

            return GetPath(start, end);
        }

        private static List<Node> GetPath(Node Start, Node End)
        {
            List<Node> Path = new List<Node>();

            // Path frontier containing nodes
            Frontier<Node> PathFrontier = new Frontier<Node>();
            PathFrontier.Enqueue(Start, 0);

            Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
            Dictionary<Node, int> costSoFar = new Dictionary<Node, int>();

            cameFrom[Start] = null;
            costSoFar[Start] = 0;

            // minimum cost for the neighbor, in order to build the path..

            while (!PathFrontier.IsEmpty)
            {
                Node currentNode = PathFrontier.Dequeue();

                if (currentNode == End)
                    break;

                for (int i = 0; i < currentNode.Neighbors.Count; i++)
                {
                    int newCost = costSoFar[currentNode] + currentNode.Neighbors[i].Weight;

                    if (!costSoFar.ContainsKey(currentNode.Neighbors[i]) || newCost < costSoFar[currentNode.Neighbors[i]])
                    {
                        costSoFar[currentNode.Neighbors[i]] = newCost;
                        int priority = newCost;
                        PathFrontier.Enqueue(currentNode.Neighbors[i], priority);
                        cameFrom[currentNode.Neighbors[i]] = currentNode;
                    }
                }
            }

            Node current = End;

            while ( current != Start && current != null )
            {
                if (!cameFrom.ContainsKey(current)) return null;
                Path.Add(current);
                current = cameFrom[current];
            }

            Path.Reverse();

            return Path;
        }
    }
}
