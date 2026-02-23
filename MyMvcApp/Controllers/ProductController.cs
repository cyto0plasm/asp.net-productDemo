namespace MyMvcApp.Controllers;
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
    public IActionResult Create()
    {
        return View();
    }
   [HttpPost]
public IActionResult Create(Product product)
{
    if (ModelState.IsValid)
    {
        if (product.ImageFile != null)
        {
            string fileName = Path.GetFileName(product.ImageFile.FileName);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                                           "wwwroot/images",
                                           fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                product.ImageFile.CopyTo(stream);
            }

            product.Image = fileName;
        }

        productBl.Create(product);
        return RedirectToAction(nameof(Index));
    }

    return View(product);
}
    public IActionResult Edit(int id)
    {
        var product = productBl.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }
  [HttpPost]
public IActionResult Edit(int id, Product product)
{
    if (ModelState.IsValid)
    {
        var existingProduct = productBl.GetById(id);

        if (existingProduct == null)
            return NotFound();

        // Update basic fields
        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;

        // If new image uploaded
        if (product.ImageFile != null)
        {
            string fileName = Path.GetFileName(product.ImageFile.FileName);

            string filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/images",
                fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                product.ImageFile.CopyTo(stream);
            }

            existingProduct.Image = fileName;
        }

        productBl.Update(id, existingProduct);

        return RedirectToAction(nameof(Index));
    }

    return View(product);
}
   [HttpPost]
public IActionResult Delete(int id)
{
    var product = productBl.GetById(id);

    if (product == null)
        return NotFound();

    productBl.Delete(id);

    return RedirectToAction(nameof(Index));
}
    
}