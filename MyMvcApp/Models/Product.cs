namespace MyMvcApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

    //model
  public class Product
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? Image { get; set; }
        
    [NotMapped]
    public IFormFile? ImageFile { get; set; }

    }