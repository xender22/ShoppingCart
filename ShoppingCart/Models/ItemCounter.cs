using Microsoft.Build.Framework;

namespace ShoppingCart.Models;

public class ItemCounter
{
    public Item? Item { get; set; }
    public int Count { get; set; }
}