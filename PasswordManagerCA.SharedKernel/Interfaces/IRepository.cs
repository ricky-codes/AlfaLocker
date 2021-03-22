using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerCA.SharedKernel.Interfaces
{
    public interface IRepository
    {
        IQueryable<T> GetAll<T>() where T : BaseEntity, IAggregateRoot;
        T GetByID<T>(int id) where T : BaseEntity, IAggregateRoot;
        T Insert<T>(T entity) where T : BaseEntity, IAggregateRoot;
        int Update<T>(int id, T entity) where T : BaseEntity, IAggregateRoot;
        int Delete<T>(T entity) where T : BaseEntity, IAggregateRoot;
        void Delete<T>(int id) where T : BaseEntity, IAggregateRoot;
    }
}
