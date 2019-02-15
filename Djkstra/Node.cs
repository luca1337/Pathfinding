using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast2D;

namespace Pathfinding
{
    public class Node
    {
        private Sprite nodeSprite;

        public Vector2 Position { get { return nodeSprite.position; } set { nodeSprite.position = value; } }
        public int Weight;

        private List<Node> neighbors;
        public List<Node> Neighbors { get { return neighbors; } }

        public bool Visited { get; set; }

        public Node(int weight, Vector2 position)
        {
            neighbors = new List<Node>();
            nodeSprite = new Sprite(0.5f, 0.5f);
            this.Weight = weight;
            this.Position = position;
            Visited = false;
        }

        public void AddNeighbor(Node node)
        {
            neighbors.Add(node);
        }

        public void PrintNeighbors()
        {
            for ( int i = 0; i < Neighbors.Count; i++ )
            {
                Neighbors [ i ].DrawNode();
            }
        }

        public void DrawNode()
        {
            nodeSprite.DrawSolidColor(1.0f, 0.0f, 0.0f);
        }
    }
}
