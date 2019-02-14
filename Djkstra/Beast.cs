﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast2D;

namespace Djkstra
{
    public class Beast
    {
        private Sprite sprite;

        public Vector2 Position { get => sprite.position; set => sprite.position = value; }

        private List<Node> path;

        public Beast( Map map, Vector2 Goal, Vector2 Position )
        {
            sprite = new Sprite(1, 1);
            this.Position = Position;

            path = Dijkstra.CompuePath(map, Position, Goal);
        }

        public void Move( float deltaTime)
        {
            if(path.Count > 0)
            {
                Vector2 targetPos = path[0].Position;
                if ( targetPos != this.Position )
                {
                    Vector2 direction = (targetPos - this.Position).Normalized();
                    this.Position += direction * 0.5f * deltaTime;
                }

                float distance = (targetPos - this.Position).Length;

                if ( distance <= 0.1f )
                {
                    Console.WriteLine("Arrived at: {0}", path.ElementAt(0).Position);
                    path.RemoveAt(0);
                }
            }
            else
            {
                Console.WriteLine("arrived at destination");
            }
        }

        public void Draw()
        {
            sprite.DrawSolidColor(1.0f, 1.0f, 1.0f);
        }
    }
}
