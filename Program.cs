using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connString = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build().GetSection("connection1").Value;
            SqlConnection sqlConnection = new SqlConnection(connString);
            SqlCommand sqlCommand = new SqlCommand("select * from Department;", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.Text;
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
                sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                $"{reader[0]} :: {reader["Dept_Name"]} :: {reader["Dept_Manager"] ?? "NOT HAVE MANAGER"} ".Print();
            }
            sqlConnection.Close();

            Console.ReadLine();
        }
    }
}
