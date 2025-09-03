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
        private Student(int id, string fName, string lName, int age, string? address, int deptId)
        {
            Id = id;
            FName = fName;
            LName = lName;
            Age = age;
            Address = address;
            DeptId = deptId;
        }
        public Student(string fName, string lName, int age, string? address, int deptId)
        {
            //Id = id;
            FName = fName;
            LName = lName;
            Age = age;
            Address = address;
            DeptId = deptId;
        }
        public Student()
        {

        }
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
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

            dataTable.PrintAll();
            "-----------====-------------------------------------------".Print();
            foreach (DataRow item in dataTable.Rows)
            {
                students.Add(new Student(
                             Convert.ToInt32(item.ItemArray[0]),
                             item.ItemArray[1] == DBNull.Value ? string.Empty : item.ItemArray[1].ToString(),
                             item.ItemArray[2] == DBNull.Value ? string.Empty : item.ItemArray[2].ToString(),
                             Convert.ToInt32(item.ItemArray[3]),
                             item.ItemArray[4] == DBNull.Value ? null : item.ItemArray[4].ToString(),
                             Convert.ToInt32(item.ItemArray[5])
                                              ));
            }
            return students;

        }

        public override string ToString()
        => $"Id: {Id}, FName: {FName}, LName: {LName}, Age: {Age}, Address: {Address ?? "N/A"}, DeptId: {DeptId}";
    }
}
