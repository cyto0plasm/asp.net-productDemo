namespace MyMvcApp.Models;
public class ProductBL
{
    //database simulation
  private static List<Product> products = new List<Product>
  {
    new Product { Id=1, Name="Product one", Price=100, Image="bugati.jpg" },
    new Product { Id=2, Name="Product two", Price=200, Image="mustang.webp" },
    new Product { Id=3, Name="Product three", Price=300, Image="mustang2.webp" },
    new Product { Id=4, Name="Product four", Price=400, Image="bmw.jpg" },
    new Product { Id=5, Name="Product five", Price=500, Image="bugati2.jpg" },
    }; 
  
    //business logic
  public List<Product> GetAll()
  {
    return products;
  }
  public Product GetById(int id)
  {
    return products.FirstOrDefault(p => p.Id == id);
  }
}