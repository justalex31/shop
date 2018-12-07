using System;
using Web.Data;
using Web.Repository.Implement;

namespace Web.Models
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        private CatalogRepository _catalog;
        private UserRepository _user;
        private RoleRepository _role;
        private ProductRepository _product;
        private OrderRepository _order;

        private bool disposed = false;

        public ApplicationDbContext Context
        {
            get { return _context; }
            set
            {
                if (_context != value)
                    _context = value;
            }
        }

        public OrderRepository Order
        {
            get
            {
                if (_order == null)
                    _order = new OrderRepository(Context);
                return _order;
            }
        }

        public CatalogRepository Catalog
        {
            get
            {
                if (_catalog == null)
                    _catalog = new CatalogRepository(Context);
                return _catalog;
            }
        }

        public UserRepository User
        {
            get
            {
                if (_user == null)
                    _user = new UserRepository(Context);
                return _user;
            }
        }

        public RoleRepository Role
        {
            get
            {
                if (_role == null)
                    _role = new RoleRepository(Context);
                return _role;
            }
        }

        public ProductRepository Product
        {
            get
            {
                if (_product == null)
                    _product = new ProductRepository(Context);
                return _product;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
