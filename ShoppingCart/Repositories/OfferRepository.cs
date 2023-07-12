using ShoppingCart.Models;

namespace ShoppingCart.Repositories;

public class OfferRepository : IOfferRepository
{
    private static  List<Offer> _offers = new List<Offer>()
    {
        new Offer { Id = 1, ItemId = 'A', ItemCount = 3, SpecialPrice = 13 },
        new Offer { Id = 2, ItemId = 'B', ItemCount = 2, SpecialPrice = 4.50m }
    };


    public List<Offer> GetAllOffers()
    {
        return _offers;
    }

    public Offer? GetOfferByItemId(char itemId)
    {
        var offer = _offers.FirstOrDefault(x => x.ItemId == itemId);
        return offer;
    }
}