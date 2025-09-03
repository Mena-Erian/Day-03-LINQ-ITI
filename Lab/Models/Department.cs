using HelperUtilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//using Lab;

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
        public static int InsertDepartment(Department department, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(@"Insert into Departments (name,insId,hiringDate)
                                                         Values (@DpName,@InstructorId ,@HiringDate)
                                                         SELECT SCOPE_IDENTITY();", connection);

            command.Parameters.AddRange(
                ConnectionHelpr.GetParameters(department,
                   new DepartmentInputData("@DpName",
                   "@InstructorId",
                   "@HiringDate"))
                );
            int identity = -1;

            identity = Convert.ToInt32(command.ExecuteScalar());


            return identity;
        }
        public static void UpdateDepartment(Department newDepartment, int idOfDepartmentUpdate, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand($"Execute Sp_UpdateDepartmenById {idOfDepartmentUpdate},@DpName,@InstructorId,@HiringDate", connection);

            cmd.Parameters.AddRange(ConnectionHelpr.GetParameters(newDepartment,
                              new DepartmentInputData("@DpName", "@InstructorId", "@HiringDate")
                                                    ));
            cmd.ExecuteNonQuery();
        }
        public override string ToString()
            => $"Department Id: {Id}, Name: {Name}, Instructor Id: {InsId}, Hiring Date {HiringDate}";
    }
}
