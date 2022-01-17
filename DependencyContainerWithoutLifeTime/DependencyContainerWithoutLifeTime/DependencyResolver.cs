using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace DependencyContainer
{
    public class DependencyResolver
    {
        DependencyContainer _container;
        public DependencyResolver(DependencyContainer Container)
        {
            _container = Container;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        public object GetService(Type type)
        {
            var dependency = _container.GetDependency(type);
            var constructor = dependency.GetConstructors().Single();
            var parameterInfos = constructor.GetParameters();

            //If service whose instance we want create has some parameter in constructor
            if (parameterInfos.Length > 0)
            {
                object[] parametersInstance = new object[parameterInfos.Length];
                for (int i = 0; i < parameterInfos.Length; i++)
                {
                    //if service has dependency also contain some parameters
                    parametersInstance[i] = GetService(parameterInfos[i].ParameterType);
                }
                return Activator.CreateInstance(dependency, parametersInstance);
            }

            return Activator.CreateInstance(dependency);
        }
    }
}
