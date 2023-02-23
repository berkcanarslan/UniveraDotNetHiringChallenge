using Microsoft.AspNetCore.Mvc;
using ProductApp.ProductAppData.UnitOfWork;
namespace ProductApp.Controllers;

public class ProductController:Controller
{   
    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IActionResult> ProductList()
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync();
        return View(products);
    }
}