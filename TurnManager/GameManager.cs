namespace GameManager
{
    using Interfaces;

    class GameManager : IGameManager
    {
        private ITurnManager _turnManager;        
        private IConsoleWindowContainer _consoleWindowContainer;     
        private IAIManager _aIManager;        

        public GameManager(IConsoleWindowContainer windows, ITurnManager turns)
        {
            _turnManager = turns;
            _consoleWindowContainer = windows;
        }

        public void Start()
        {
            _consoleWindowContainer.DrawAll();
            Play();
        }

        public void Play()
        {
            for (; ; )
                ManageGame();
        }

        private void ManageGame()
        {
            //var actor = _turnManager.GetNextActor();
            //if (actor != null)
            //{
            //    if (actor.PlayerControlled)
            //    {
            //        while (!actor.TurnFinished)
            //        {
            //            _consoleWindowContainer.ProcessInput();
            //        }
            //    }
            //    else
            //        _aIManager.PlayAI(actor);
            //}
            //else
            //    _turnManager.NextTurn();
            _consoleWindowContainer.ProcessInput();
        }
    }
}
