using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djkstra
{
    public static class Dijkstra
    {
        public static List<Node> CompuePath(Map map, Vector2 Start, Vector2 End)
        {
            Node start = map.GetNode((int)Start.X, (int)Start.Y);
            Node end = map.GetNode((int)End.X, (int)End.Y);

            return GetPath(start, end);
        }

        private static List<Node> GetPath(Node Start, Node Goal)
        {
            List<Node> path = new List<Node>();

            // all the nodes are connected each-others, from them we can easly calculate the SPT which is given
            // by the weight of each neighbor compared with each other neighbor, if distance.a < distance.b we choose
            // distance a which is the shortest path.

            // first by start position i have to check each possible neighbor

            // Set the current node as the start where we spawn at and visit it

           /*      
            *           [2]
            *           [▲]
            *       [1]◄[A]►[3]
            *           [▼]
            *           [4]                 [B] -> this is the 'Goal' 
            *          
            *   (((this is the computation to get the next node to move on)))
            *                           ||
            *                           || i.e
            *                           \/
            *          ( [ B.Pos - 3.Pos ] = dist2 ) + 3
            *          ( [ B.Pos - 1.Pos ] = dist0 ) + 1
            *          ( [ B.Pos - 4.Pos ] = dist3 ) + 4
            *          ( [ B.Pos - 2.Pos ] = dist1 ) + 2
            */

            Node currentNode = Start;
            currentNode.Visited = true;

            Node bestNode = currentNode.Neighbors[0];

            for ( int i = 1; i < currentNode.Neighbors.Count; i++ )
            {
                // Uso Dist0 come punto di riferimento x tutte le distanze e lo cmp con gli altri

                if ( currentNode.Neighbors [ i ] == Goal )
                {
                    path.Add(currentNode.Neighbors [ i ]);
                    break;
                }

                if ( currentNode.Neighbors [ i ].Visited || currentNode.Neighbors [ i ] == bestNode )
                {
                    continue;
                }

                float Dist0 = (Goal.Position - bestNode.Position).Length + bestNode.Weight;                       //Distance0 => from bestNode 
                float Dist1 = (Goal.Position - currentNode.Neighbors[i].Position).Length + currentNode.Neighbors[i].Weight;       //Distance1 => from all other nodes

                // Cmp le distanze
                if ( Dist0 <= Dist1 )
                {
                    // Se tra un ciclo sarò alla fine della lista di vicini
                    if ( ( i + 1 ) >= currentNode.Neighbors.Count )
                    {
                        currentNode.Visited = true;
                        currentNode = bestNode;  //my current node is not the best neighbor found!
                        bestNode = currentNode.Neighbors.Where(x => !x.Visited).FirstOrDefault();
                        path.Add(currentNode);
                        i = -1;
                    }
                }
                else // se Dist0 è >= Dist1
                {
                    // Se tra un ciclo sarò alla fine della lista di vicini
                    if ( ( i + 1 ) >= currentNode.Neighbors.Count )
                    {
                        currentNode.Visited = true;
                        currentNode = currentNode.Neighbors[i];  //my current node is not the best neighbor found!
                        bestNode = currentNode.Neighbors.Where(x => !x.Visited).FirstOrDefault();
                        path.Add(currentNode);
                        i = -1;
                        continue;
                    }

                    bestNode = currentNode.Neighbors [ i ];
                }
            }

            return path;
        }
    }
}
