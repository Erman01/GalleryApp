using GalleryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Core.Contracts
{
    public interface IRepository<T> where T:BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        T Find(string id);
        void Insert(T TEntity);
        void Update(T TEntity);
        void Delete(string id);
    }
}
