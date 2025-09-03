using HelperUtilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;


namespace Lab.Models
{
    internal class Department
    {
        public Department(string name, int insId, DateOnly hiringDate)
        {
            //Id = id;
            Name = name;
            InsId = insId;
            HiringDate = hiringDate;
        }
        private Department(int id, string name, int insId, DateOnly hiringDate)
        {
            Id = id;
            Name = name;
            InsId = insId;
            HiringDate = hiringDate;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int InsId { get; set; }
        public DateOnly HiringDate { get; set; }

        public static List<Department> GetDepartments(string strConnection)
        {
            List<Department> departments = new List<Department>();
            SqlConnection connection = new SqlConnection(strConnection);

            SqlCommand command = new SqlCommand("Select * from Departments", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                departments.Add(new Department((int)reader["id"],
                                                    (string)reader["name"],
                                                    (int)reader["insId"],
                                                    DateOnly.FromDateTime((DateTime)reader["hiringDate"])));
            }
            return departments;
        }
        public static int InsertDepartment(Department department, string strConnection)
        {
            SqlConnection connection = new SqlConnection(strConnection);
            SqlCommand command = new SqlCommand(@"Insert into Departments (name,insId,hiringDate)
                                                         Values (@DpName,@InstructorId ,@HiringDate)
                                                         SELECT SCOPE_IDENTITY();", connection);

            SqlParameter p1Name = new SqlParameter() { ParameterName = "@DpName", Value = department.Name, SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input };
            SqlParameter p2InsId = new SqlParameter() { ParameterName = "@InstructorId", Value = department.InsId, SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input };
            SqlParameter p3HiringDate = new SqlParameter() { ParameterName = "@HiringDate", Value = (DateOnly)department.HiringDate, SqlDbType = SqlDbType.Date, Direction = ParameterDirection.Input };

            command.Parameters.AddRange([p1Name, p2InsId, p3HiringDate]);

            int identity = -1;
            ConnectionHelpr.ConnectThenDisconnect(connection, () =>
            {

                identity = Convert.ToInt32(command.ExecuteScalar());
            });

            return identity;
        }
        public override string ToString()
            => $"Department Id: {Id}, Name: {Name}, Instructor Id: {InsId}, Hiring Date {HiringDate}";
    }
}
