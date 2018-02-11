using System.ComponentModel.DataAnnotations;
using GetPropertyInfoViaLinq.Interfaces;
using Xunit;
using static GetPropertyInfoViaLinq.Tests.Utility;

namespace GetPropertyInfoViaLinq.Tests
{
    public class GetAttributeViaLinq
    {
        private readonly IGetPropertyInfoViaLinq<Person> _utility;

        public GetAttributeViaLinq()
        {
            _utility = new GetPropertyInfoViaLinq<Person>();
        }
        
        [Fact]
        public void Test__Basic()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.FirstName);
            var expected = $"Attribute.FirstName";

            // Act
            var result = (_utility.GetAttribute(lambda, typeof(DisplayAttribute)) as DisplayAttribute)?.Name;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test__Complex()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.Parents.MotherName);
            var expected = "Attribute.MotherName";

            // Act
            var result = (_utility.GetAttribute(lambda, typeof(DisplayAttribute)) as DisplayAttribute)?.Name;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test__ComplexNested()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.Parents.GreatParents.FirstName);
            var expected = $"Attribute.FirstName";

            // Act
            var result = (_utility.GetAttribute(lambda, typeof(DisplayAttribute)) as DisplayAttribute)?.Name;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}