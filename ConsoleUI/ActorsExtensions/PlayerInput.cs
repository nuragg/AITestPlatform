using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArenaBase;
using Arena;

namespace ConsoleUI
{
    public static class ActorInput
    {
        private static Actor _currentActor;
        private static string _currentMsg;
        private const string _moveUp = @"You move up";
        private const string _moveDown = @"You move down";
        private const string _moveLeft = @"You move left";
        private const string _moveRight = @"You move right";

        public static InputResponse ProcessArenaInput(this Actor Actor, ConsoleKey Key, MapsContainer Maps)
        {
            _currentActor = Actor;
            InputResponse response = new InputResponse();
            response.MsgWindowType = WindowType.TopMsg;
            response.Actor = _currentActor;
            response.Redraw = true;
            MoveActor(Actor, Key, Maps, response);           
            return response;
        }

        private static void MoveActor(Actor Actor, ConsoleKey Key, MapsContainer Maps, InputResponse Response)
        {
            switch (Key)
            {
                case ConsoleKey.W:                 
                case ConsoleKey.S:                 
                case ConsoleKey.A:                 
                case ConsoleKey.D:
                    Move(Actor, Response, Maps, Key);
                    break;
                default:
                    return;
            }
        }

        private static void Move(Actor Actor, InputResponse Response, MapsContainer Maps, ConsoleKey Key)
        {            
            var newCoord = GetNewCoordination(Coordinates.NewCoord(Actor.Location.X, Actor.Location.Y), Key);
            _currentMsg = _moveUp;
            var tile = CheckMovement(newCoord, Maps) as ArenaTile;

            if (tile.Passable)
            {
                MoveActorToLocation(newCoord);
                Response.Msg = "You move";
            }
            else
                Response.Msg = string.Format("You hit a {0}", tile.Name);
        }

        private static Coordinates GetNewCoordination(Coordinates newCoord, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                    newCoord.Y--;
                    break;
                
                case ConsoleKey.S:
                    newCoord.Y++;
                    break;

                case ConsoleKey.A:
                    newCoord.X--;
                    break;

                case ConsoleKey.D:
                    newCoord.X++;
                    break;

                default:
                    new IndexOutOfRangeException(string.Format("Uknown direction: {0}", key));
                    break;                    
            }
            return newCoord;
        }     

        private static void MoveActorToLocation(Coordinates Location)
        {
            _currentActor.Location = Location;          
        }

        private static BaseTile CheckMovement(Coordinates Location, MapsContainer Maps)
        {
            var tile = CheckPassable(Location, Maps);
            var actor = CheckUnoccupied(Location, Maps);

            if (actor != null)
                return actor;
            else
                return tile;
        }

        private static BaseTile CheckPassable(Coordinates Location, MapsContainer Maps)
        {
            var tile = Maps.Arena.Map.First(x => x.Location == Location);
            return tile;// if (tile.Passable)
            //    return true;
            //else
            //{
            //    _currentMsg = String.Format("You hit a {0}", tile.Name);
            //    return false;
            //}
        }

        private static BaseTile CheckUnoccupied(Coordinates Location, MapsContainer Maps)
        {
            var tile = Maps.Actors.Map.FirstOrDefault(x => x.Location == Location);
            //bool unoccupied = !Maps.Actors.Map.Any(x => x.Location == Location);
            return tile;
        }
    }
}
