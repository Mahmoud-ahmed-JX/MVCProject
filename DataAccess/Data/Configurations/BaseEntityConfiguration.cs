using DataAccess.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Configurations
{
    internal class BaseEntityConfiguration<T>:IEntityTypeConfiguration<T> where T:BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
          
            builder.Property("CreatedOn").HasDefaultValueSql("getdate()");
            builder.Property("ModifiedOn").HasComputedColumnSql("GETDATE()");
        }
    }
    
    }

