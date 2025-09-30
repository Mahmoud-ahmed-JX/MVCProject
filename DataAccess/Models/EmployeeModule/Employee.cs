using DataAccess.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Models.EmployeeModule
{
    public class Employee:BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [Range(24,50)]
        public int Age { get; set; }
        [MaxLength(50)]
        public string Address { get; set; } = null!;

        public decimal Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime HiringDate { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public Gender Gender { get; set; }

        public virtual Department? Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
