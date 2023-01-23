﻿using Moq;
using NorthwindBusiness;
using NorthwindData.Services;
using NorthwindData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTests.CustomerManagerTests
{
    public class WhenSetSelectedCustomerIsCalled
    {
        CustomerManager _sut;
        [SetUp]
        public void Setup()
        {
            var dummyCustomerService = new Mock<ICustomerService>().Object;
            _sut = new CustomerManager(dummyCustomerService);
        }

        [Test]
        public void WithAValidCustomer_ThatCustomerIsSelected()
        {
            var customer = new Customer();

            _sut.SetSelectedCustomer(customer);

            Assert.That(_sut.SelectedCustomer, Is.EqualTo(customer));
        }

        [Test]
        public void WithANonCustomer_AnInvalidCastExceptionIsThrown()
        {
            var customer = new Object();

            Assert.That(() => _sut.SetSelectedCustomer(customer), Throws.TypeOf<InvalidCastException>());
        }
    }
}
