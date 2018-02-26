namespace GameManager
{
    using Interfaces;
    using System;
    using System.Collections.Generic;

    public class ServiceLocator : IServiceLocator
    {
        private Dictionary<object, object> _services;
        private static ServiceLocator instance = null;
        private Factory _factory;

        public ServiceLocator()
        {
            _factory = new Factory();
            _services = new Dictionary<object, object>();         
            _services.Add(typeof(IMapsContainer), _factory.CreateMapsContainer());
            _services.Add(typeof(ITurnManager), _factory.CreateTurnManager());
            _services.Add(typeof(IGameManager), _factory.CreateGameManager());
        }

        public T GetService<T>()
        {
            try
            {
                return (T)_services[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("Not registered");
            }
        }

        public static ServiceLocator GetInstance()
        {
            return instance ?? new ServiceLocator();
        }
    }
}
