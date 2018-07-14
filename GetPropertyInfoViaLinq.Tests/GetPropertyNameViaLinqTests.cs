using System;
using System.Linq.Expressions;
using GetPropertyInfoViaLinq.Interfaces;
using GetPropertyInfoViaLinq.Tests.Models;
using Xunit;
using static GetPropertyInfoViaLinq.Tests.Utilities.PersonUtility;

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
            const string expected = "Age";

            // Act
            var result = _utility.Lambda(lambda).GetPropertyName();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test__Complex()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.Parents);
            const string expected = "Parents";

            // Act
            var result = _utility.Lambda(lambda).GetPropertyName();

            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Test__Nested()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.Parents.FatherName);
            const string expected = "Parents.FatherName";

            // Act
            var result = _utility.Lambda(lambda).GetPropertyName();

            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Test__ComplexNested()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.Parents.GreatParents.Parents.GreatParents.Parents.MotherName);
            const string expected = "Parents.GreatParents.Parents.GreatParents.Parents.MotherName";

            // Act
            var result = _utility.Lambda(lambda).GetPropertyName();

            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Test__ComplexNestedLeaf()
        {
            // Arrange
            var lambda = LambdaToExp(x => x.Parents.GreatParents.Parents.GreatParents.Parents.GreatParents.Age);
            const string expected = "Parents.GreatParents.Parents.GreatParents.Parents.GreatParents.Age";

            // Act
            var result = _utility.Lambda(lambda).GetPropertyName();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}