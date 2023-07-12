using ShoppingCart.Models;
using ShoppingCart.Repositories;

namespace ShoppingCartTests;

[TestFixture]
public class OfferRepositoryTests
{
    private OfferRepository _offerRepository;

    [SetUp]
    public void SetUp()
    {
        _offerRepository = new OfferRepository();
    }

    [Test]
    public void GetAllOffers_ReturnsAllOffers()
    {
        // Act
        List<Offer> offers = _offerRepository.GetAllOffers();

        // Assert
        Assert.AreEqual(2, offers.Count);
        Assert.IsTrue(offers.Any(o => o.ItemId == 'A' && o.ItemCount == 3 && o.SpecialPrice == 13));
        Assert.IsTrue(offers.Any(o => o.ItemId == 'B' && o.ItemCount == 2 && o.SpecialPrice == 4.50m));
    }

    [Test]
    public void GetOfferByItemId_WithExistingItemId_ReturnsOffer()
    {
        // Arrange
        var itemId = 'A';

        // Act
        var offer = _offerRepository.GetOfferByItemId(itemId);

        // Assert
        Assert.IsNotNull(offer);
        Assert.AreEqual(itemId, offer.ItemId);
        Assert.AreEqual(3, offer.ItemCount);
        Assert.AreEqual(13, offer.SpecialPrice);
    }

    [Test]
    public void GetOfferByItemId_WithNonExistingItemId_ReturnsNull()
    {
        // Arrange
        var itemId = 'C';

        // Act
        var offer = _offerRepository.GetOfferByItemId(itemId);

        // Assert
        Assert.IsNull(offer);
    }
}