namespace MyMvcApp.Models;
public class ProductBL
{
    //database simulation
  private static List<Product> products = new List<Product>
  {
    new() { Id=1, Name="Product one", Price=100, Image="bugati.jpg" },
    new() { Id=2, Name="Product two", Price=200, Image="mustang.webp" },
    new() { Id=3, Name="Product three", Price=300, Image="mustang2.webp" },
    new() { Id=4, Name="Product four", Price=400, Image="bmw.jpg" },
    new() { Id=5, Name="Product five", Price=500, Image="bugati2.jpg" },
    }; 
  
    //business logic
  public List<Product> GetAll()
  {
    return products;
  } 
  public Product? GetById(int id)
  {
    return products.FirstOrDefault(p => p.Id == id);
  }
  public Product Create(Product product)
  {
    product.Id = products.Max(p => p.Id) + 1;
    products.Add(product);
    return product;
  }
  public Product Update(int id, Product product)
  {
    var existingProduct = GetById(id);
    if (existingProduct != null)
    {
      products.Remove(existingProduct);
      products.Add(product);
    }
    return product;
  }
  public void Delete(int id)
  {
    var product = GetById(id);
    if (product != null)
    {
      products.Remove(product);
    }
  }
}