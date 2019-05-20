using ProductCatalog.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Infrastructure.Infrastructure
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity:class
    {
        private DbSet<TEntity> _set;
        public RepositoryBase(ProductCatalogModel _ctx)
        {
            this._set = _ctx.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _set;
        }

        public TEntity GetById(params object[] id)
        {
            return _set.Find(id);
        }

        public void Add(TEntity entity)
        {
            _set.Add(entity);
        }

        public void Update(TEntity entity, UnitOfWork uow)
        {
            uow.Update(entity);
        }

        public void Delete(params object[] id)
        {
            _set.Remove(_set.Find(id));
        }
    }
}
