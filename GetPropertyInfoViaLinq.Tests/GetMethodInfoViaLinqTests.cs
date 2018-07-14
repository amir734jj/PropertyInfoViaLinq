using Xunit;

namespace GetPropertyInfoViaLinq.Tests
{
    public class GetMethdoInfoViaLinqTests
    {
        [Fact]
        public void Test__GetMethodInfoViaLinq()
        {
            // Arrange
            const string expected = "ToString";
            
            // Act
            var name = GetMethodInfoViaLinq<string>.FuncName<string>(x => x.ToString);
            
            // Assert
            Assert.Equal(expected, name);
        }
    }
}