using Moq;
using System.Collections.Generic;

namespace NorthwindTests.CustomerManagerTests
{
    public class WhenRetrieveAllIsCalled
    {
        private CustomerManager _sut;

        [Test]
        public void AndCustomersExist_ReturnCustomerList()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var CustomerList = new List<Customer>() {
                new Customer(),
                new Customer()
            };
            mockCustomerService.Setup(cs => cs.GetCustomerList()).Returns(CustomerList);
            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            var result = _sut.RetrieveAll();

            //Assert
            Assert.That(result, Is.EqualTo(CustomerList));
        }

        [Test]
        public void AndNoCustomersExist_ReturnEmptyList()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var CustomerList = new List<Customer>() { };
            mockCustomerService.Setup(cs => cs.GetCustomerList()).Returns(CustomerList);
            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            var result = _sut.RetrieveAll();

            //Assert
            Assert.That(result, Is.Empty);
        }
    }
}
