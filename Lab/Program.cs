using HelperUtilities;
using Lab.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

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


            #region Student CRUD Operations With DisConnected MODE
            Console.ForegroundColor = ConsoleColor.Green;
            Student.GetStudents(sqlConnection).PrintAll();
            Console.ResetColor();

            #region Update Student
            Student.UpdateStudentById(24,
                new Student("Mo3az", "Esmaeal", 12, 12, "ELCOPA")
                , sqlConnection);
            #endregion

            #region Insert Or Create Students
            //Department.GetDepartments(strConnection).PrintAll() ;
            //Student.InsertStudent(new Student("Hosam", "Mohamad", 14, 1, "ElKhosuse"), sqlConnection).Print("  <<< Idintity");
            #endregion

            #region Get Or Read Students
            //Student.GetStudents(sqlConnection).PrintAll();
            #endregion

            "===========================After Edit And Update===========================".Print();
            Student.GetStudents(sqlConnection).PrintAll(color: ConsoleColor.DarkYellow);
            #endregion
            /// SqlDataAdapter adapter = new SqlDataAdapter(getAllDepartmentCmd);
            /// SqlCommandBuilder updateBuilder = new SqlCommandBuilder(adapter);
            /// adapter.UpdateCommand = updateBuilder.GetUpdateCommand();
            /// adapter.UpdateCommand.CommandText.Print("\n\n");
            /// DataTable dt = new DataTable();
            /// adapter.Fill(dt);
            /// 
            /// 
            /// foreach (DataRow item in dt.Rows)
            /// {
            ///     item.ItemArray.PrintAll();
            ///     item.RowState.Print();
            ///     "-------------------------------*".Print();
            /// }
            /// 
            /// "===========================Before Edit===========================".Print();
            /// 
            /// dt.Rows[0][0] = "Hamada Department";
            /// dt.Rows[0][3] = DateTime.Today.ToString();
            /// dt.Rows[0][0].Print(); 
            /// 
            /// foreach (DataRow item in dt.Rows)
            /// {
            ///     item.ItemArray.PrintAll();
            ///     item.RowState.Print();
            ///     "-------------------------------*".Print();
            /// }
            /// "===========================After Edit Before Update===========================".Print();
            /// DataRow dr = dt.NewRow();
            /// dr["Dname"] = "DP6";
            /// dr["Dnum"] = 60;
            /// dr["MGRSSN"] = 223344;
            /// dr["MGRStart Date"] = DateTime.MinValue;
            /// 
            /// dr.ItemArray.PrintAll("\n");
            /// adapter.Update(dt);
            /// "===========================After Edit And Update===========================".Print();
            /// dr.ItemArray.PrintAll("\n");
            /// 
            /// 
            /// foreach (DataRow dataRow in dt.Rows)
            /// {
            ///     dataRow.ItemArray.PrintAll();
            ///     dataRow.RowState.Print();
            ///     "-------------------------------*".Print();
            /// }

            #region Department CRUD Operation With Connected MODE
            //Department.GetDepartments(strConnection ?? "").PrintAll();

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

            #region Delete
            /// ConnectionHelpr.ConnectThenDisconnect(sqlConnection, () =>
            /// {
            ///     Department.DeleteDepartment(16, sqlConnection);
            /// });
            #endregion


            //"=======================================After Edit===========================================".Print();
            //Department.GetDepartments(strConnection ?? "").PrintAll(); 
            #endregion

            Console.ReadLine();
        }
    }
}
