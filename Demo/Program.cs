using HelperUtilities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Demo
{
    #region Lab
    // Create Db
    // Make CRUD Operations
    /// <connected mode> => sqlconnection, sqlcommand,
    /// Read Department
    /// insert (text, Identity)
    /// Update (stored Procedure)
    /// Delete (stored Procedure)
    /// </connected mode>

    /// Student work with disconnected mode => sqlConnection, sqlcommand, sqldataadapter

    //Make Class for student
    //List<Studnet>
    #endregion

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

            #region DisConnected Mode
            var connectionString = new ConfigurationBuilder().AddJsonFile("appSetting.json").Build().GetSection("connection1").Value;

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand getAllDepartmentCmd = new SqlCommand("select * from Departments", connection);

            SqlDataAdapter adapter = new SqlDataAdapter(getAllDepartmentCmd);
            SqlCommandBuilder updateBuilder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = updateBuilder.GetUpdateCommand();
            adapter.UpdateCommand.CommandText.Print("\n\n");
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            foreach (DataRow item in dt.Rows)
            {
                item.ItemArray.PrintAll();
                item.RowState.Print();
                "-------------------------------*".Print();
            }

            "===========================Before Edit===========================".Print();

            dt.Rows[0][0] = "Hamada Department";
            dt.Rows[0][3] = DateTime.Today.ToString();
            dt.Rows[0][0].Print();

            foreach (DataRow item in dt.Rows)
            {
                item.ItemArray.PrintAll();
                item.RowState.Print();
                "-------------------------------*".Print();
            }
            "===========================After Edit Before Update===========================".Print();
            DataRow dr = dt.NewRow();
            dr["Dname"] = "DP6";
            dr["Dnum"] = 60;
            dr["MGRSSN"] = 223344;
            dr["MGRStart Date"] = DateTime.MinValue;

            dr.ItemArray.PrintAll("\n");
            adapter.Update(dt);
            "===========================After Edit And Update===========================".Print();
            dr.ItemArray.PrintAll("\n");


            foreach (DataRow dataRow in dt.Rows)
            {
                dataRow.ItemArray.PrintAll();
                dataRow.RowState.Print();
                "-------------------------------*".Print();
            }
            #endregion
            /// connection.Open();

            /// SqlDataReader reader = getAllDepartmentCmd.ExecuteReader();
            /// while (reader.Read())
            /// {
            ///     $"{reader[0]} :: {reader[1]} :: {reader[2]} :: {reader[3]} ".Print();
            /// }

            /// connection.Close();

            Console.ReadLine();
        }
        static void DeleteCommand()
        {
            var connectionString = new ConfigurationBuilder().AddJsonFile("appSetting.json").Build().GetSection("connection1").Value;

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand deleteCommand = new SqlCommand(
                            "Delete From Departments \r\nwhere Dnum = @depNumber;",
                                   connection);

            Console.Write("Please Enter Id of Department: ");
            SqlParameter parameter = new SqlParameter()
            {
                ParameterName = "@depNumber",
                SqlDbType = SqlDbType.Int,
                Value = Console.ReadLine()
            };
            deleteCommand.Parameters.Add(parameter);
            connection.Open();

            deleteCommand.ExecuteNonQuery().Print();

            SqlCommand getAllDepartmentCmd = new SqlCommand("select * from Departments", connection);
            SqlDataReader reader = getAllDepartmentCmd.ExecuteReader();
            while (reader.Read())
            {
                $"{reader[0]} :: {reader[1]} :: {reader[2]} :: {reader[3]} ".Print();
            }

            connection.Close();
        }
        static void UpdateCommand()
        {
            var connectionString = new ConfigurationBuilder().AddJsonFile("appSetting.json").Build().GetSection("connection1").Value;

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(
                            "Update Departments \r\n set Dname = 'DP04'\r\n where Dnum = 40;",
                                   connection);

            connection.Open();
            command.ExecuteNonQuery().Print();
            connection.Close();
        }
        static void InsertCommand()
        {
            var connectionString = new ConfigurationBuilder().AddJsonFile("AppSetting.json").Build().GetSection("connection1").Value;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(
                //"insert into Project (Pname,Pnumber,Plocation,City,Dnum) values ('ISchool',800,'Eltagamo3','Alex',30)",
                "insert into Project (Pname,Pnumber,Plocation,City,Dnum) values (" +
                "@pName,@pNumber,@pLocation,@pCity,@dNumber)",
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
