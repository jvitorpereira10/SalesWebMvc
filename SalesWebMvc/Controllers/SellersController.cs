using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
  public class SellersController : Controller
  {
    private readonly SellerService _sellerService;
    private readonly DepartmentService _departmentService;

    public SellersController(SellerService sellerService, DepartmentService departmentService)
    {
      _sellerService = sellerService;
      _departmentService = departmentService;
    }

    public IActionResult Index()
    {
      var listSellers = _sellerService.FindAll();      
      return View(listSellers);
    }

    public IActionResult Create()
    {
      var listDepartments = _departmentService.FindAll();
      var viewModel = new SellerFormViewModel { Departments = listDepartments };
      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller seller)
    {
      _sellerService.Insert(seller);
      return RedirectToAction(nameof(Index));
    }
  }
}
