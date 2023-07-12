namespace ShoppingCart.Repositories;

public interface IItemRepository
{
    decimal CalculateItemsPrice(string items);
}