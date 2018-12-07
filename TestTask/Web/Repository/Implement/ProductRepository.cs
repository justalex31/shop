using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Data;

namespace Web.Repository.Implement
{
    public class ProductRepository : IRepository<Product>
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) => _context = context;

        public void Add(Product entity) => _context.Products.Add(entity);

        public void AddRange(IEnumerable<Product> entities) => _context.Products.AddRange(entities);

        public void Delete(Product entity) => _context.Products.Remove(entity);

        public Product Get(Guid id) => _context.Products.FirstOrDefault(x => x.ID == id);

        public IEnumerable<Product> GetAll() => _context.Products;

        public void Update(Product entity) => _context.Entry(entity).State = EntityState.Modified;

        public IEnumerable<Product> GetAllWithIncludes() => _context.Products
                                        .Include(x => x.Catalog)
                                        .Include(x => x.Rates);

        public Product GetWithCatalog(Guid id) => _context.Products
                                .Include(x => x.Catalog)
                                    .FirstOrDefault(x => x.ID == id);
    }
}
