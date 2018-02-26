using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArenaBase;

namespace Arena
{
    public class MapBuilder
    {
        public ArenaMap SimpleSquareMap(int width, int height)
        {
            ArenaMap map = new ArenaMap();
            CreateBorderWalls(width, height, map);
           // FillWithFloor(width, height, map);
            return map;

        }

        private void CreateBorderWalls(int width, int height, ArenaMap map)
        {
            for (int i = 0; i < width; i++)
            {
                for(int j=0; j < height; j++)
                {
                    if (i == 0 || i == width-1 || j == 0 || j == height-1)
                    {
                        map.Map.Add(new ArenaTile()
                        {
                            Icon = '#',
                            Location = Coordinates.NewCoord(i, j),
                            Passable = false,
                            Immovable = false,
                            Name = "Stone wall"
                        });
                    }
                    else
                    {
                        map.Map.Add(new ArenaTile()
                        {
                            Icon = '.',
                            Location = Coordinates.NewCoord(i, j),
                            Passable = true,
                            Immovable = false,
                            Name = "Floor"
                        });
                    }
                }
            }
        }

        private void FillWithFloor(int width, int height, ArenaMap map)
        {
            for (int i = 1; i < width-1; i++)
            {
                for (int j = 1; j < height-1; j++)
                {
                    
                }
            }
        }
    }
}
