using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    public static class LevelManager
    {
        public static Level level;

        public static Level LoadLevel(string levelName)
        {
            level = new Level(levelName);

            string[] lines = File.ReadAllLines(levelName);

            level.Columns = lines.GetLength(0) + 1;

            foreach (string line in lines)
            {
                string[] values = line.Trim().Split(',');

                foreach (string value in values)
                {
                    bool isParsed = int.TryParse(value, out int result);

                    if(isParsed)
                        level.Cells.Add(result);
                }

                level.Rows++;
            }

            return level;
        }
    }

    public class Level
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public List<int> Cells { get; set; }
        public string LevelName { get; set; }

        public Level(string levelName)
        {
            Cells = new List<int>();
            this.LevelName = levelName;
        }
    }
}
