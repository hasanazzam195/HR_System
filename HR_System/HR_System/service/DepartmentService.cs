using HR_System.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.service
{
    public class DepartmentService : IDepartmentService
    {
        private  HRContext context;

        public DepartmentService(HRContext _context)
        {
            context = _context;
        }

        public List<Department> LoadAll()
        {
            List<Department> li = context.departments.ToList();
            return li;
        }
        public void Insert(Department dept)
        {
            context.departments.Add(dept);
            context.SaveChanges();
        }

        public List<Department> Search(string name)
        {
            List<Department> li = context.departments.Where(n => n.Name == name).ToList();
            return li;
        }

        public void Remove(int id)
        {
            Department dept= context.departments.Find(id);
            context.departments.Remove(dept);
            context.SaveChanges();
        }

        public Department load(int id)
        {
            Department dept = context.departments.Find(id);
            return dept;
        }

        public void Update(Department dept)
        {
            context.departments.Attach(dept);
            context.Entry(dept).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
