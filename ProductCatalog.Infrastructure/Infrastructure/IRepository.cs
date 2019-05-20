using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Infrastructure.Infrastructure
{
    interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(params object[] id);
        void Add(TEntity entity);
        void Update(TEntity entity, UnitOfWork uow);
        void Delete(params object[] id);
    }
}
