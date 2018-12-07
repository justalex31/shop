using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Data;

namespace Web.Repository.Implement
{
    public class RoleRepository : IRepository<UserRole>
    {

        private ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(UserRole entity)
        {
            _context.Add(entity);
        }

        public void AddRange(IEnumerable<UserRole> entities)
        {
            _context.AddRange(entities);
        }

        public void Delete(UserRole entity)
        {
            _context.Remove(entity);
        }

        public UserRole Get(Guid id)
        {
            return _context.UserRoles.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<UserRole> GetAll()
        {
            return _context.UserRoles;
        }

        public void Update(UserRole entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
