using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djkstra
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

            return Path;
        }
    }
}
