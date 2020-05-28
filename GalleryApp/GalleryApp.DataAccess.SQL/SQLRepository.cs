using GalleryApp.Core.Contracts;
using GalleryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public T Find(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T TEntity)
        {
            throw new NotImplementedException();
        }

        public void Update(T TEntity)
        {
            throw new NotImplementedException();
        }
    }
}
