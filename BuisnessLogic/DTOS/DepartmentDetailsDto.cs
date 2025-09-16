using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.DTOS
{
    internal class DepartmentDetailsDto
    {
        public int Id { get; set; }

        public int CreatedBy { get; set; }
        public DateOnly? CreatedOn { get; set; }
        public int ModifiedBy { get; set; } //User ID
        public DateOnly? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public string? Description { get; set; }

        //public DepartmentDetailsDto(Department department)
        //{
        //    Id = department.Id;
        //    Code = department.Code;
        //    Name = department.Name;
        //    Description = department.Description;
        //    CreatedBy = department.CreatedBy;
        //    CreatedOn = department.CreatedOn.HasValue ? DateOnly.FromDateTime(department.CreatedOn.Value) : default;
        //    ModifiedBy = department.ModifiedBy;
        //    ModifiedOn = department.ModifiedOn.HasValue ? DateOnly.FromDateTime(department.ModifiedOn.Value) : default;
        //    IsDeleted = department.IsDeleted;

        //}
    }
}
