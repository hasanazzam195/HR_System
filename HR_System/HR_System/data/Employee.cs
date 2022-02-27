using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HR_System.helper;
using Microsoft.AspNetCore.Http;

namespace HR_System.data
{
    [Table("Employees")]
    public class Employee
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Birth of Date")]
        [BDateValidation]
        public DateTime BDate { get; set; }
        [Required]
        [Display(Name = "Date of Joining")]
        public DateTime DateOFJoin { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string path { get; set; }
        [ForeignKey("department")]
        public int Department_id { get; set; }
        [Display(Name = "Department")]
        public Department department { get; set; }
        [NotMapped]
        public IFormFile ProfileImage { get; set; }
    }
}
