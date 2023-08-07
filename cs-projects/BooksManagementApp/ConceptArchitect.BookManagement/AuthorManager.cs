using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class AuthorManager
    {
        const string connectionString= @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MyWorks\Corporate\202307-ecolab-cs\booksdb.mdf;Integrated Security = True; Connect Timeout = 30";
        public List<Author> GetAllAuthors()
        {
            IDbConnection connection = null;
            var authors = new List<Author>();

            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                var command=connection.CreateCommand();
                command.CommandText = "select * from authors";

                var reader = command.ExecuteReader();
                

                while (reader.Read())
                {
                    var author = new Author()
                    {
                        Id = reader["id"].ToString(),
                        Name = reader["name"].ToString(),
                        Biography = reader["biography"].ToString(),
                        Photo = reader["photo"].ToString(),
                        Email = reader["email"].ToString()

                    };

                    authors.Add(author);

                }


                

            }catch(SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                
            }
            finally
            {
                if (connection != null)
                    connection.Close();                
            }
            return authors;
        }

        public Author GetAuthorById(string id)
        {

            IDbConnection connection = null;
           

            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"select * from authors where id='{id}'";

                var reader = command.ExecuteReader();


                if (reader.Read())
                {
                    var author = new Author()
                    {
                        Id = reader["id"].ToString(),
                        Name = reader["name"].ToString(),
                        Biography = reader["biography"].ToString(),
                        Photo = reader["photo"].ToString(),
                        Email = reader["email"].ToString()

                    };

                    return author;

                }
                



            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            throw new InvalidIdException();
        }


    }
}
