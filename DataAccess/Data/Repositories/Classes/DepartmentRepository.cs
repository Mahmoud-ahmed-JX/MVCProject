using DataAccess.Data.context;
using DataAccess.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repositories.Classes
{
    public class DepartmentRepository(ApplicationDbContext _dbContext) : IDepartmentRepository
    {
        //private readonly ApplicationDbContext _dbContext = dbContext;

        //5 CRUD Operations
        //GetAll
        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Departments.ToList();
            }
            else
            {
                return _dbContext.Departments.AsNoTracking().ToList();
            }
        }
        //GetById
        public Department? GetById(int Id) => _dbContext.Departments.Find(Id);

        //Add
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }

        //Update
        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }

        //Remove
        public int Remove(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }

    }
}
