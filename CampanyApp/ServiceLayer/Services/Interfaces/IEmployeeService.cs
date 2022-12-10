using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IEmployeeService
    {
        Employee Create(Employee employee);
        Employee Update(int id, Employee employee);
        void Delete(int? id);
        Employee GetById(int? id);
        List<Employee> Count();
        List<Employee> SearchEmployeesByNameOrSurname(string searchText);
        List<Employee> GetEmployeesByDepartmentAge(int age);
        List<Employee> GetEmployeesByDepartamentId(int? id);
        List<Employee> GetAllEmployeesByDepartamentName(string name);

    }
}
