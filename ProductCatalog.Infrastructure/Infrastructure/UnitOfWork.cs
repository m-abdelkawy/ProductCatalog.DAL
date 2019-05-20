using ProductCatalog.DAL;
using ProductCatalog.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Infrastructure.Infrastructure
{
    public class UnitOfWork : IDisposable
    {
        private ProductCatalogModel _ctx = new ProductCatalogModel();

        public ProductRepository ProductRepository
        {
            get { return new ProductRepository(_ctx); }
        }

        public int Commit()
        {
            return _ctx.SaveChanges();
        }

        internal void Update<T>(T entity) where T : class
        {
            _ctx.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(_ctx);
        }
    }
}
