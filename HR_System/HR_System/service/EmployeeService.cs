using HR_System.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.service
{
    public class EmployeeService: IEmployeeService
    {
        private readonly HRContext context;
        public EmployeeService(HRContext _context)
        {
            context = _context;
        }

        public List<Employee> LoadAll()
        {
            List<Employee> li = context.employees.Include("department").ToList();
            return li;
        }
        public void Insert(Employee emp)
        {
            context.employees.Add(emp);
            context.SaveChanges();
        }

        public List<Employee> Search(string name)
        {
            List<Employee> li = context.employees.Where(e => e.FName == name).Include("department").ToList();
            return li;
        }

        public Employee Edit(int id)
        {
            Employee emp = context.employees.Find(id);
            return emp;
        }

        public void Update(Employee emp)
        {
            context.employees.Attach(emp);
            context.Entry(emp).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            Employee emp= context.employees.Find(id);
            context.employees.Remove(emp);
            context.SaveChanges();
        }
    }
}
