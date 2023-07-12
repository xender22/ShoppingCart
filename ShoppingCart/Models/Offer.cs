namespace ShoppingCart.Models;

public class Offer
{
    public int Id { get; set; }
    public char ItemId { get; set; }
    public int ItemCount { get; set; }
    public decimal SpecialPrice { get; set; }
}