using ShoppingCart.Models;

namespace ShoppingCart.Repositories;

public interface IItemRepository
{
    List<Item> GetAllItems();
    Item GetItemById(char id);
}