using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataAccessLayer
{
    public static class DBManager
    {
        static SqlConnection connection;
        static DBManager()
        {
            var strConniction = new ConfigurationBuilder().AddJsonFile("appSetting.json").Build().GetSection("connection2").Value; ;
            connection = new SqlConnection(strConniction);
        }
        public static DataTable GetQueryResult(string cmdText)
        {
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public static int ExecuteNonQuery(string cmdText)
        {
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            connection.Open();
            int x = cmd.ExecuteNonQuery();
            connection.Close();
            return x;
        }
        //scaler
    }
}
