using DAL;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<ProductModel> GetProducts();
    }
}
