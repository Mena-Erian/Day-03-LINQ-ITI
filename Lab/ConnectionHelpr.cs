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
    public record StudentInputData(string fname, string lname, string age, string deptId, string address);
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
        public static SqlParameter[] GetParameters(Student student, StudentInputData parametersNames)
        {
            if (parametersNames is null) return [];

            SqlParameter[] parameters = new SqlParameter[3];

            SqlParameter p1FName = new() { ParameterName = parametersNames.fname, Value = student.FName, SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input };
            SqlParameter p2LName = new() { ParameterName = parametersNames.lname, Value = student.LName, SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input };
            SqlParameter p3Age = new() { ParameterName = parametersNames.age, Value = student.Age, SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input };
            SqlParameter p4DeptId = new() { ParameterName = parametersNames.deptId, Value = student.DeptId, SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input };
            SqlParameter p5Address = new() { ParameterName = parametersNames.address, Value = student.Address, SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input };

            return [p1FName, p2LName, p3Age, p4DeptId, p5Address];
        }
    }
}
