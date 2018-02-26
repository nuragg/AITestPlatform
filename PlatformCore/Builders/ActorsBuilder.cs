using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArenaBase;

namespace Arena
{
    public class ActorsBuilder
    {
        public Actor BuildPlayer()
        {
            return new Actor() { 
                Description = "Test Player", 
                DisplayPriority = 3, 
                Icon = '@', 
                Speed = 1, 
                Location = new Coordinates(1,1), 
                Name = "Player", 
                Color = ConsoleColor.DarkBlue, 
                PlayerControlled = true };
        }
    }
}
