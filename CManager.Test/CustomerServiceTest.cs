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
            var expectedCustomer = new Customer { Email = "test@test.com" };
            mockRepository.Setup(r => r.GetCustomerByEmail("test@test.com")).Returns(expectedCustomer);

            var service = new CustomerService(mockRepository.Object);
            
            // Act
            var customer = service.GetCustomerByEmail("test@test.com");

            // Assert
            Assert.NotNull(customer);
            Assert.Equal(expectedCustomer.Email, customer.Email);
        }
    }
}
