using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Avenger.Repository
{
    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : BaseEntityModel<TKey>
    {
        private readonly DbContext _context;
        private DbSet<T> _table = null;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public void Delete(TKey id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }

        public IQueryable<T> GetAll(string includeForeignParameter = "", bool noTracking = false)
        {
            if (string.IsNullOrEmpty(includeForeignParameter))
                return _table;
            else
            {
                IQueryable<T> tmpQuery = _table;
                foreach (var includeParam in includeForeignParameter.Split(","))
                    tmpQuery = tmpQuery.Include(includeParam);
                if (noTracking)
                    return tmpQuery.AsNoTracking();
                else
                    return tmpQuery;
            }
        }

        //public IQueryable<T, TProperty> Include<T, TProperty>(IQueryable<T, TProperty>  source, Expression<Func<T, TProperty>> navigationPropertyPath)
        //{
        //    return source.Include<T, TProperty>(navigationPropertyPath);
        //}

        //public IIncludableQueryable<T, TProperty> Include<T, TProperty>(params Expression<Func<T, TProperty>>[] navigationPropertyPath)
        //{
        //    return null;
        //}

        //IIncludableQueryable<TEntity, TProperty> Include<TEntity, TProperty>([NotNullAttribute] this IQueryable<TEntity> source, [NotNullAttribute] Expression<Func<TEntity, TProperty>> navigationPropertyPath) where TEntity : class;


        //public IQueryable<T> Include(string includeForeignParameter = "")
        //{
        //    if (string.IsNullOrEmpty(includeForeignParameter))
        //        return _table;
        //    else
        //    {
        //        IQueryable<T> tmpQuery = _table;
        //        foreach (var includeParam in includeForeignParameter.Split(","))
        //            tmpQuery = tmpQuery.Include(includeParam);
        //        return tmpQuery;
        //    }
        //}

        public T GetById(TKey id)
        {
            return _table.Find(id);
        }

        public void Insert(T entity)
        {
            _table.Add(entity);
        }
        public void InsertRange(List<T> entities)
        {
            _table.AddRange(entities);
        }

        public void Update(T entity)
        {
            T dbEntity = _table.Find(entity.ID);
            _context.Entry(dbEntity).CurrentValues.SetValues(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
