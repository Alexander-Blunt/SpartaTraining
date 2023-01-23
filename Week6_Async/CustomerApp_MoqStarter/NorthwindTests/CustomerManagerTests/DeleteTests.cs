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
        public void WithValidId_CallGetCustomerByIdOnce()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            _sut = new CustomerManager(mockCustomerService.Object);
            var originalCustomer = new Customer() { CustomerId = "JSMITH" };

            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(originalCustomer);

            //Act
            _sut.Delete("JSMITH");

            //Assert
            mockCustomerService.Verify(cs => cs.GetCustomerById(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void WithValidId_CallRemoveCustomerOnce()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            _sut = new CustomerManager(mockCustomerService.Object);
            var originalCustomer = new Customer() { CustomerId = "JSMITH" };

            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(originalCustomer);

            //Act
            _sut.Delete("JSMITH");

            //Assert
            mockCustomerService.Verify(cs => cs.RemoveCustomer(It.IsAny<Customer>()), Times.Once);
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

        [Test]
        public void WithInvalidId_CallGetCustomerByIdOnce()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns((Customer)null);

            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            var result = _sut.Delete("JSMITH");

            //Assert
            mockCustomerService.Verify(cs => cs.GetCustomerById("JSMITH"), Times.Once);
        }

        [Test]
        public void WithInvalidId_DoesNotCallRemoveCustomer()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns((Customer)null);

            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            var result = _sut.Delete("JSMITH");

            //Assert
            mockCustomerService.Verify(cs => cs.RemoveCustomer((Customer)null), Times.Never);
        }
    }
}
