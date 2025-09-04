using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBusinessLayer
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InsId { get; set; }
        public DateTime HiringDate { get; set; }
        public override string ToString()
            => $"Department: Id={Id}, Name={Name ?? "N/A"}, InsId={InsId}, HiringDate={HiringDate:yyyy-MM-dd}";
    }

}
