using DataAccess.Data.context;
using DataAccess.Data.Repositories.Interfaces;
using DataAccess.Models.EmployeeModule;
using DataAccess.Models.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Repositories.Classes
{
    public class GenericRepository<TEntity>(ApplicationDbContext _dbContext):IGenericRepository<TEntity> where TEntity:BaseEntity
    {
        public IEnumerable<TEntity> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Set<TEntity>().Where(entity=>entity.IsDeleted==false).ToList();
            }
            else
            {
                return _dbContext.Set<TEntity>().Where(entity => entity.IsDeleted == false).AsNoTracking().ToList();
            }
        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            
                return _dbContext.Set<TEntity>().Where(expression).Where(entity => entity.IsDeleted == false).ToList();
            
          
        }


        //GetById
        public TEntity? GetById(int Id) => _dbContext.Set<TEntity>().Find(Id);

        //Add
        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
           
        }

        //Update
        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
         
        }

        //Remove
        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            
        }
    }
}
