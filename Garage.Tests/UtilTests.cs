using Garage.Helpers;
using Moq;
using Garage.Vehicles;


namespace Garage.Tests
{
    public class UtilTests
    {
        [Fact]
        public void AskForInt_ValidInput_ReturnsParsedInteger()
        {
            // Arrange: set up a mock UI that returns a valid integer input
            const string input = "2";
            var mockUI = new Mock<IUI>();
            mockUI.Setup(ui => ui.GetInput()).Returns(input);

            // Act
            int result = Util.AskForInt("Enter number", mockUI.Object);

            // Assert: verify that the parsed result matches the expected value
            Assert.Equal(2, result);
        }


        [Fact]
        public void AskForInt_InvalidInput_ShowsErrorAndRetries()
        {
            // Arrange: first invalid, then valid input
            var mockUI = new Mock<IUI>();
            mockUI.SetupSequence(ui => ui.GetInput())
                .Returns("abc")
                .Returns("2");

            // Act
            int result = Util.AskForInt("Enter number", mockUI.Object);

            // Assert: returns parsed value
            Assert.Equal(2, result);

            // Assert: error message printed once on invalid input
            mockUI.Verify(ui => ui.Print(It.Is<string>(s => s.Contains("Invalid input"))), Times.Once);

            // Optional: verify GetInput called twice
            mockUI.Verify(ui => ui.GetInput(), Times.Exactly(2));

            // Optional: verify prompt printed twice (once per attempt)
            mockUI.Verify(ui => ui.Print("Enter number"), Times.Exactly(2));
        }

        [Fact]
        public void AddVehicle_ValidVehicle_ReturnsSuccessMessage()
        {
            // Arrange: Create a manager with capacity and a valid car
            var manager = new Manager(2);
            var car = new Car("CAR001", "Blue", 4, "Diesel");

            // Act: Try to add the vehicle
            string result = manager.AddVehicle(car);

            // Assert: Confirm that the success message is returned
            Assert.Equal("Vehicle CAR001 parked successfully.", result);
        }

        [Fact]
        public void RemoveVehicle_ExistingVehicle_ReturnsSuccessMessage()
        {
            // Arrange: add a vehicle to the manager
            var manager = new Manager(2);
            var car = new Car("CAR001", "Blue", 4, "Diesel");
            manager.AddVehicle(car);

            // Act: remove the vehicle
            string result = manager.RemoveVehicle("CAR001");

            // Assert: success message is returned
            Assert.Equal("Vehicle CAR001 removed successfully.", result);
        }



    }
}
