using Microsoft.Data.SqlClient;
namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection(
                "Server=.;Database=ITIA;integrated security=true;trustservercertificate=true;"
                );
            SqlCommand sqlCommand = new SqlCommand("select * from Department;", sqlConnection);
            
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }
            sqlConnection.Close();
        }
    }
}
