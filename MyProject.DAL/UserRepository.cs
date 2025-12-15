using Microsoft.Data.SqlClient;

namespace MyProject.DAL
{
    public class UserRepository
    {
        public virtual bool CheckLogin(string username, string password)
        {
            using var conn = DbHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Users WHERE Username=@u AND Password=@p",
                conn);

            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);

            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }
}