using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;

namespace Web.Repository.Implement
{
    public class OrderRepository : IRepository<Order>
    {
        private ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Order entity)
        {
            _context.Orders.Add(entity);
        }

        public void AddRange(IEnumerable<Order> entities)
        {
            _context.Orders.AddRange(entities);
        }

        public void Delete(Order entity)
        {
            _context.Orders.Remove(entity);
        }

        public Order Get(Guid id)
        {
            return _context.Orders.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }

        public void Update(Order entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<Order> GetAllInclude()
        {
            return _context.Orders
                            .Include(x => x.Product)
                            .Include(x => x.ShipStatus)
                            .Include(x => x.User)
                            .Include(x => x.TypeShip);
        }
    }
}
