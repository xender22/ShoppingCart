using ShoppingCart.Models;

namespace ShoppingCart.Repositories;

public interface IOfferRepository
{
    List<Offer> GetAllOffers();
    Offer? GetOfferByItemId(char itemId);
}