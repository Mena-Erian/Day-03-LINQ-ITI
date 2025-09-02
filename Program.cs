using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Read From DB
            /// string? connString = new ConfigurationBuilder().AddJsonFile("appSetting.json").Build().GetSection("connection1").Value;
            /// SqlConnection sqlConnection = new SqlConnection(connString);
            /// if (sqlConnection.State ==ConnectionState.Closed)
            ///     sqlConnection.Open();
            /// SqlCommand sqlCommand = new SqlCommand("select * from Employees", sqlConnection);
            /// 
            /// SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            /// 
            /// while (sqlDataReader.Read())
            /// {
            ///    
            ///     $"{sqlDataReader[0]} :: {sqlDataReader[1]} :: {sqlDataReader[2] ?? "NOT HAVE MANAGER"} ".Print();
            /// }
            /// sqlConnection.Close(); 
            #endregion







            Console.ReadLine();
        }
        static void InsertCommand()
        {
            var connectionString = new ConfigurationBuilder().AddJsonFile("AppSetting.json").Build().GetSection("connection1").Value;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(
                //"insert into Project (Pname,Pnumber,Plocation,City,Dnum) values ('ISchool',800,'Eltagamo3','Alex',30)",
                "insert into Project (Pname,Pnumber,Plocation,City,Dnum) values (@pName,@pNumber,@pLocation,@pCity,@dNumber)",
                sqlConnection);
            // use when insert update delete

            SqlParameter p1 = new SqlParameter("@pName", "Rehap El Eman") { SqlDbType = SqlDbType.Text, Direction = ParameterDirection.Input };
            SqlParameter p2 = new SqlParameter("@pNumber", 1000) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input };
            SqlParameter p3 = new SqlParameter("@pLocation", "Elmarg") { SqlDbType = SqlDbType.Text, Direction = ParameterDirection.Input };
            SqlParameter p4 = new SqlParameter("@pCity", "Cairo") { SqlDbType = SqlDbType.Text, Direction = ParameterDirection.Input };
            SqlParameter p5 = new SqlParameter("@dNumber", 30) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input };

            //sqlCommand.Parameters.Add(p1);
            //sqlCommand.Parameters.AddRange([p1, p2, p3, p4, p5]);  

            sqlCommand.Parameters.Add(p1);
            sqlCommand.Parameters.Add(p2);
            sqlCommand.Parameters.Add(p3);
            sqlCommand.Parameters.Add(p4);
            sqlCommand.Parameters.Add(p5);


            if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();


            sqlCommand.ExecuteNonQuery().Print();

            sqlConnection.Close();
        }
        static void ExecuteReader(string[] args)
        {
            var connString = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build().GetSection("connection1").Value;
            SqlConnection sqlConnection = new SqlConnection(connString);
            SqlCommand sqlCommand = new SqlCommand("select * from Department;", sqlConnection);

            sqlCommand.CommandType = CommandType.Text;
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                $"{reader[0]} :: {reader["Dept_Name"]} :: {reader["Dept_Manager"] ?? "NOT HAVE MANAGER"} ".Print();
            }
            sqlConnection.Close();

        }
    }
}
