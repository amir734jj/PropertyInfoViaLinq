using System;
using System.Linq.Expressions;
using GetPropertyInfoViaLinq.Interfaces;
using GetPropertyNameViaLinq;
using Xunit;
using static GetPropertyInfoViaLinq.Tests.Utility;

namespace GetPropertyInfoViaLinq.Tests
{
    public class GetPropertyNameViaLinqTests
    {
        private readonly IGetPropertyInfoViaLinq<Person> _utility;

        public GetPropertyNameViaLinqTests()
        {
            _utility = new GetPropertyInfoViaLinq<Person>();
        }

        [Fact]
        public void Test__Basic()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.Age);
            var expected = "Age";

            // Act
            var result = _utility.GetPropertyName(lambda);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test__Complex()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.Parents);
            var expected = "Parents";

            // Act
            var result = _utility.GetPropertyName(lambda);

            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Test__Nested()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.Parents.FatherName);
            var expected = "Parents.FatherName";

            // Act
            var result = _utility.GetPropertyName(lambda);

            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Test__ComplexNested()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.Parents.GreatParents.Parents.GreatParents.Parents.MotherName);
            var expected = "Parents.GreatParents.Parents.GreatParents.Parents.MotherName";

            // Act
            var result = _utility.GetPropertyName(lambda);

            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Test__ComplexNestedLeaf()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.Parents.GreatParents.Parents.GreatParents.Parents.GreatParents.Age);
            var expected = "Parents.GreatParents.Parents.GreatParents.Parents.GreatParents.Age";

            // Act
            var result = _utility.GetPropertyName(lambda);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}