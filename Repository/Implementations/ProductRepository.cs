using DAL;
using DomainModels;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public DatabaseContext context
        {
            get
            {
                return _db as DatabaseContext;
            }
        }
        public ProductRepository(DbContext db) : base(db)
        {

        }
        public IEnumerable<ProductModel> GetProducts()
        {
            var data = (from prd in context.Products
                        join cat in context.Categories
                        on prd.CategoryId equals cat.CategoryId
                        select new ProductModel
                        {
                            ProductId = prd.ProductId,
                            Name = prd.Name,
                            UnitPrice = prd.UnitPrice,
                            Description = prd.Description,
                            Category = cat.Name
                        }).ToList();
            return data;
        }
    }
}
