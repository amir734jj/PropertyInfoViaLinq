using System.ComponentModel.DataAnnotations;
using System.Linq;
using GetPropertyInfoViaLinq.Interfaces;
using GetPropertyInfoViaLinq.Tests.Models;
using Xunit;
using static GetPropertyInfoViaLinq.Tests.Utilities.PersonUtility;

namespace GetPropertyInfoViaLinq.Tests
{
    public class GetPropertyInfoViaLinqTests
    {
        private readonly IGetPropertyInfoViaLinq<Person> _utility;

        public GetPropertyInfoViaLinqTests()
        {
            _utility = new GetPropertyInfoViaLinq<Person>();
        }
        
        [Fact]
        public void Test__Basic()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.FirstName);
            var expected = typeof(Person).GetProperties().First(x => x.Name == "FirstName");

            // Act
            var result = _utility.Lambda(lambda).GetPropertyInfo();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test__Complex()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.Parents.MotherName);
            var expected = typeof(NestedPersonInfo).GetProperties().First(x => x.Name == "MotherName");

            // Act
            var result = _utility.Lambda(lambda).GetPropertyInfo();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}