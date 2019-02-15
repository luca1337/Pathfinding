using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    public class Frontier<T> where T : class
    {
        private Dictionary<T, int> items;

        public Frontier()
        {
            items = new Dictionary<T, int>();
        }

        public void Enqueue(T item, int priority)
        {
            items[item] = priority;
        }

        public T Dequeue()
        {
            int bestPriority = int.MaxValue;
            T bestItem = default(T);
            foreach (T key in items.Keys)
            {
                if (items[key] < bestPriority)
                {
                    bestItem = key;
                    bestPriority = items[key];
                }
            }

            items.Remove(bestItem);
            return bestItem;
        }

        public bool IsEmpty
        {
            get
            {
                return items.Count == 0;
            }
        }
    }
}