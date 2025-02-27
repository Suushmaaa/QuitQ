

namespace QuitQ_Hexaware.Models;


public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Navigation properties
    public List<Product>? Products { get; set; }
}