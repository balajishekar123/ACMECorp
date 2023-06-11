using ACMECorp.Model;
using ACMECorp.Repositories;
using AcmeCorpAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;

namespace AcmeCorpAPI.UnitTests
{
    [TestFixture]
    public class CustomersControllerTests
    {
        private CustomersController _controller;
        private CustomerRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new CustomerRepository();
            _controller = new CustomersController(_repository);
        }

        [Test]
        public void GetAllCustomers_ReturnsOkResult()
        {
            // Arrange

            // Act
            var result = _controller.GetAllCustomers();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void GetCustomerById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                Name = "John Doe"
            };
            _repository.Add(customer);

            // Act
            var result = _controller.GetCustomerById(1);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void GetCustomerById_NonexistentId_ReturnsNotFoundResult()
        {
            // Arrange

            // Act
            var result = _controller.GetCustomerById(999);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public void AddCustomer_ValidCustomer_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var customer = new Customer
            {
                Name = "Jane Smith"
            };

            // Act
            var result = _controller.AddCustomer(customer);

            // Assert
            Assert.IsInstanceOf<CreatedAtActionResult>(result);
        }

        [Test]
        public void UpdateCustomer_ExistingId_ValidCustomer_ReturnsNoContentResult()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                Name = "John Doe"
            };
            _repository.Add(customer);

            // Act
            var result = _controller.UpdateCustomer(1, customer);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public void UpdateCustomer_NonexistentId_ReturnsBadRequestResult()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                Name = "John Doe"
            };

            // Act
            var result = _controller.UpdateCustomer(1, customer);

            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public void DeleteCustomer_ExistingId_ReturnsNoContentResult()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                Name = "John Doe"
            };
            _repository.Add(customer);

            // Act
            var result = _controller.DeleteCustomer(1);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public void DeleteCustomer_NonexistentId_ReturnsNoContentResult()
        {
            // Arrange

            // Act
            var result = _controller.DeleteCustomer(1);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }
    }
}
