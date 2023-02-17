using ProductApp.ProductAppData.Context;
using ProductApp.ProductAppData.DataModel;
using ProductApp.ProductAppData.Repository;

namespace ProductApp.ProductAppData.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductAppDbContext _context;
    private IGenericRepository<Product> _productRepository;

    public UnitOfWork(ProductAppDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<Product> ProductRepository
    {
        get
        {
                _productRepository = new GenericRepository<Product>(_context);
                return _productRepository;
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}