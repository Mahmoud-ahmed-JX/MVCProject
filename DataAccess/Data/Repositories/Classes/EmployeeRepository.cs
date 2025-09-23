using DataAccess.Data.context;
using DataAccess.Data.Repositories.Interfaces;
using DataAccess.Models.EmployeeModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repositories.Classes
{
    public class EmployeeRepository(ApplicationDbContext _dbContext) :GenericRepository<Employee>(_dbContext),IEmployeeRepository
    {
       
    }
}
