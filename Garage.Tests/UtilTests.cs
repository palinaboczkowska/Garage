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

            // Verify GetInput called twice
            mockUI.Verify(ui => ui.GetInput(), Times.Exactly(2));

            // Verify prompt printed twice (once per attempt)
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
        public void AddVehicle_WhenGarageIsFull_ReturnsErrorMessage()
        {
            // Arrange: create a manager with capacity 1 and add a car
            var manager = new Manager(1);
            var car1 = new Car("CAR001", "Blue", 4, "Diesel");
            manager.AddVehicle(car1);

            // Act: try to add another car
            var car2 = new Car("CAR002", "Red", 4, "Petrol");
            string result = manager.AddVehicle(car2);

            // Assert: confirm that the garage full message is returned
            Assert.Equal("Failed to park vehicle CAR002. It may already exist or garage is full.", result);
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

        [Fact]
        public void RemoveVehicle_NonExistingVehicle_ReturnsErrorMessage()
        {
            // Arrange: create a manager with capacity but no vehicles
            var manager = new Manager(2);

            // Act: try to remove a vehicle that does not exist
            string result = manager.RemoveVehicle("CAR999");

            // Assert: confirm that the error message is returned
            Assert.Equal("Vehicle CAR999 not found.", result);
        }

    }
}
