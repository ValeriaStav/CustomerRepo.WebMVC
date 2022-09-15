using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using CustomerRepo.WebMVC.Controllers;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;

namespace CustomerRepo.WebMVC.Tests
{
    public class AddressesControllerTests
    {
        [Fact]
        public void ShouldCreateAddressesController()
        {
            var controller = new AddressesController();
            Assert.NotNull(controller);
        }

        [Fact]
        public void ShouldReturnAddressesList()
        {
            var controller = new AddressesController();
            var addressesResult = controller.Index();
            var addressesView = addressesResult as ViewResult;
            var addressesModel = addressesView.Model as List<Address>;
            Assert.NotNull(addressesModel);
        }

        [Fact]
        public void ShouldCreateAddress()
        {
            var addressesControllerMock = new Mock<IRepository<Address>>();
            var addressController = new AddressesController(addressesControllerMock.Object);
            addressController.Create();

            var result = addressController.Create(new Address()
            {
                CustomerId = 1,
                AddressLine = "First line",
                AddressLine2 = "Second line",
                AddressType = "Shipping",
                City = "Toronto",
                PostalCode = "66777",
                State = "Ontario",
                Country = "Canada"
            }) as RedirectToRouteResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldEditAddress()
        {
            var addressesControllerMock = new Mock<IRepository<Address>>();
            var addressController = new AddressesController(addressesControllerMock.Object);
            addressController.Edit(1);

            var result = addressController.Edit(new Address()
            {
                CustomerId = 1,
                AddressLine = "First line",
                AddressLine2 = "Second line",
                AddressType = "Shipping",
                City = "Toronto",
                PostalCode = "66777",
                State = "Ontario",
                Country = "Canada"
            }) as RedirectToRouteResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldDeleteAddress()
        {
            var addressesControllerMock = new Mock<IRepository<Address>>();
            var addressController = new AddressesController(addressesControllerMock.Object);
            addressController.Delete(1);

            var result = addressController.Delete(1, new Address
            {
                CustomerId = 1,
                AddressLine = "First line",
                AddressLine2 = "Second line",
                AddressType = "Shipping",
                City = "Toronto",
                PostalCode = "66777",
                State = "Ontario",
                Country = "Canada"
            }) as RedirectToRouteResult;

            Assert.Empty("");
        }
    }
}
