using DataAccess.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity: BaseEntity 
    {
        int Add(TEntity department);
        IEnumerable<TEntity> GetAll(bool withTracking = false);
        TEntity? GetById(int Id);
        int Remove(TEntity department);
        int Update(TEntity department);
    }


    }

