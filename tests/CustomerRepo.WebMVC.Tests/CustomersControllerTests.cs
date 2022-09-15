using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using CustomerRepo.WebMVC.Controllers;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;

namespace CustomerRepo.WebMVC.Tests
{
    public class CustomersControllerTests
    {
        [Fact]
        public void ShouldCreateCustomersController()
        {
            var controller = new CustomersController();
            Assert.NotNull(controller);
        }

        [Fact]
        public void ShouldReturnCustomersList()
        {
            var controller = new CustomersController();
            var customersResult = controller.Index();
            var customersView = customersResult as ViewResult;
            var customersModel = customersView.Model as List<Customer>;
            
            Assert.NotNull(customersModel);
        }

        [Fact]
        public void ShouldCreateCustomer()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            var controller = new CustomersController(customerServiceMock.Object);
            controller.Create();

            var result = controller.Create(new Customer()
            {
                FirstName = "Vasia",
                LastName = "Petrov",
                CustomerPhoneNumber = "0987654321",
                CustomerEmail = "edxgtdjyt@jkjk.com",
                TotalPurchaseAmount = 7000
            }) as RedirectToRouteResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldEditCustomer()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            var controller = new CustomersController(customerServiceMock.Object);
            controller.Edit(1);

            var result = controller.Edit(1, new Customer()
            {
                FirstName = "Vasia",
                LastName = "Petrov",
                CustomerPhoneNumber = "0987654321",
                CustomerEmail = "edxgtdjyt@jkjk.com",
                TotalPurchaseAmount = 7000
            }) as RedirectToRouteResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldDeleteCustomer()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            var controller = new CustomersController(customerServiceMock.Object);
            controller.Delete(1);

            var result = controller.Delete(new Customer
            {
                FirstName = "Vasia",
                LastName = "Petrov",
                CustomerPhoneNumber = "0987654321",
                CustomerEmail = "edxgtdjyt@jkjk.com",
                TotalPurchaseAmount = 7000
            }) as RedirectToRouteResult;

            Assert.Empty("");
        }
    }
}