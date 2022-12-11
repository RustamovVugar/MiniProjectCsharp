using DomainLayer.Entities;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _repo;

        private int _count;

        public EmployeeService()
        {
            _repo = new EmployeeRepository();
        }

        public List<Employee> Count()
        {
            return _repo.GetAll(null);
        }

        public Employee CreateEmployee(Employee employee)
        {
            employee.Id = _count;
            _repo.Add(employee);
            _count++;
            return employee;
        }

        public void DeleteEmployee(int? id)
        {
            if (id == null) throw new ArgumentNullException();

            Employee employee = GetById(id);

            if (employee == null) throw new NotFoundException("Data not found");

            _repo.Delete(employee);
        }

        public Employee Update(int id, Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(int? id)
        {
            if (id is null) throw new ArgumentNullException();
            return _repo.Get(m => m.Id == id);
        }

        public List<Employee> GetAllEmployeesByDepartamentName(string name)
        {
            if (name is null) throw new ArgumentNullException();
            return _repo.GetAll(m => m.Name == name);
        }

        public List<Employee> GetEmployeesByDepartmentAge(int age)
        {
            if (age == 0) throw new ArgumentNullException();
            return _repo.GetAll(m => m.Age == age);
        }

        public List<Employee> GetEmployeesByDepartamentId(int? id)
        {
            if (id == null) throw new ArgumentNullException();
            return _repo.GetAll(m => m.Department.Id == id);
        }

        public List<Employee> SearchEmployeesByNameOrSurname(string searchText)
        {
            return _repo.GetAll(m => m.Name.ToLower().Contains(searchText.ToLower()) && m.Surname.ToLower().Contains(searchText.ToLower()));
        }


    }
}
