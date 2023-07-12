using Moq;
using ShoppingCart.Models;
using ShoppingCart.Repositories;

namespace ShoppingCartTests;

[TestFixture]
public class ItemRepositoryTests
{
    private ItemRepository _itemRepository;
    private Mock<IOfferRepository> _offerRepositoryMock;

    [SetUp]
    public void SetUp()
    {
        _offerRepositoryMock = new Mock<IOfferRepository>();
        _itemRepository = new ItemRepository(_offerRepositoryMock.Object);
    }

    [Test]
    public void CalculateItemsPrice_WithValidItems_ReturnsCorrectTotalPrice()
    {
        // Arrange
        string itemIds = "ABAC";

        // Act
        var totalPrice = _itemRepository.CalculateItemsPrice(itemIds);

        // Assert
        Assert.AreEqual(15, totalPrice);
    }

    [Test]
    public void CalculateItemsPrice_WithInvalidItem_ThrowsArgumentException()
    {
        // Arrange
        string itemIds = "ABCDX";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _itemRepository.CalculateItemsPrice(itemIds));
    }

    [Test]
    public void CalculateItemsPrice_WithOffer_ReturnsCorrectTotalPrice()
    {
        // Arrange
        string itemIds = "AAA";
        var offer = new Offer { ItemCount = 3, SpecialPrice = 13 };
        _offerRepositoryMock.Setup(r => r.GetOfferByItemId('A')).Returns(offer);

        // Act
        var totalPrice = _itemRepository.CalculateItemsPrice(itemIds);

        // Assert
        Assert.AreEqual(13, totalPrice);
    }
}