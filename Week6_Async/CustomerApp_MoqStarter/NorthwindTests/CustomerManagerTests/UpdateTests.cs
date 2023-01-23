using Moq;
using NorthwindBusiness;
using NorthwindData.Services;
using NorthwindData;
using NUnit.Framework;
using System.Data;

namespace NorthwindTests.CustomerManagerTests
{
    public class WhenUpdateIsCalled
    {
        private CustomerManager _sut;

        [Test]
        public void WithValidId_ReturnTrue()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer() { CustomerId = "JSMITH" };

            //We only need to implement the methods we are actually going to use.
            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(originalCustomer);

            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            var result = _sut.Update("JSMITH", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void WithValidIdAndInputs_UpdateCustomer()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer()
            {
                CustomerId = "JSMITH",
                ContactName = "John Smith",
                Country = "UK",
                City = "Birmingham",
                PostalCode = "B99 AB3"
            };

            //We only need to implement the methods we are actually going to use.
            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(originalCustomer);

            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            var result = _sut.Update("JSMITH", "Jonathan Smith", "UK", "London", originalCustomer.PostalCode);

            //Assert
            Assert.That(originalCustomer.ContactName, Is.EqualTo("Jonathan Smith"));
            Assert.That(originalCustomer.City, Is.EqualTo("London"));
        }

        [Test]
        public void WithInvalidId_ReturnFalse()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns((Customer)null);

            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            var result = _sut.Update("JSMITH", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void AndADatabaseExceptionOccurs_ReturnFalse()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(new Customer() { CustomerId = "JSMITH" });
            mockCustomerService.Setup(cs => cs.SaveCustomerChanges()).Throws<DataException>();

            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            var result = _sut.Update("JSMITH", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            //Assert
            Assert.That(result, Is.False);
        }


        [Test]
        public void WithValidId_CallSaveCustomerChangesOnce()
        {
            //Arrange
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer() { CustomerId = "JSMITH" };

            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(originalCustomer);

            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            _sut.Update("JSMITH", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            //Assert
            mockCustomerService.Verify(cs => cs.SaveCustomerChanges(), Times.Once);
        }

        [Test]
        public void IfAllInvocationsArentSetUp_LetsSeeWhatHappens()
        {
            // Arrange
            var mockCustomerService = new Mock<ICustomerService>(MockBehavior.Strict);
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
            mockCustomerService.Setup(cs => cs.SaveCustomerChanges());
            _sut = new CustomerManager(mockCustomerService.Object);
            // Act
            var result = _sut.Update("ROCK", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            // Assert
            Assert.That(result);
        }

    }
}
