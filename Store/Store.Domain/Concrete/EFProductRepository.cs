using System;
using System.Collections.Generic;
using System.Text;
using Store.Domain.Abstract;
using Store.Domain.Entities;
using System.Linq;

namespace Store.Domain.Concrete
{
    public class EFProductRepository:IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
