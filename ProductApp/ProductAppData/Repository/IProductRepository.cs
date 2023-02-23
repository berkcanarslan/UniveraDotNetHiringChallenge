using ProductApp.ProductAppData.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApp.ProductAppData.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByListIdAsync(int listId);
    }
}