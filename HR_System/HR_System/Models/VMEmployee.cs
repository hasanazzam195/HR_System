using HR_System.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.Models
{
    public class VMEmployee
    {
        public Employee employee { get; set; }
        public List<Department> lidepartments { get; set; }
    }
}
