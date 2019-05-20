using ProductCatalog.DAL;
using ProductCatalog.DAL.Models;
using ProductCatalog.Infrastructure.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Infrastructure.Repositories
{
    public class ProductRepository:RepositoryBase<Product>
    {
        public ProductRepository(ProductCatalogModel _ctx) : base(_ctx) { }
    }
}
