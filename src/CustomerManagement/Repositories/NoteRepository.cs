using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CustomerManagement.Repositories
{
    public class NoteRepository : BaseRepository, IRepository<Notes>
    {
        public void Create(Notes entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Notes (CustomerId, Note) VALUES (@CustomerId,@Note)", connection);

                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int) { Value = entity.CustomerId };
                var noteParam = new SqlParameter("@Note", SqlDbType.NVarChar, 255) { Value = entity.Note };

                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(noteParam);

                command.ExecuteNonQuery();
            }
        }

        public Notes Read(int entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM Notes WHERE NoteId = @NoteId", connection);

                var noteIdParam = new SqlParameter("@NoteId", SqlDbType.Int) { Value = entity };

                command.Parameters.Add(noteIdParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Notes
                        {
                            NoteId = Convert.ToInt32(reader["NoteId"]),
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            Note = reader["Note"].ToString()
                        };
                    }
                    return null;
                }
            }
        }

        public void Update(Notes entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("UPDATE Notes SET CustomerId = @CustomerId, Note = @Note WHERE NoteId = @NoteId", connection);

                var noteIdParam = new SqlParameter("@NoteId", SqlDbType.Int) { Value = entity.NoteId };
                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int) { Value = entity.CustomerId };
                var noteParam = new SqlParameter("@Note", SqlDbType.NVarChar, 255) { Value = entity.Note };

                command.Parameters.Add(noteIdParam);
                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(noteParam);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("DELETE Notes WHERE Note = @Note", connection);

                var noteParam = new SqlParameter("@Note", SqlDbType.NVarChar, 255) { Value = entity };

                command.Parameters.Add(noteParam);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Notes", connection);
                command.ExecuteNonQuery();
            }
        }

        public List<Notes> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
