using BuisnessLogic.DTOS;
using BuisnessLogic.Factories;
using DataAccess.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services
{
    internal class DepartmentService(IDepartmentRepository _departmentRepository)
    {
        //private readonly IDepartmentRepository _departmentRepository = departmentRepository;

        //Get All =>Id , Code , Name , Description , DateOfCreation
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();
            return departments.Select(d => d.ToDepartmentDto() );

        }

        //Get By Id
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department=_departmentRepository.GetById(id);
            if(department is null)
                return null;
            //Auto Mapping => Package [AutoMapper]
            //Manual Mapping
            return department.ToDepartmentDetailsDto();
        }

        //Add
        public int AddDepartment(CreateDepartmentDto departmentDto)
        {
        var department = departmentDto.ToEntity();

            return _departmentRepository.Add(department);
        
        }

        //Update
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto) { 
        return _departmentRepository.Update(departmentDto.ToEntity());
        }

        //Delete
        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if(department is null)
                return false;
            int numOfRows=_departmentRepository.Remove(department);
            return numOfRows > 0;
        }
    }
}
