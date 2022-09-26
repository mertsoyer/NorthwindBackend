using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SP14MERTS;Database=Northwind;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims{ get; set; }

    }
}
