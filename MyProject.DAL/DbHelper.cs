using Microsoft.Data.SqlClient;
using System.Configuration;

namespace MyProject.DAL
{
    public static class DbHelper
    {
        public static SqlConnection GetConnection()
        {
            string connStr =
                "Server=(localdb)\\MSSQLLocalDB;Database=SE_Final_DB;Trusted_Connection=True;";
            return new SqlConnection(connStr);
        }
    }
}