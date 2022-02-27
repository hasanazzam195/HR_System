using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.data
{
    [Table("Departments")]
    public class Department
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Employee> liEmployee { get; set; }
    }
}
