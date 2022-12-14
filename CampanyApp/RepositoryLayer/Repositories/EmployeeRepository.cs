using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public void Add(Employee entity)
        {
            if (entity is null) throw new ArgumentNullException();
            AppDbContext<Employee>.datas.Add(entity);
        }

        public void Delete(Employee entity)
        {
            if (entity is null) throw new ArgumentNullException();
            AppDbContext<Employee>.datas.Remove(entity);
        }

        public Employee Get(Predicate<Employee> predicate)
        {
            return AppDbContext<Employee>.datas.Find(predicate);
        }

        public List<Employee> GetAll(Predicate<Employee> predicate = null)
        {
            return predicate == null ? AppDbContext<Employee>.datas : AppDbContext<Employee>.datas.FindAll(predicate);
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
