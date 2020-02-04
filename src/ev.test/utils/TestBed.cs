using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace ev.test.utils
{
    public static class TestBed
    {
        public static IServiceProvider Create<T>(MockBehavior mockBehavior = MockBehavior.Loose)
            where T: class
        {
            var sc = new ServiceCollection();

            var inputType = typeof(T);

            //take one with lergest list of params
            var constructor = inputType.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Count())
                .FirstOrDefault();

            if (constructor == null)
            {
                throw new Exception($"Constructor not found for type {inputType.FullName}");
            }

            var mockRepo = new MockRepository(mockBehavior);

            foreach(var param in constructor.GetParameters())
            {
                // if(param.ParameterType.IsGenericType)
                // {
                //     continue;
                // }
                var t = param.ParameterType.FullName;
                Console.WriteLine(t);
            }

            return sc.BuildServiceProvider();
        }
    }
}