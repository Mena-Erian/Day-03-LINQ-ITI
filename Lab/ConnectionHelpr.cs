using Lab.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
   public record DepartmentInputData(string name, string instructorId, string hiringDate);
    internal static class ConnectionHelpr
    {
        public static void ConnectThenDisconnect(SqlConnection conn, Action action)
        {
            if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
            action.Invoke();
            conn.Close();
        }
        public static SqlParameter[] GetParameters(Department department, DepartmentInputData parametersNames)
        {
            if (parametersNames is null) return [];

            SqlParameter[] parameters = new SqlParameter[3];

            SqlParameter p1Name = new() { ParameterName = parametersNames.name, Value = department.Name, SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input };
            SqlParameter p2InsId = new() { ParameterName = parametersNames.instructorId, Value = department.InsId, SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input };
            SqlParameter p3HiringDate = new() { ParameterName = parametersNames.hiringDate, Value = (DateOnly)department.HiringDate, SqlDbType = SqlDbType.Date, Direction = ParameterDirection.Input };
            return [p1Name, p2InsId, p3HiringDate];
        }
    }
}
