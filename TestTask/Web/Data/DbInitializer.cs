using Core.Entity;
using System;
using System.Linq;

namespace Web.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.UserRoles.Any())
            {
                var roles = new UserRole[]
                {
                    new UserRole
                    {
                        ID = Guid.NewGuid(),
                        Name = "admin"
                    },
                    new UserRole
                    {
                        ID = Guid.NewGuid(),
                        Name = "user"
                    }
                };

                context.UserRoles.AddRange(roles);

                context.SaveChanges();

            }

            var idAdmin = context.UserRoles.FirstOrDefault(t => t.Name == "admin").ID;

            if (context.User.FirstOrDefault(x => x.UserRoleID == idAdmin) == null)
            {
                var user = new User
                {
                    ID = Guid.NewGuid(),
                    Email = "admin@gmail.com",
                    Password = "123456",
                    UserRoleID = idAdmin
                };

                context.User.Add(user);

                context.SaveChanges();


            }

            if (!context.Catalogs.Any())
            {
                var catalogs = new Catalog[]
                {
                    new Catalog
                    {
                        ID = Guid.NewGuid(),
                        Name = "Mobile"
                    },
                    new Catalog
                    {
                        ID = Guid.NewGuid(),
                        Name = "Electronic"
                    }
                };

                context.Catalogs.AddRange(catalogs);

                context.SaveChanges();
            }
        }
    }
}