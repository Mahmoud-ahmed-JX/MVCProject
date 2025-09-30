using BuisnessLogic.DTOS.DepartmentDtos;
using BuisnessLogic.Factories;
using BuisnessLogic.Services.Interfaces;
using DataAccess.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services.Classes
{
    public class DepartmentService(IUnitOfWork _unitOfWork) : IDepartmentService
    {
        //private readonly IDepartmentRepository _departmentRepository = departmentRepository;

        //Get All =>Id , Code , Name , Description , DateOfCreation
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _unitOfWork.Departments.GetAll();
            return departments.Select(d => d.ToDepartmentDto());

        }

        //Get By Id
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _unitOfWork.Departments.GetById(id);
            if (department is null)
                return null;
            //Auto Mapping => Package [AutoMapper]
            //Manual Mapping
            return department.ToDepartmentDetailsDto();
        }

        //Add
        public int AddDepartment(CreateDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();

             _unitOfWork.Departments.Add(department);
            return _unitOfWork.SaveChanges();
        }

        //Update
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            _unitOfWork.Departments.Update(departmentDto.ToEntity());
            return _unitOfWork.SaveChanges();
        }

        //Delete
        public bool DeleteDepartment(int id)
        {
            var department = _unitOfWork.Departments.GetById(id);
            if (department is null)
                return false;
             _unitOfWork.Departments.Remove(department);
            return _unitOfWork.SaveChanges() > 0;
        }
    }
}
