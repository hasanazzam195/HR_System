using HR_System.data;
using HR_System.service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService _departmentService)
        {
            departmentService = _departmentService;
        }
        public IActionResult NewDepartment()
        {
            ViewData["ISValid"] = false;
            return View();
        }
        public IActionResult DepartmentList()
        {
            List<Department> li = departmentService.LoadAll();
            return View(li);
        }

        public IActionResult SaveData(Department dept)
        {
            departmentService.Insert(dept);
            ViewData["ISValid"] = false;
            return View("NewDepartment");
        }

        public IActionResult SearchData()
        {
            string name = Request.Form["txtSearch"];
            List<Department> li = departmentService.Search(name);
            return View("DepartmentList",li);
        }

        public IActionResult DeleteData(int id)
        {
            departmentService.Remove(id);
            List<Department> li = departmentService.LoadAll();
            return View("DepartmentList",li);
        }

        public IActionResult Edit(int id)
        {
            Department dept= departmentService.load(id);
            ViewData["ISValid"] = true;
            return View("NewDepartment", dept);
        }

        public IActionResult UpdateData(Department dept)
        {
            departmentService.Update(dept);
            ViewData["ISValid"] = true;
            return View("NewDepartment");
        }
    }
}
