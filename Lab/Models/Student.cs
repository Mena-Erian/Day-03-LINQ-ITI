using HelperUtilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    internal class Student
    {
        private string fName;
        private string lName;

        private Student(int id, string fName, string lName, int age, string? address, int deptId)
        {
            Id = id;
            FName = fName;
            LName = lName;
            Age = age;
            Address = address;
            DeptId = deptId;
        }
        public Student(string fName, string lName, int age, int deptId, string? address = default)
        {
            //Id = id;
            FName = fName;
            LName = lName;
            Age = age;
            Address = address;
            DeptId = deptId;
        }
        public Student() { }
        public int Id { get; set; }
        public string FName
        {
            get => fName;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    fName = char.ToUpper(value[0]) + value.Substring(1);
                }
                fName = value;
            }
        }
        public string LName
        {
            get => lName;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    lName = char.ToUpper(value[0]) + value.Substring(1);
                }
                lName = value;
            }
        }
        public int Age { get; set; }
        public string? Address { get; set; }
        public int DeptId { get; set; }

        public static List<Student> GetStudents(SqlConnection connection)
        {
            var students = new List<Student>();

            SqlCommand cmd = new SqlCommand("Select * from Students;", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            foreach (DataRow item in dataTable.Rows)
            {
                students.Add(new Student(
                             Convert.ToInt32(item.ItemArray[0]),
                             item.ItemArray[1] == DBNull.Value ? string.Empty : item.ItemArray[1]?.ToString()!,
                             item.ItemArray[2] == DBNull.Value ? string.Empty : item.ItemArray[2]?.ToString()!,
                             Convert.ToInt32(item.ItemArray[3]),
                             item.ItemArray[4] == DBNull.Value ? null : item.ItemArray[4]?.ToString()!,
                             Convert.ToInt32(item.ItemArray[5])
                                              ));
            }
            return students;
        }
        public static int InsertStudent(Student student, SqlConnection connection)
        {
            SqlCommand cmd =
                new SqlCommand($"Execute Sp_InsertStudent @fName, @lName, @age, @DeptId, @address", connection);

            cmd.Parameters.AddRange(ConnectionHelpr.GetParameters(student,
                        new StudentInputData("@fName", "@lName",
                                 "@age", "@DeptId", "@address")));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
        }
        public static void UpdateStudentById(int IdOfStudentUpdate, Student newStudent, SqlConnection connection)
        { 
            SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("select * From Students", connection));
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = sqlCommandBuilder.GetUpdateCommand();

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            DataRow[] dataRows = dataTable.Select($"id = {IdOfStudentUpdate}");

            if (dataRows.Length > 0)
            {
                dataRows[0]["fName"] = newStudent.fName;
                dataRows[0]["lName"] = newStudent.lName;
                dataRows[0]["age"] = newStudent.Age;
                dataRows[0]["deptId"] = newStudent.DeptId;
                dataRows[0]["address"] = newStudent.Address;
                adapter.Update(dataTable);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"USER OF ID {IdOfStudentUpdate} IS NOT FOUNDED!!");
                Console.ResetColor();
            }
        }

        public override string ToString()
        => $"Id: {Id}, FName: {FName}, LName: {LName}, Age: {Age}, Address: {Address ?? "N/A"}, DeptId: {DeptId}";
    }
}
