namespace ShoppingCart.Services;

public interface ICartService
{
    decimal CalculateItemsPrice(string itemIds);
}