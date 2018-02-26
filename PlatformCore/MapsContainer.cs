using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Arena;
using ArenaBase;
using Interfaces;

namespace Arena
{
    public class MapsContainer : IMapsContainer
    {
        public MapsContainer(ArenaMap arena, ActorsMap actors)
        {
            Arena = arena;
            Actors = actors;
        }

        public ActorsMap Actors { get; set; }

        public ArenaMap Arena { get; set; }


        public BaseTile[][] GetArenaTiles()
        {
            return this.Arena.GetTilesArray();
        }
        public BaseTile[][] GetFinalTiles()
        {
            var arenaTiles = this.GetArenaTiles();
            
            for (int i = 0; i <= 3; i++ ) //priority loop, 0 = lowest, 3 = Player
            {
                foreach (var actor in Actors)
                {
                    if (actor.DisplayPriority ==i)
                    {
                        arenaTiles[actor.Location.Y][actor.Location.X] = actor;
                    }
                }
            }
            return arenaTiles;
        }

        public void  DrawFinalTiles()
        {

        }       

        //TODO: temporary
        public Actor GetPlayer()
        {
            return Actors.OfType<Actor>().ToList().First(x => x.PlayerControlled);
        }
    }
}
