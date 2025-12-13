using System.Collections.Generic;
using Microsoft.Data.SqlClient; // Use Microsoft.Data.SqlClient instead of System.Data.SqlClient
using MyProject.DTO;

namespace MyProject.DAL
{
    public class ProductRepository
    {
        private readonly string _connectionString =
            "YOUR_CONNECTION_STRING_HERE";

        public List<ProductDTO> GetAll()
        {
            var list = new List<ProductDTO>();

            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var cmd = new SqlCommand("SELECT * FROM Products", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new ProductDTO
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()!,
                    Price = (decimal)reader["Price"],
                    Quantity = (int)reader["Quantity"]
                });
            }

            return list;
        }

        public void Add(ProductDTO p)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var cmd = new SqlCommand(
                "INSERT INTO Products (Name, Price, Quantity) VALUES (@n,@p,@q)",
                conn);

            cmd.Parameters.AddWithValue("@n", p.Name);
            cmd.Parameters.AddWithValue("@p", p.Price);
            cmd.Parameters.AddWithValue("@q", p.Quantity);

            cmd.ExecuteNonQuery();
        }

        public void Update(ProductDTO p)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var cmd = new SqlCommand(
                "UPDATE Products SET Name=@n, Price=@p, Quantity=@q WHERE Id=@id",
                conn);

            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.Parameters.AddWithValue("@n", p.Name);
            cmd.Parameters.AddWithValue("@p", p.Price);
            cmd.Parameters.AddWithValue("@q", p.Quantity);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var cmd = new SqlCommand(
                "DELETE FROM Products WHERE Id=@id",
                conn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}