using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Window window = new Window(800, 600, "ciaone");
            window.SetDefaultOrthographicSize(10);

            Map mainMap = new Map( LevelManager.LoadLevel("Assets/Levels/level1.dat") );

            Vector2 Start = new Vector2(1.0f, 1.0f);
            Vector2 End = new Vector2(6.0f, 5.0f);

            Beast beast = new Beast(mainMap, End, Start);

            while (window.opened)
            {
                beast.Move(window.deltaTime);

                mainMap.DrawMap();

                beast.Draw();

                window.Update();
            }
        }
    }
}
