using CustomerManagement.BusinessEntities;

namespace CustomerManagement.Interfaces
{
    public interface ICustomerService
    {
        object GetAll();
        void Update(Customer customer);
    }
}