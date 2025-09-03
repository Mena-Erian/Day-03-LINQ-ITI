using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    internal static class ConnectionHelpr
    {
        public static void ConnectThenDisconnect(SqlConnection conn, Action action)
        {
            if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
            action.Invoke();
            conn.Close();
        }
    }
}
