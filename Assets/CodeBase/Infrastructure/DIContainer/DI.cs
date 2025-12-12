using System;
using System.Collections.Generic;
using Assets.CodeBase.Infrastructure.Services;

namespace Assets.CodeBase.Infrastructure.DIContainer
{
    public class DI
    {        
        private readonly Dictionary<Type, IService> _services = new();

        public void RegisterService<T>(T implementation) where T : IService => 
            _services[typeof(T)] = implementation;

        public T GetService<T>() where T : IService =>
            (T)_services[typeof(T)];
    }
}
