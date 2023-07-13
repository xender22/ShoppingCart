using ShoppingCart.Repositories;

namespace ShoppingCartTests;

[TestFixture]
public class ItemRepositoryTests
{
    private ItemRepository _itemRepository;

    [SetUp]
    public void Setup()
    {
        _itemRepository = new ItemRepository();
    }

    [Test]
    public void GetAllItems_ReturnsAllItems()
    {
        // Arrange

        // Act
        var items = _itemRepository.GetAllItems();

        // Assert
        Assert.AreEqual(4, items.Count);
        Assert.IsTrue(items.Exists(i => i.Id == 'A' && i.Price == 5));
        Assert.IsTrue(items.Exists(i => i.Id == 'B' && i.Price == 3));
        Assert.IsTrue(items.Exists(i => i.Id == 'C' && i.Price == 2));
        Assert.IsTrue(items.Exists(i => i.Id == 'D' && i.Price == 1));
    }

    [Test]
    public void GetItemById_ExistingId_ReturnsItem()
    {
        // Arrange
        var id = 'B';

        // Act
        var item = _itemRepository.GetItemById(id);

        // Assert
        Assert.IsNotNull(item);
        Assert.AreEqual(id, item.Id);
        Assert.AreEqual(3, item.Price);
    }

    [Test]
    public void GetItemById_NonExistingId_ReturnsNull()
    {
        // Arrange
        var id = 'Z';

        // Act
        var item = _itemRepository.GetItemById(id);

        // Assert
        Assert.IsNull(item);
    }
}