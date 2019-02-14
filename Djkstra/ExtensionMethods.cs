using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Djkstra
{
    public static class ExtensionMethods
    {
        public static Vector2 SumInt(Vector2 v, int val)
        {
            v.X += val;
            v.Y += val;
            return v;
        }
    }
}
