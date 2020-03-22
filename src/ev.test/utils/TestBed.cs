using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace ev.test.utils
{
    public static class TestBed
    {
        public static IServiceProvider Create<T>(MockBehavior mockBehavior = MockBehavior.Loose, Action<IServiceCollection> action = null)
            where T : class
        {
            var sc = new ServiceCollection();

            action?.Invoke(sc);

            var inputType = typeof(T);

            //take one with lergest list of params
            var constructor = inputType.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Count())
                .FirstOrDefault();

            if (constructor == null)
            {
                throw new Exception($"Constructor not found for type {inputType.FullName}");
            }

            var method = typeof(Mock).GetMethod("Of",new Type[] { typeof(MockBehavior) });

            foreach (var param in constructor.GetParameters())
            {
                sc.AddSingleton(
                    param.ParameterType, 
                    sp => method.MakeGenericMethod(param.ParameterType).Invoke(null,new object[] { mockBehavior })
                );
            }

            sc.AddSingleton<T>();

            return sc.BuildServiceProvider();
        }
    }
}