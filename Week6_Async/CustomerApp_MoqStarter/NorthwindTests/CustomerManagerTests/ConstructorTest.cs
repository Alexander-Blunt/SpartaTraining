using NUnit.Framework;
using Moq;
using NorthwindBusiness;
using NorthwindData;
using NorthwindData.Services;
using System.Data;

namespace NorthwindTests.CustomerManagerTests
{
    public class CustomerManagerShould
    {
        private CustomerManager _sut;

        [Test]
        public void BeConstructable()
        {
            //Arrange
            var dummyCustomerService = new Mock<ICustomerService>().Object;

            //Act
            _sut = new CustomerManager(dummyCustomerService); //null can also act as a dummy

            //Assert
            Assert.That(_sut, Is.InstanceOf<CustomerManager>());
        }

        

    }
}