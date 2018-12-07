using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;
using Web.Models.AccountViewModel;

namespace Web.Repository.Implement
{
    public class UserRepository : IRepository<User>
    {

        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            _context.Add(entity);
        }

        public void AddRange(IEnumerable<User> entities)
        {
            _context.AddRange(entities);
        }

        public void Delete(User entity)
        {
            _context.Remove(entity);
        }

        public User Get(Guid id)
        {
            return _context.User.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User;
        }

        public void Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public User GetUserRole(LoginModel model)
        {
            return _context.User
                                .Include(u => u.UserRole)
                                .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
        }
    }
}
