using AutoMapper;
using BuisnessLogic.DTOS.EmployeeDtos;
using BuisnessLogic.Services.Interfaces;
using DataAccess.Data.Repositories.Classes;
using DataAccess.Data.Repositories.Interfaces;
using DataAccess.Models.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services.Classes
{
    public class EmployeeServices(IUnitOfWork _unitOfWork,IMapper _mapper) : IEmployeeServices

    {
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
           var employee= _mapper.Map<CreatedEmployeeDto,Employee>(employeeDto);
            _unitOfWork.Employees.Add(employee);
            return _unitOfWork.SaveChanges();
        }

      

        public IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName,bool withTracking = false)
        {
            IEnumerable<Employee> employees;
            if (!string.IsNullOrWhiteSpace(EmployeeSearchName))
            {
                employees = _unitOfWork.Employees.GetAll(e => e.Name.ToLower().Contains(EmployeeSearchName.ToLower()));
            }
            else
                employees = _unitOfWork.Employees.GetAll(withTracking);
                //.Select(
                //    e => _mapper.Map<EmployeeDto>(e)
                //);

            var employeeDtos = _mapper.Map<IEnumerable<Employee>,IEnumerable<EmployeeDto>>(employees);
            //e =>
            //new EmployeeDto
            //{
            //    Id = e.Id,
            //    Name = e.Name,
            //    Age = e.Age,
            //    Salary = e.Salary,
            //    IsActive = e.IsActive,
            //    Email = e.Email,
            //    Gender = e.Gender.ToString(),
            //    EmployeeType = e.EmployeeType.ToString(),
            //}

            //);

            return employeeDtos;
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _unitOfWork.Employees.GetById(id);
            if (employee is null) return null;
            else
                return _mapper.Map<Employee,EmployeeDetailsDto>(employee);
            //return new EmployeeDetailsDto
            //{
            //    Id = employee.Id,
            //    Name = employee.Name,
            //    Age = employee.Age,
            //    Address = employee.Address,
            //    Salary = employee.Salary,
            //    IsActive = employee.IsActive,
            //    Email = employee.Email,
            //    PhoneNumber = employee.PhoneNumber,
            //    HiringDate = DateOnly.FromDateTime(employee.HiringDate),
            //    CreatedOn = employee.CreatedOn,
            //    ModifiedOn = employee.ModifiedOn,
            //    CreatedBy = 1,
            //    ModifiedBy = 1,
            //    EmployeeType = employee.EmployeeType.ToString(),
            //    Gender = employee.Gender.ToString(),
            //};
        }

        public int UpdatedEmployee(UpdatedEmployeeDto employeeDto)
        {
             _unitOfWork.Employees.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto));
            return _unitOfWork.SaveChanges();

        }

        public bool DeleteEmployee(int id)
        {
            var employee = _unitOfWork.Employees.GetById(id);
            if (employee is null) return false;

            employee.IsDeleted = true;
            _unitOfWork.Employees.Update(employee);
          
            return _unitOfWork.SaveChanges()>0;

        }

    }
}
