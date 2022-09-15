using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using CustomerManagement.Repositories;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<Notes> _noteRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
            _addressRepository = new AddressRepository();
            _noteRepository = new NoteRepository();
        }

        public CustomerService(IRepository<Customer> customerRepository,
            IRepository<Address> addressRepository = null, IRepository<Notes> noteRepository = null)
        {
            _customerRepository = customerRepository;
            _addressRepository = new AddressRepository();
            _noteRepository = new NoteRepository();
        }

        public object GetAll(int entity)
        {
            if (entity == 0)
                throw new ArgumentNullException(nameof(entity));

            Customer customer;
            int tries = 0;

            while (true)
            {
                try
                {
                    customer = _customerRepository.Read(entity);

                    if (entity != 0)
                    {
                        var addresses = _addressRepository;
                        customer.Addresses = (List<Address>)addresses;
                    }

                    break;
                }
                catch (TimeoutException e)
                {
                    tries++;

                    if (tries > 3)
                    {
                        throw e;
                    }
                }
            }

            if (customer == null)
                throw new KeyNotFoundException();

            return customer;
        }

        public Customer Create(Customer customer)
        {
            _customerRepository.Create(customer);

            return customer;
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }
    }
}