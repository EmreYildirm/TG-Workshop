using Microsoft.EntityFrameworkCore;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductService.DataAccesLayer.Repositories
{
    /// <summary>
    /// The area we process in our database about products
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly TGDbContext _context;
        protected TGDbContext context { get { return _context; } }

        private readonly DbSet<Product> _dbSet;

        public ProductRepository(TGDbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<Product>();
        }
        /// <summary>
        /// Brings the products
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await GetAllProducts().ToListAsync();
        }
        /// <summary>
        /// Method that returns a queryable list
        /// </summary>
        /// <returns></returns>
        private IQueryable<Product> GetAllProducts()
        {
            return _dbSet.AsQueryable();
        }
    }
}
