using HR_System.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.service
{
    public interface IDepartmentService
    {
        void Insert(Department dept);
        List<Department> Search(string name);
        List<Department> LoadAll();
        void Remove(int id);
        Department load(int id);
        void Update(Department dept);
    }
}
