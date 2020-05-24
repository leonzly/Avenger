using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Avenger.Repository
{
    public interface IGenericRepository<T, TKey> where T : BaseEntityModel<TKey>
    {
        IQueryable<T> GetAll(string includeForeignParameter = "", bool noTracking = false);
        //IIncludableQueryable<T, TProperty> Include<T, TProperty>(params Expression<Func<T, TProperty>>[] navigationPropertyPath);

        T GetById(TKey id);
        void Insert(T entity);
        void InsertRange(List<T> entities);
        void Update(T entity);
        void Delete(TKey id);
        void Save();
    }
}
