using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace ev.test
{
    public static class TestUtil
    {
        
        public static IServiceProvider GetServiceProvider<T>(MockBehavior mb = MockBehavior.Loose)
            where T: class
        {
            var type = typeof(T);
            var constructor = type
                .GetConstructors()
                .ToList()
                .OrderByDescending(i => i.GetParameters().Length)
                .First();
            
            var sc = new ServiceCollection();
            
            var mockRepo = new MockRepository(mb);
            var createMockMethod = typeof(MockRepository)
                .GetMethods()
                .First(m => m.IsGenericMethod && m.Name == "Create");

            foreach (var p in constructor.GetParameters())
            {
                var createConcrete = createMockMethod.MakeGenericMethod(p.ParameterType);
                
                var mock = createConcrete.Invoke(mockRepo, null);
                sc.AddSingleton(mock.GetType(),mock);
                
                var mockObjProp = typeof(Mock<>)
                    .MakeGenericType(p.ParameterType)
                    .GetProperties()
                    .First(mp => mp.Name == "Object");

                
                var mockObj = mockObjProp.GetValue(mock);
                sc.AddSingleton(p.ParameterType,mockObj);
            }
            
            sc.AddSingleton<T>();

            return sc.BuildServiceProvider();
        }
    }
}