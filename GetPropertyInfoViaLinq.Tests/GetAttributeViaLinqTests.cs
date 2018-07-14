using System.ComponentModel.DataAnnotations;
using GetPropertyInfoViaLinq.Interfaces;
using GetPropertyInfoViaLinq.Tests.Models;
using Xunit;
using static GetPropertyInfoViaLinq.Tests.Utilities.PersonUtility;

namespace GetPropertyInfoViaLinq.Tests
{
    public class GetAttributeViaLinqTests
    {
        private readonly IGetPropertyInfoViaLinq<Person> _utility;

        public GetAttributeViaLinqTests()
        {
            _utility = GetPropertyInfoViaLinq<Person>.New();
        }
        
        [Fact]
        public void Test__Basic()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.FirstName);
            const string expected = "Attribute.FirstName";

            // Act
            var result = _utility.Lambda(lambda).GetAttribute<DisplayAttribute>()?.Name;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test__Complex()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.Parents.MotherName);
            const string expected = "Attribute.MotherName";

            // Act
            var result = _utility.Lambda(lambda).GetAttribute<DisplayAttribute>()?.Name;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test__ComplexNested()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.Parents.GreatParents.FirstName);
            const string expected = "Attribute.FirstName";

            // Act
            var result = _utility.Lambda(lambda).GetAttribute<DisplayAttribute>()?.Name;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}