using DataAccess.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity: BaseEntity 
    {
        void Add(TEntity department);
        IEnumerable<TEntity> GetAll(bool withTracking = false);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);

        TEntity? GetById(int Id);
        void Remove(TEntity department);
        void Update(TEntity department);
    }


    }

