namespace ShoppingCart.Models;

public class Item
{
    public char Id { get; set; }
    public decimal Price { get; set; }
    public Offer? Offer { get; set; }
}