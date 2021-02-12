using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManagerCA.SharedKernel;
using PasswordManagerCA.SharedKernel.Interfaces;

namespace PasswordManagerCA.Infrastructure.Data.Config
{
    public class EFRepository : IRepository
    {

        private readonly AppDbModel _dbContext;

        public EFRepository(AppDbModel dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetByID<T>(int id) where T : BaseEntity, IAggregateRoot
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public IQueryable<T> GetAll<T>() where T : BaseEntity, IAggregateRoot
        {
            return _dbContext.Set<T>();
        }


        public T Insert<T>(T entity) where T : BaseEntity, IAggregateRoot
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                string er = e.InnerException.ToString();
            }
            
            return entity;
        }

        public int Update<T>(int id, T entity) where T : BaseEntity, IAggregateRoot
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int Delete<T>(T entity) where T : BaseEntity, IAggregateRoot
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges();
        }

        
        
    }
}
