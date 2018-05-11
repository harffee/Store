using System;
using System.Collections.Generic;
using System.Text;
using Store.Domain.Entities;
using System.Data.Entity;

namespace Store.Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        public DbSet<Product> Products { get; set;  }
    }
}
