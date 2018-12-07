using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Data;

namespace Web.Repository.Implement
{
    public class CatalogRepository : IRepository<Catalog>
    {
        private ApplicationDbContext _context;

        public CatalogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Catalog entity)
        {
            _context.Catalogs.Add(entity);
        }

        public void AddRange(IEnumerable<Catalog> entities)
        {
            _context.Catalogs.AddRange(entities);
        }

        public void Delete(Catalog entity)
        {
            _context.Catalogs.Remove(entity);
        }

        public Catalog Get(Guid id)
        {
            return _context.Catalogs.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Catalog> GetAll()
        {
            return _context.Catalogs;
        }

        public void Update(Catalog entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
