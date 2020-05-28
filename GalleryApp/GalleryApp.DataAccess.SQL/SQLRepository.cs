using GalleryApp.Core.Contracts;
using GalleryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GalleryApp.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext _dataContext;
        internal DbSet<T> _dbSet;
        public SQLRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
            
        }
        public IQueryable<T> Collection()
        {
            return _dbSet;
        }

        public void Commit()
        {
            _dataContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var t = _dbSet.Find(id);
            if (_dataContext.Entry(t).State == EntityState.Detached)
                _dbSet.Attach(t);
            _dbSet.Remove(t);
        }

        public T Find(string id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T TEntity)
        {
            _dbSet.Add(TEntity);
        }

        public void Update(T TEntity)
        {
            _dbSet.Attach(TEntity);
            _dataContext.Entry(TEntity).State = EntityState.Modified;
        }
    }
}
