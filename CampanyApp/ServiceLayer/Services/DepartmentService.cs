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
    public class DepartmentService : IDepartmentService
    {
        private readonly DepartmentRepository _repo;

        private int _count;

        public DepartmentService()
        {
            _repo = new DepartmentRepository();
        }



        public Department Create(Department department)
        {
            department.Id = _count;
            _repo.Add(department);
            _count++;
            return department;
        }

        public void Delete(int? id)
        {
            if (id == null) throw new ArgumentNullException();

            Department department = GetById(id);

            if (department == null) throw new NotFoundException("Data not found");

            _repo.Delete(department);
        }

        public List<Department> GetAll(string text)
        {
            if(text == null) throw new ArgumentNullException();
            return _repo.GetAll();
        }

        public Department GetById(int? id)
        {

            if (id is null) throw new ArgumentNullException();
            return _repo.Get(m => m.Id == id);
        }

        public List<Department> Search(string searchText)
        {
            return _repo.GetAll(m => m.Name.ToLower().Contains(searchText.ToLower()));
        }

        public Department Update(int id, Department department)
        {
            throw new NotImplementedException();
        }
    }
}
