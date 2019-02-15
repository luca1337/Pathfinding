using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    interface IPathfind
    {
        bool IsComputed { get; set; }
        T ComputePath<T>(T Graph, T Start, T Goal);
    }
}
