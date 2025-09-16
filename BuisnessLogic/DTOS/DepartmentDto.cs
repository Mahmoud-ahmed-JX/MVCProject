using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.DTOS
{
    internal class DepartmentDto
    {
        public int Id { get; set; }

        public string Code { get; set; }=string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }
        public DateOnly DateOfCreation { get; set; }
    }
}
