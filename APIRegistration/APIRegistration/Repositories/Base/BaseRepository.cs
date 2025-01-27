using System.Data.SqlClient;

namespace APIRegistration.Repositories.Base
{
    public class BaseRepository
    {
        public static string connection = "Data Source=INBOOK_X1;Initial Catalog=mytestdb;Integrated Security=True";


        public SqlConnection openConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            return sqlConnection;
        }
    }
}
