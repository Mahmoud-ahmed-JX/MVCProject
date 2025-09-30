
using BuisnessLogic.DTOS.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services.Interfaces
{
    public interface IEmployeeServices
    {
       
        public IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName,bool withTracking = false);

        public EmployeeDetailsDto GetEmployeeById(int id);
    
        public int CreateEmployee(CreatedEmployeeDto employeeDto);

        public int UpdatedEmployee(UpdatedEmployeeDto employeeDto);

        public bool DeleteEmployee(int id);
    }
}
