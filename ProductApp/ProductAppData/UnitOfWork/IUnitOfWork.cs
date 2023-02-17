using ProductApp.ProductAppData.DataModel;
using ProductApp.ProductAppData.Repository;

namespace ProductApp.ProductAppData.UnitOfWork;

public interface IUnitOfWork
{
    IGenericRepository<Product> ProductRepository { get; }
    void Save();
}