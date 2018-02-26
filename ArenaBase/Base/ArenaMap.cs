using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ArenaBase;

namespace ArenaBase
{
    public class ArenaMap : IEnumerable<ArenaTile>
    {
        public ArenaMap()
        {
            Map = new List<ArenaTile>();
        }

        #region IEnumerable
        public IEnumerator<ArenaTile> GetEnumerator()
        {
            return Map.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Map.GetEnumerator();
        }
        #endregion
        
        public List<ArenaTile> Map {get; set;}


        public char[][] GetCharArray()
        {
            var width = Map.Max(x => x.Location.Y) + 1;
            char[][] tilesMap = new char[width][];

            for (int i = 0; i < tilesMap.Count(); i++)
            {
                tilesMap[i] = new char[Map.Where(x => x.Location.Y == i).Max(x => x.Location.X) + 1];
                //   Map.ForEach(x => tilesMap[x.Location.X] = new char[Map.Where(y => x.Location.X == x.Location.X).Max(z => z.Location.Y)]);
            }
            Map.ForEach(x => tilesMap[x.Location.Y][x.Location.X] = x.Icon);
            return tilesMap;
        }

        public BaseTile[][] GetTilesArray()
        {
            var width = Map.Max(x => x.Location.Y) + 1;
            BaseTile[][] tilesMap = new BaseTile[width][];

            for (int i = 0; i < tilesMap.Count(); i++)
            {
                tilesMap[i] = new BaseTile[Map.Where(x => x.Location.Y == i).Max(x => x.Location.X) + 1];
                //   Map.ForEach(x => tilesMap[x.Location.X] = new char[Map.Where(y => x.Location.X == x.Location.X).Max(z => z.Location.Y)]);
            }
            Map.ForEach(x => tilesMap[x.Location.Y][x.Location.X] = x);
            return tilesMap;
        }


    }

}
