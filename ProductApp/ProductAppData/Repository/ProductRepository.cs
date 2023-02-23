using Microsoft.EntityFrameworkCore;
using ProductApp.ProductAppData.Context;
using ProductApp.ProductAppData.DataModel;
using ProductApp.ProductAppData.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProductApp.ProductAppData.UnitOfWork;

namespace ProductApp.ProductAppData.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductAppDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public ProductRepository(ProductAppDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetProductsByListIdAsync(int listId)
        {
            return await _dbContext.ListProducts
                .Include(lp => lp.Product)
                .Where(lp => lp.ListId == listId)
                .Select(lp => lp.Product)
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id, params Expression<Func<Product, object>>[] includes)
        {
            IQueryable<Product> query = _dbContext.Products;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task AddAsync(Product entity)
        {
            await _dbContext.Products.AddAsync(entity);
        }

        public void Update(Product entity)
        {
            _dbContext.Products.Update(entity);
        }

        public void Delete(Product entity)
        {
            _dbContext.Products.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}