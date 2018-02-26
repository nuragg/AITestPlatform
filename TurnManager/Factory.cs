namespace GameManager
{
    using Arena;
    using ArenaBase;
    using ConsoleUI;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    class Factory
    {
        public Func<IMapsContainer> CreateMapsContainer { get; set; }
        public Func<ITurnManager> CreateTurnManager { get; set; }
        public Func<IConsoleWindowContainer> CreateConsoleWindowContainer { get; set; }
        public Func<IGameManager> CreateGameManager { get; set; }

        public Factory()
        {
            this.CreateMapsContainer = () => new MapsContainer(new ArenaBase.ArenaMap(), new ArenaBase.ActorsMap());
            this.CreateTurnManager = () => new TurnManager(this.CreateMapsContainer());
            this.CreateConsoleWindowContainer = () => this.CreateTestWindows();
            this.CreateGameManager = () => new GameManager(this.CreateTestWindows(), this.CreateTurnManager());
        }

        //TODO: zaimplementowac buildera

        private IConsoleWindowContainer CreateTestWindows()
        {
            Console.SetWindowSize(230, 60);
            ConsoleWindowContainer WindowContainer = new ConsoleWindowContainer();

            List<ConsoleWindowBase> windows = new List<ConsoleWindowBase>();

            ConsoleTextWindow topWindow = new ConsoleTextWindow(WindowType.TopMsg);
            topWindow.Location = Coordinates.NewCoord(0, 0);
            topWindow.DrawBorder = true;
            topWindow.BorderSymbol = '*';
            topWindow.Height = 5;
            topWindow.Enabled = true;
            topWindow.Width = Console.WindowWidth;


            ConsoleTextField field1 = new ConsoleTextField();
            field1.Location = new Coordinates(1, 1);
            field1.Color = System.ConsoleColor.Cyan;
            field1.Msg = "TEST";

            topWindow.FieldList.Add(field1);


            ConsoleTextWindow bottomWindow = new ConsoleTextWindow(WindowType.BottomWindow);
            bottomWindow.Location = Coordinates.NewCoord(0, 41);
            bottomWindow.DrawBorder = true;
            bottomWindow.BorderSymbol = '*';
            bottomWindow.Height = 5;
            bottomWindow.Enabled = true;
            bottomWindow.Width = Console.WindowWidth;

            ConsoleTextField field2 = new ConsoleTextField();
            field2.Location = new Coordinates(1, 1);
            field2.Color = System.ConsoleColor.Cyan;


            bottomWindow.FieldList.Add(field2);



            var Player = new ActorsBuilder().BuildPlayer();
            var ActorMaps = new ActorsMap();
            ActorMaps.Map.Add(Player);



            MapsContainer container = new MapsContainer(new MapBuilder().SimpleSquareMap(80, 30), ActorMaps);
            ConsoleMapWindow mapWindow = new ConsoleMapWindow(WindowType.Arena, container);
            mapWindow.Active = true;
            mapWindow.Enabled = true;
            mapWindow.Location = new Coordinates(20, 8);

            windows.Add(mapWindow);
            windows.Add(topWindow);
            windows.Add(bottomWindow);

            WindowContainer.WindowList = windows;

            return WindowContainer;

        }
    }
}
