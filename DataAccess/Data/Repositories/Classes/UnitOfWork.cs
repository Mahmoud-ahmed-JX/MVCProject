using DataAccess.Data.context;
using DataAccess.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbcotext;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;

        public UnitOfWork(ApplicationDbContext _dbcotext)
        {
            dbcotext = _dbcotext;
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(dbcotext));
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(dbcotext));
        }
        public IEmployeeRepository Employees => _employeeRepository.Value;

        public IDepartmentRepository Departments => _departmentRepository.Value;

        public int SaveChanges()
        {
            return dbcotext.SaveChanges();
        }
    }
}
