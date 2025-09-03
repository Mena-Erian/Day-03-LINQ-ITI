using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    internal class Instructor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Bouns { get; set; }
        public decimal Salary { get; set; }
        public string? Address { get; set; }
        public int HourRate { get; set; }
        public int DeptId { get; set; }
    }
}
