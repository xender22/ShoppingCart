using ShoppingCart.Models;

namespace ShoppingCart.Repositories;

public class ItemRepository : IItemRepository
{
    private static List<Item> _items = new List<Item>()
    {
        new Item { Id = 'A', Price = 5 },
        new Item { Id = 'B', Price = 3 },
        new Item { Id = 'C', Price = 2 },
        new Item { Id = 'D', Price = 1 }
    };

    public List<Item> GetAllItems()
    {
        return _items;
    }

    public Item GetItemById(char id)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        return item;
    }
}