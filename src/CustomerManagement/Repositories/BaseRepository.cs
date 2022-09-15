using System.Data.SqlClient;

namespace CustomerManagement.Repositories
{
    public class BaseRepository
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection("server=.\\SQLEXPRESS;DataBase=CustomerLib_Stavriadi;Trusted_Connection=True");
        }
    }
}
