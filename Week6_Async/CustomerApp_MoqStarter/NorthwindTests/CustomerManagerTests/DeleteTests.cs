using Moq;

namespace NorthwindTests.CustomerManagerTests
{
    public class WhenDeleteIsCalled
    {
        private CustomerManager _sut;

        [Test]
        public void WithValidId_ReturnTrue()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer() { CustomerId = "JSMITH" };

            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(originalCustomer);

            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            var result = _sut.Delete("JSMITH");

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void WithValidId_ContainNullSelectedCustomer()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer() { CustomerId = "JSMITH" };

            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(originalCustomer);

            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            _sut.Delete("JSMITH");

            //Assert
            Assert.That(_sut.SelectedCustomer, Is.Null);
        }

        [Test]
        public void WithInvalidId_ReturnFalse()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns((Customer)null);

            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            var result = _sut.Delete("JSMITH");

            //Assert
            Assert.That(result, Is.False);
        }
    }
}
