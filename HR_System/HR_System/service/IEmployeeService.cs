using HR_System.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.service
{
    public interface IEmployeeService
    {
        void Insert(Employee emp);
        List<Employee> Search(string name);
        List<Employee> LoadAll();
        Employee Edit(int id);
        void Update(Employee emp);
        void Remove(int id);
    }
}
