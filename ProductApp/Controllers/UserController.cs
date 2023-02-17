using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ProductApp.ProductAppData.DataModel;
using ProductApp.ProductAppData.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductApp.ProductAppData.UnitOfWork;

namespace ProductApp.Controllers;

public class UserController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("/products")]
    public async Task<IActionResult> GetProductList(int userId)
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync();

        return Ok(products.Where(p => p.CreatedBy == userId));
    }
}