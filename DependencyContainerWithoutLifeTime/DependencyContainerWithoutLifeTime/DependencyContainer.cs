using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DependencyContainer
{
    public class DependencyContainer
    {
        private List<Type> _listOfDependencies = null;
        public DependencyContainer()
        {
            
        }

        public void AddDependency(Type type)
        {
            if(_listOfDependencies==null)
            {
                _listOfDependencies = new List<Type>();
            }

            _listOfDependencies.Add(type);
        }
        public void AddDependency<T>()
        {
            if (_listOfDependencies == null)
            {
                _listOfDependencies = new List<Type>();
            }

            _listOfDependencies.Add(typeof(T));
        }

        public Type GetDependency(Type type)
        {
            return _listOfDependencies.First(x => x.Name == type.Name);
        }
    }
}
