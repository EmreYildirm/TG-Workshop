using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductService.DataAccesLayer.Repositories
{
    /// <summary>
    /// Interface that carries out database-related operations of our products
    /// </summary>
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}
