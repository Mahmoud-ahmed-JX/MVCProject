using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Shared
{
    public class BaseEntity//Include the common properties
    {
        public int Id { get; set; }

        public int CreatedBy { get; set; } 
        public DateTime? CreatedOn { get; set; }
        public int ModifiedBy { get; set; } //User ID
        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; } //Soft Delete
    }
}
