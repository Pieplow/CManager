using CManager.Core.Models;
using CManager.Infrastructure.Interfaces;
using CManager.Services;
using Moq;

namespace CManager.Test
{
    public class CustomerServiceTest
    {
        [Fact]
        public void CreateCustomer_ReturnsTrue_WhenRepositorySucceeds()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository.Setup(r => r.CreateCustomer(It.IsAny<Customer>())).Returns(true);

            var service = new CustomerService(mockRepository.Object);
            var customer = new Customer { FirstName = "test" };

            // Act
            bool result = service.CreateCustomer(customer);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetCustomerByEmail_ReturnsCustomer_WhenFound()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var expectedCustomer = new Customer { Email = "Rasmus@gmail.com" };

            mockRepository.Setup(r => r.GetCustomerByEmail("Rasmus@gmail.com")).Returns(expectedCustomer);

            var service = new CustomerService(mockRepository.Object);

            // Act
            var customer = service.GetCustomerByEmail("Rasmus@gmail.com");

            // Assert
            Assert.NotNull(customer);
            Assert.Equal(expectedCustomer.Email, customer.Email);
        }
        
        [Fact]
        public void GetCustomerById_ReturnsCustomer_WhenFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            var mockRepository = new Mock<ICustomerRepository>();
            var expectedCustomer = new Customer { Id = id };
            mockRepository.Setup(r => r.GetCustomerById(id)).Returns(expectedCustomer);

            var service = new CustomerService(mockRepository.Object);

            // Act
            var customer = service.GetCustomerById(id);

            // Assert
            Assert.NotNull(customer);
            Assert.Equal(expectedCustomer.Id, customer.Id);
        }

        [Fact]
        public void GetAllCustomers_ReturnsCustomerList_WhenNoError()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var expectedCustomers = new List<Customer>
            {
                new Customer { FirstName = "John" },
                new Customer { FirstName = "Jane" }
            };
            mockRepository.Setup(r => r.GetAllCustomers()).Returns(expectedCustomers);
            var service = new CustomerService(mockRepository.Object);
            // Act
            var customers = service.GetAllCustomers();
            // Assert
            Assert.Equal(2, customers.Count);
        }


        [Fact]
        public void DeleteCustomerByEmail_ReturnsNoCustomer_WhenFound()

        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var Email = "rasmus@gmail.com";

            mockRepository.Setup(r => r.DeleteCustomer(Email)).Returns(true);

            var service = new CustomerService(mockRepository.Object);

            //Act
            var result = service.DeleteCustomer(Email);

            mockRepository.Verify(r => r.DeleteCustomer(Email), Times.Once);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateCustomer_ReturnsTrue_WhenRepositorySucceeds()
        {
            // Arrange
            var id = Guid.NewGuid();
            var mockRepository = new Mock<ICustomerRepository>();
            var existingCustomer = new Customer { FirstName = "OldRasmus", Id = id };

            mockRepository.Setup(r => r.GetCustomerById(id)).Returns(existingCustomer);
            mockRepository.Setup(r => r.UpdateCustomer(id, It.IsAny<Customer>())).Returns(true);

            var service = new CustomerService(mockRepository.Object);

            var updatedCustomer = new Customer { FirstName = "NewRasmus", Id = id };

            // Act
            var result = service.UpdateCustomer(updatedCustomer);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void DeleteAllCustomers_ReturnsTrue_WhenRepositorySucceeds()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository.Setup(r => r.DeleteAllCustomers()).Returns(true);
            var service = new CustomerService(mockRepository.Object);
            // Act
            bool result = service.DeleteAllCustomers();
            // Assert
            Assert.True(result);

        }

        [Fact]
        public void CustomerExists_ReturnsTrue_WhenCustomerExists()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var email = "rasmus@gmail.com";
            mockRepository.Setup(r => r.GetCustomerByEmail(email)).Returns(new Customer { Email = email });
            var service = new CustomerService(mockRepository.Object);
            // Act
            bool exists = service.CustomerExists(email);
            // Assert
            Assert.True(exists);
        }
    }
}