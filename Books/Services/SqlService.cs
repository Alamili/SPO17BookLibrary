using Books.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Books.Services
{
    public class SqlService : ISqlService
    {
        public ApplicationDbContext _db { get; set; }
        public SqlService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add<TEntity>(TEntity item) where TEntity : class
        {
            _db.Add(item);
            _db.SaveChanges();
        }

        public void Delete<TEntity>(TEntity item) where TEntity : class
        {
            _db.Remove(item);
            _db.SaveChanges();
        }

        public IQueryable<TEntity> Get<TEntity>() where TEntity : class
        {
            return _db.Set<TEntity>().AsQueryable();
        }

        public void Update<TEntity>(TEntity item) where TEntity : class
        {
            _db.Update(item);
            _db.SaveChanges();
        }

        //_db.Set<TEntity>().Include(entityName).Load();
    }
}
