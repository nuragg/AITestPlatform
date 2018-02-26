using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using ArenaBase;

namespace ArenaBase
{
    public class ActorsMap : IEnumerable<Actor>
    {
        public ActorsMap()
        {
            Map = new List<Actor>();
        }

        #region IEnumerable
        public IEnumerator<Actor> GetEnumerator()
        {
            return Map.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Map.GetEnumerator();
        }
        #endregion

        public Actor GetPlayer()
        {
            return Map.OfType<Actor>().FirstOrDefault(x => x.PlayerControlled);
        }

        public List<Actor> Map { get; set; }
    }
}
