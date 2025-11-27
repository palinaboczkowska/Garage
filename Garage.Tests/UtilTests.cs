using Garage.Helpers;
using Moq;


namespace Garage.Tests
{
    public class UtilTests
    {
        [Fact]
        public void AskForInt_ValidInput_ReturnsParsedInteger()
        {
            // Arrange
            const string input = "2";
            var mockUI = new Mock<IUI>();
            mockUI.Setup(ui => ui.GetInput()).Returns(input);

            // Act
            int result = Util.AskForInt("Enter number", mockUI.Object);

            // Assert
            Assert.Equal(2, result);
        }

    }
}
