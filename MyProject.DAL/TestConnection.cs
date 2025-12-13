using Microsoft.Data.SqlClient;

namespace MyProject.DAL
{
    public class TestConnection
    {
        public static bool Test()
        {
            try
            {
                using var conn = new SqlConnection(DbHelper.ConnectionString);
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}