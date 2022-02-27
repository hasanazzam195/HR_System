using HR_System.data;
using HR_System.Models;
using HR_System.service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private  IEmployeeService employeeService;
        private  IConfiguration configuration;
        private  IDepartmentService departmentService;

        public EmployeeController(IEmployeeService _employeeService,IConfiguration _configuration,IDepartmentService _departmentService)
        {
            employeeService = _employeeService;
            configuration = _configuration;
            departmentService = _departmentService;
        }
        public IActionResult Index(VMEmployee vm)
        {
            ViewData["ISValid"] = false;
            vm.lidepartments = departmentService.LoadAll();
            return View("NewEmployee",vm);
        }

        public IActionResult SaveData(VMEmployee vm)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\" + configuration["filePath"], vm.employee.ProfileImage.FileName);
            vm.employee.ProfileImage.CopyTo(new FileStream(filePath, FileMode.Create));
            vm.employee.path = "http://localhost/HR_System/" + configuration["filePath"] + configuration["filePath"] + "/" + vm.employee.ProfileImage.FileName;
            employeeService.Insert(vm.employee);
            vm.lidepartments = departmentService.LoadAll();
            ViewData["ISValid"] = false;
            return View("NewEmployee",vm);
        }

        public IActionResult EmployeeList()
        {
            List<Employee> li = employeeService.LoadAll();
            return View(li);
        }

        public IActionResult SearchData()
        {
            string name = Request.Form["txtSearch"];
            List<Employee> li = employeeService.Search(name);
            return View("EmployeeList", li);
        }

        public IActionResult EditData(int id,VMEmployee vm)
        {
            vm.employee = employeeService.Edit(id);
            ViewData["ISValid"] = true;
            vm.lidepartments = departmentService.LoadAll();
            return View("NewEmployee",vm);
        }

        public IActionResult UpdateData(VMEmployee vm)
        {
            employeeService.Update(vm.employee);
            ViewData["ISValid"] = true;
            vm.lidepartments = departmentService.LoadAll();
            return View("NewEmployee", vm);
        }

        public IActionResult DeleteData(int id)
        {
            employeeService.Remove(id);
            List<Employee> li = employeeService.LoadAll();
            return View("EmployeeList", li);
        }
    }
}
