using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBusinessLayer
{
    public class DepartmentList : List<Department>
    {
        public void Add(Department dept)
        {
            base.Add(dept);
        }
    }
}
