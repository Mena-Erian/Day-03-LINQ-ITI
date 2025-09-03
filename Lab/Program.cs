using HelperUtilities;
using Lab.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Lab
{
    internal class Program
    {
        public static SqlConnection sqlConnection;
        static void Main()
        {
            var strConnection = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build()
                                .GetSection("connection1").Value;
            sqlConnection = new SqlConnection(strConnection);



            Department.GetDepartments(strConnection ?? "").PrintAll();


            #region Inserting
            /// ConnectionHelpr.ConnectThenDisconnect(sqlConnection, () =>
            /// {
            ///     Department.InsertDepartment(new Department("Backend Enginnering",
            ///                                                         566,
            ///                                                         DateOnly.Parse("10/20/2022")),
            ///                                 sqlConnection).Print("  <<< ExecuteScalar()");
            /// });
            #endregion

            #region Updated
            /// ConnectionHelpr.ConnectThenDisconnect(sqlConnection, () =>
            /// {
            ///     Department.UpdateDepartment(new Department("Basics Mentors",
            ///                                                    8,
            ///                                                    DateOnly.Parse("4/20/2025")),
            ///                            12, sqlConnection);
            /// });
            #endregion

            "=======================================After Updating===========================================".Print();
            Department.GetDepartments(strConnection ?? "").PrintAll();

            Console.ReadLine();
        }
    }
}
