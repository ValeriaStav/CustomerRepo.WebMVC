using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace CustomerManagement.Repositories
{
    public class CustomerRepository : BaseRepository, IRepository<Customer>
    {
        public void Create(Customer entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO Customer (FirstName, LastName, CustomerPhoneNumber, CustomerEmail, TotalPurchaseAmount)" +
                    "VALUES (@FirstName, @LastName, @CustomerPhoneNumber, @CustomerEmail, @TotalPurchaseAmount)", connection);

                var firstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
                {
                    Value = entity.FirstName
                };
                var lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
                {
                    Value = entity.LastName
                };
                var customerPhoneNumberParam = new SqlParameter("@CustomerPhoneNumber", SqlDbType.NVarChar, 15)
                {
                    Value = entity.CustomerPhoneNumber
                };
                var customerEmailParam = new SqlParameter("@CustomerEmail", SqlDbType.NVarChar, 50)
                {
                    Value = entity.CustomerEmail
                };
                var totalPurchaseAmountParam = new SqlParameter("@TotalPurchaseAmount", SqlDbType.Int)
                {
                    Value = entity.TotalPurchaseAmount
                };

                command.Parameters.Add(firstNameParam);
                command.Parameters.Add(lastNameParam);
                command.Parameters.Add(customerPhoneNumberParam);
                command.Parameters.Add(customerEmailParam);
                command.Parameters.Add(totalPurchaseAmountParam);

                command.ExecuteNonQuery();
            }
        }

        public Customer Read(int entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Customer WHERE CustomerId = @CustomerId", connection);
                
                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = entity
                };

                command.Parameters.Add(customerIdParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Customer
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            CustomerPhoneNumber = reader["CustomerPhoneNumber"].ToString(),
                            CustomerEmail = reader["CustomerEmail"].ToString(),
                            TotalPurchaseAmount = Convert.ToInt32(reader["TotalPurchaseAmount"])
                        };
                    }
                }   
                return null;
            }
        }

        public void Update(Customer entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("UPDATE Customer SET " +
                    "FirstName = @FirstName, " +
                    "LastName = @LastName, " +
                    "CustomerPhoneNumber = @CustomerPhoneNumber, " +
                    "CustomerEmail = @CustomerEmail, " +
                    "TotalPurchaseAmount = @TotalPurchaseAmount " +
                    "WHERE CustomerId = @CustomerId", connection);

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = entity.CustomerId
                };
                var firstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
                {
                    Value = entity.FirstName
                };
                var lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
                {
                    Value = entity.LastName
                };
                var customerPhoneNumberParam = new SqlParameter("@CustomerPhoneNumber", SqlDbType.NVarChar, 15)
                {
                    Value = entity.CustomerPhoneNumber
                };
                var customerEmailParam = new SqlParameter("@CustomerEmail", SqlDbType.NVarChar, 50)
                {
                    Value = entity.CustomerEmail
                };
                var totalPurchaseAmountParam = new SqlParameter("@TotalPurchaseAmount", SqlDbType.Int)
                {
                    Value = entity.TotalPurchaseAmount
                };

                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(firstNameParam);
                command.Parameters.Add(lastNameParam);
                command.Parameters.Add(customerPhoneNumberParam);
                command.Parameters.Add(customerEmailParam);
                command.Parameters.Add(totalPurchaseAmountParam);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Customer WHERE CustomerId = @CustomerId", connection);

                var lastNameParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = entity
                };

                command.Parameters.Add(lastNameParam);

                command.ExecuteNonQuery();
            }
        }

        public int GetID()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT CustomerId FROM Customer", connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["CustomerId"]);
                }
                return 0;
            }
        }

        public List<Customer> GetAll()
        {
            var customers = new List<Customer>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Customer", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            CustomerPhoneNumber = reader["CustomerPhoneNumber"].ToString(),
                            CustomerEmail = reader["CustomerEmail"].ToString(),
                            TotalPurchaseAmount = Convert.ToInt32(reader["TotalPurchaseAmount"])
                        });
                    }
                }

                return customers;
            }
        }

        public void DeleteAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var deleteAddressesCommand = new SqlCommand(
                    "DELETE FROM Address", connection);
                deleteAddressesCommand.ExecuteNonQuery();

                var command = new SqlCommand(
                    "DELETE FROM Customer", connection);

                command.ExecuteNonQuery();
            }
        }
    }
}
