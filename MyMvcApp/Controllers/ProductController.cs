namespace MyMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;
public class ProductController : Controller
{
    ProductBL productBl = new ProductBL();

    public IActionResult Index()
    {
        var products = productBl.GetAll();
        return View(products);
    }
    public IActionResult Details(int id)
    {
        var product = productBl.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }
}