﻿namespace GameManager
{
    using ArenaBase;    
    using Interfaces;
    using System.Linq;

    public class TurnManager : ITurnManager        
    {
        private IMapsContainer _mapContainer;        

        public TurnManager(IMapsContainer mapContainer)
        {
            _mapContainer = mapContainer;
        }   

        public Actor GetNextActor()
        {
            //TODO: add some kind of priority for selecting actors 
            return _mapContainer.Actors.Where(x => !x.TurnFinished).FirstOrDefault();
        }

        public void NextTurn()
        {
            _mapContainer.Actors.ToList().ForEach(x => x.Enegry -= 1000);
        }
    }
}
