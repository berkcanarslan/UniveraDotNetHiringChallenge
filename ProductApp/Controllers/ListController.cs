using Microsoft.AspNetCore.Mvc;
using ProductApp.ProductAppData.Repository;
using ProductApp.ProductAppData.UnitOfWork;
namespace ProductApp.Controllers;

public class ListController:Controller
{   
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;

    public ListController(IUnitOfWork unitOfWork,IProductRepository productRepository)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var lists = await _unitOfWork.ListRepository.GetAllAsync();
        return View(lists);
    }
    public async Task<IActionResult> ProductsInList(int listId)
    {
        var products = await _productRepository.GetProductsByListIdAsync(listId);
        return View(products);
    }
}