using ECommerce.Models;

namespace ECommerce.ViewModel
{
  public class HomeViewModel
  {
    public User User { get; set; }
    public Product Product { get; set; }
    public Inventory Inventory { get; set; }
    public Category Category { get; set; }
    public Cart Cart { get; set; }
    public Theme Theme { get; set; }
  }
}