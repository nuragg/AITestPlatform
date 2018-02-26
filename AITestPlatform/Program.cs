namespace AITestPlatform
{
    using Interfaces;
    using GameManager;

    class Program
    {
        static void Main(string[] args)
        {
            IServiceLocator locator = ServiceLocator.GetInstance();
            var manager = locator.GetService<IGameManager>();
            manager.Start();
        }
    }
}
