using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ProductCatalog.DAL;
using ProductCatalog.DAL.Models;
using ProductCatalog.Infrastructure.Infrastructure;

namespace ProductCatalog.BLL.Controllers
{
    //[EnableCors(origins: "*", headers:"*", methods:"*")]
    public class ProductsController : ApiController
    {
        private UnitOfWork uow = new UnitOfWork();

        // GET: api/Products
        public IQueryable<Product> GetProducts()
        {
            return uow.ProductRepository.GetAll();
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = uow.ProductRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            uow.ProductRepository.Update(product, uow);

            try
            {
                uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            uow.ProductRepository.Add(product);
            uow.Commit();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = uow.ProductRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            uow.ProductRepository.Delete(id);
            uow.Commit();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return uow.ProductRepository.GetAll().Count(p => p.Id == id) > 0;
        }
    }
}