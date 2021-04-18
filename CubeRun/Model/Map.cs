using System;
using System.Collections.Generic;
using System.Drawing;

namespace CubeRun.Model
{
    public class Map
    {
        private readonly List<List<MapEntity>> mathMap = new List<List<MapEntity>>();
        public readonly Point Start;
        

        public Map(string stringMap)
        {
            var slice = new List<MapEntity>();
            foreach (var obj in stringMap)
            {
                switch (obj)
                {
                    case '\n':
                        mathMap.Add(slice);
                        slice = new List<MapEntity>();
                        break;

                    case '.':
                        slice.Add(MapEntity.Block);
                        break;
                    
                    case ' ':
                        slice.Add(MapEntity.Empty);
                        break;
                }
            }
            Start = new Point(mathMap.Count - 2, 0);
        }

        public Point? GetFloor(int x)
        {
            for (var i = mathMap.Count; i >= 0; i--)
            {
                if (mathMap[i][x] == MapEntity.Empty)
                {
                    return new Point(x, i);
                }
            }
            return null;
        }

        public void WriteMap()
        {
            foreach (var bytes in mathMap)
            {
                foreach (var b in bytes)
                {
                    Console.Write(b);
                }
                Console.WriteLine();
            }
        }

        enum MapEntity
        {
            Empty,
            Block,
        }
    }
}