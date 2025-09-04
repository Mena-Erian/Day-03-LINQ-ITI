using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBusinessLayer
{
    public static class DepartmentManager
    {
        public static DepartmentList GetAll()
        {
            DataTable dt = DBManager.GetQueryResult("select * from departments");
            return MapFromDTtoDeptList(dt);
        }
        public static Department GetById(int id)
        {
            var dt = DBManager.GetQueryResult($"select top 1 * from departments where id = {id}");
            Department department = MapDataTableRowToDept(dt.Rows[0]);
            return department;
        }
        private static DepartmentList MapFromDTtoDeptList(DataTable dt)
        {
            var result = new DepartmentList();
            foreach (DataRow dr in dt.Rows) result.Add(MapDataTableRowToDept(dr));
            return result;
        }
        private static Department MapDataTableRowToDept(DataRow dr)
        {
            Department dept = new Department();
            dept.Id = (int)dr[0];
            dept.Name = (string)dr[1].ToString() ?? string.Empty;
            dept.InsId = (int)dr[2];
            DateTime.TryParse(dr[3].ToString(), out DateTime hiringDate);

            dept.HiringDate = hiringDate;

            return dept;
        }
    }

}
