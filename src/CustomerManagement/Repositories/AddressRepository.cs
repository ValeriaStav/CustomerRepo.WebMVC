using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CustomerManagement.Repositories
{
    public class AddressRepository : BaseRepository, IRepository<Address>
    {
        public void Create(Address address)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO Address (CustomerId, AddressLine, AddressLine2, AddressType, City, PostalCode, State, Country)" +
                    "VALUES (@CustomerId, @AddressLine, @AddressLine2, @AddressType, @City, @PostalCode, @State, @Country)", connection);

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = address.CustomerId
                };
                var addressLineParam = new SqlParameter("@AddressLine", SqlDbType.NVarChar, 100)
                {
                    Value = address.AddressLine
                };
                var addressLine2Param = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100)
                {
                    Value = address.AddressLine2
                };
                var addressTypeParam = new SqlParameter("@AddressType", SqlDbType.NVarChar, 8)
                {
                    Value = address.AddressType
                };
                var cityParam = new SqlParameter("@City", SqlDbType.NVarChar, 50)
                {
                    Value = address.City
                };
                var postalCodeParam = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 6)
                {
                    Value = address.PostalCode
                };
                var stateParam = new SqlParameter("@State", SqlDbType.NVarChar, 20)
                {
                    Value = address.State
                };
                var countryParam = new SqlParameter("@Country", SqlDbType.NVarChar, 30)
                {
                    Value = address.Country
                };

                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(addressLineParam);
                command.Parameters.Add(addressLine2Param);
                command.Parameters.Add(addressTypeParam);
                command.Parameters.Add(cityParam);
                command.Parameters.Add(postalCodeParam);
                command.Parameters.Add(stateParam);
                command.Parameters.Add(countryParam);

                command.ExecuteNonQuery();
            }
        }

        public Address Read(int entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM Address WHERE AddressLine = @AddressLine", connection);

                var addressLineParam = new SqlParameter("@AddressLine", SqlDbType.Int) { Value = entity };

                command.Parameters.Add(addressLineParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Address
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            AddressLine = reader["AddressLine"].ToString(),
                            AddressLine2 = reader["AddressLine2"].ToString(),
                            AddressType = reader["AddressType"].ToString(),
                            City = reader["City"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            State = reader["State"].ToString(),
                            Country = reader["Country"].ToString()
                        };
                    }
                }

                return null;
            }
        }

        public void Update(Address entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE [Address] SET CustomerId = @CustomerId, AddressLine = @AddressLine, AddressLine2 = @AddressLine2, AddressType = @AddressType, City= @City, PostalCode = @PostalCode, State = @State, Country = @Country WHERE AddressId = @AddressId", connection);

                var addressIdParam = new SqlParameter("@AddressId", SqlDbType.Int) { Value = entity.AddressId };
                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int) { Value = entity.CustomerId };
                var addresLineParam = new SqlParameter("@AddressLine", SqlDbType.NVarChar, 100) { Value = entity.AddressLine };
                var addresLine2Param = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100) { Value = entity.AddressLine2 };
                var addresTypeParam = new SqlParameter("@AddressType", SqlDbType.NVarChar, 20) { Value = entity.AddressType };
                var cityParam = new SqlParameter("@City", SqlDbType.NVarChar, 50) { Value = entity.City };
                var postalCodeParam = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 6) { Value = entity.PostalCode };
                var stateParam = new SqlParameter("@State", SqlDbType.NVarChar, 20) { Value = entity.State };
                var countryParam = new SqlParameter("@Country", SqlDbType.NVarChar, 100) { Value = entity.Country };

                command.Parameters.Add(addressIdParam);
                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(addresLineParam);
                command.Parameters.Add(addresLine2Param);
                command.Parameters.Add(addresTypeParam);
                command.Parameters.Add(cityParam);
                command.Parameters.Add(postalCodeParam);
                command.Parameters.Add(stateParam);
                command.Parameters.Add(countryParam);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("DELETE Address WHERE AddressId = @AddressId", connection);

                var addressIdParam = new SqlParameter("@AddressId", SqlDbType.NVarChar, 100) { Value = entity };

                command.Parameters.Add(addressIdParam);

                command.ExecuteNonQuery();
            }
        }

        public int GetId()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT AddressId FROM Address", connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["AddressId"]);
                }
                return 0;
            }
        }

        public void DeleteAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Address", connection);
                command.ExecuteNonQuery();
            }
        }

        public int GetCustomerId()
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

        public List<Address> ReadByCustomerId(int customerId)
        {
            List<Address> addresses = new List<Address>();

            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Address", connection);

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = customerId
                };

                command.Parameters.Add(customerIdParam);


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addresses.Add(new Address()
                        {
                            AddressId = Convert.ToInt32(reader["AddressId"]),
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            AddressLine = reader["AddressLine"].ToString(),
                            AddressLine2 = reader["AddressLine2"].ToString(),
                            AddressType = reader["AddressType"].ToString(),
                            City = reader["City"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            State = reader["State"].ToString(),
                            Country = reader["Country"].ToString()
                        });
                    }
                }
                return addresses;
            }
        }

        public List<Address> GetAll()
        {
            List<Address> address = new List<Address>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Address", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        address.Add(new Address
                        {
                            AddressId = Convert.ToInt32(reader["AddressId"]),
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            AddressLine = reader["AddressLine"].ToString(),
                            AddressLine2 = reader["AddressLine2"].ToString(),
                            AddressType = reader["AddressType"].ToString(),
                            City = reader["City"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            State = reader["State"].ToString(),
                            Country = reader["Country"].ToString()
                        });
                    }
                }
                return address;
            }
        }
    }
}