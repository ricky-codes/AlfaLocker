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
            _dbContext.Configuration.LazyLoadingEnabled = false;
        }

        public T GetByID<T>(int id) where T : BaseEntity, IAggregateRoot
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.id == id);
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

                return entity;
            }
            
            catch(Exception err)
            {
                string eee = err.InnerException.ToString();
                return null;
            }
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

        public void Delete<T>(int id) where T : BaseEntity, IAggregateRoot
        {
            T entityToDelete = _dbContext.Set<T>().Find(id);
            Delete<T>(entityToDelete);
        }



    }
}
