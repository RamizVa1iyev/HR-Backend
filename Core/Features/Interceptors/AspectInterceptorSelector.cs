using Castle.DynamicProxy;
using Core.Aspects.Autofac.Exception;
using Core.CCC.Logging.Log4Net.Loggers;
using System.Reflection;

namespace Core.Features.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name, method.GetParameters().Select(p => p.ParameterType).ToArray())
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            if (methodAttributes != null) classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }

    }
}
