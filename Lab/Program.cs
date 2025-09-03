using HelperUtilities;
using Lab.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Lab
{
    internal class Program
    {
        static void Main()
        {
            var strConnection = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build()
                                .GetSection("connection1").Value;
            Department.GetDepartments(strConnection ?? "").PrintAll();
            /// Department.InsertDepartment(new Department("Backend Enginnering",
            ///                                                     54,
            ///                                                     DateOnly.Parse("10/20/2022")),
            ///                             strConnection!).Print("  <<< ExecuteScalar()");
            /// "=======================================After Updated===========================================".Print();
            /// Department.GetDepartments(strConnection ?? "").PrintAll();

            Console.ReadLine();
        }
    }
}
