using Microsoft.Data.SqlClient;
using MyProject.DTO;

namespace MyProject.DAL
{
    public class UserRepository
    {
        public UserDTO Login(string username, string password)
        {
            using var conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();

            var cmd = new SqlCommand(
                "SELECT UserId, Username, Role FROM Users " +
                "WHERE Username=@u AND PasswordHash=@p AND IsActive=1",
                conn);

            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new UserDTO
                {
                    UserId = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Password = password, // Set required property
                    Role = reader.GetString(2)
                };
            }
            return null;
        }
    }
}