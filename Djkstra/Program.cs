using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> map = new List<int>()
            {
                -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
                -1,00,15,00,00,00,00,00,00,-1,
                -1,01,00,12,00,00,00,00,00,-1,
                -1,00,00,00,12,00,06,00,00,-1,
                -1,00,00,00,-1,-1,-1,00,00,-1,
                -1,00,00,00,00,00,00,00,00,-1,
                -1,00,00,00,00,00,00,00,00,-1,
                -1,00,00,00,00,00,00,00,00,-1,
                -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
            };

            Window window = new Window(800, 600, "ciaone");
            window.SetDefaultOrthographicSize(10);

            Map mainMap = new Map(map, 10, 9);

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
