using AutoFixture;
using GetPropertyInfoViaLinq.Interfaces;
using GetPropertyInfoViaLinq.Tests.Models;
using Xunit;

namespace GetPropertyInfoViaLinq.Tests
{
    public static class GetInfoExtension
    {
        public static object GetValue<T>(this IGetInfo<T> getInfo, T instance) => getInfo.GetPropertyInfo().GetValue(instance);
    }
    
    public class GetInfoExtensionTest
    {
        private readonly GetPropertyInfoViaLinq<Person> _utility;
        
        private readonly Fixture _fixture;

        public GetInfoExtensionTest()
        {
            _utility = GetPropertyInfoViaLinq<Person>.New();
            _fixture = new Fixture();
        }

        [Fact]
        public void Test__GetValue()
        {
            // Arrange
            var person = _fixture.Build<Person>().Without(x => x.Parents).Create();    
            
            // Act, Assert
            Assert.Equal(person.Age, _utility.Lambda(x => x.Age).GetValue(person));
        }
    }
}