using Moq;
using System.Data;

namespace NorthwindTests.CustomerManagerTests
{
    public class WhenCreateIsCalled
    {
        CustomerManager _sut;

        [Test]
        public void WithValidCustomer_CreateCustomerIsCalledOnce()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            _sut = new CustomerManager(mockCustomerService.Object);

            _sut.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            mockCustomerService.Verify(cs => cs.CreateCustomer(It.IsAny<Customer>()), Times.Once);
        }
    }
}
