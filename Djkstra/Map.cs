using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    public class Map
    {
        private List<Sprite> gridCells;

        private Node[] mapNodes;

        public Level CurrentLevel { get; set; }

        private float padding = 0.0f;

        public Map( Level level )
        {
            CurrentLevel = level;
            gridCells = new List<Sprite>();
            mapNodes = new Node [ level.Columns * level.Rows ];

            for ( int i = 0; i < level.Columns * level.Rows; i++ )
            {
                //add our grid sprite and set the position
                gridCells.Add(new Sprite(1, 1));
                gridCells [ i ].position = new Vector2(( i % level.Columns ) * ( gridCells [ i ].scale.X + padding ), ( i / level.Columns ) * ( gridCells [ i ].scale.Y + padding ));
            }

            // Generate map nodes with it's size
            for ( int y = 0; y < level.Rows; y++ )
            {
                for ( int x = 0; x < level.Columns; x++ )
                {
                    int index = (y * level.Columns) + x;

                    // the cost is set to zero initially
                    mapNodes [ index ] = new Node(level.Cells[index], new OpenTK.Vector2( x * 1.0f, y * 1.0f));
                }
            }

            GenerateNeighborNode();
        }

        private void GenerateNeighborNode()
        {
            for ( int y = 0; y < CurrentLevel.Rows - 1; y++ )
            {
                for ( int x = 0; x < CurrentLevel.Columns; x++ )
                {
                    int index = (y * CurrentLevel.Columns) + x;

                    // Top
                    Node topNode = GetNode(x, y - 1);
                    if ( topNode != null && topNode.Weight != -1 )
                    {
                        mapNodes [ index ].AddNeighbor(topNode);
                    }

                    // Bottom
                    Node bottomNode = GetNode(x, y + 1);
                    if ( bottomNode != null && bottomNode.Weight != -1 )
                    {
                        mapNodes [ index ].AddNeighbor(bottomNode);
                    }

                    // Left
                    Node leftNode = GetNode(x - 1, y);
                    if ( leftNode != null && leftNode.Weight != -1 )
                    {
                        mapNodes [ index ].AddNeighbor(leftNode);
                    }

                    // Right
                    Node rightNode = GetNode(x + 1, y);
                    if ( rightNode != null && rightNode.Weight != -1 )
                    {
                        mapNodes [ index ].AddNeighbor(rightNode);
                    }
                }
            }

            Console.WriteLine("All Neighbors Generated!");
        }

        public Node GetNode(int x, int y)
        {
            if ( x < 0 || x > CurrentLevel.Columns)
                return null;
            if ( y < 0 || y > CurrentLevel.Rows)
                return null;

            int index = (y * CurrentLevel.Columns) + x;

            return mapNodes [ index ];
        }

        public void DrawMap( )
        {
            for ( int i = 0; i < gridCells.Count; i++ )
            {
                gridCells [ i ].DrawSolidColor(0.2f, 0.2f, 0.2f);
            }

            for ( int i = 0; i < mapNodes.Length; i++ )
            {
                mapNodes [ i ]?.PrintNeighbors();
            }
        }
    }
}
