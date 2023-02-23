using ProductApp.ProductAppData.Context;
using ProductApp.ProductAppData.DataModel;
using ProductApp.ProductAppData.Repository;

namespace ProductApp.ProductAppData.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductAppDbContext _context;
    private IGenericRepository<Product> _productRepository;
    private IGenericRepository<List> _listRepository;
    private IGenericRepository<ListProduct> _listProductRepository;

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
    public IGenericRepository<List> ListRepository
    {
        get
        {
            _listRepository = new GenericRepository<List>(_context);
            return _listRepository;
        }
    }
    public IGenericRepository<ListProduct> ListProductRepository
    {
        get
        {
            _listProductRepository = new GenericRepository<ListProduct>(_context);
            return _listProductRepository;
        }
    }


    public void Save()
    {
        _context.SaveChanges();
    }
}