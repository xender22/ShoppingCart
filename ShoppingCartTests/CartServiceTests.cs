using Moq;
using ShoppingCart.Models;
using ShoppingCart.Repositories;
using ShoppingCart.Services;

namespace ShoppingCartTests;

[TestFixture]
    public class CartServiceTests
    {
        private CartService _cartService;
        private Mock<IOfferRepository> _mockOfferRepository;
        private Mock<IItemRepository> _mockItemRepository;

        [SetUp]
        public void Setup()
        {
            _mockOfferRepository = new Mock<IOfferRepository>();
            _mockItemRepository = new Mock<IItemRepository>();
            _cartService = new CartService(_mockOfferRepository.Object, _mockItemRepository.Object);
        }

        [Test]
        public void CalculateItemsPrice_ValidItemIds_ReturnsCorrectTotalPrice()
        {
            // Arrange
            var itemIds = "ABCD";
            var itemA = new Item { Id = 'A', Price = 5 };
            var itemB = new Item { Id = 'B', Price = 3 };
            var itemC = new Item { Id = 'C', Price = 2 };
            var itemD = new Item { Id = 'D', Price = 1 };

            _mockItemRepository.Setup(x => x.GetItemById('A')).Returns(itemA);
            _mockItemRepository.Setup(x => x.GetItemById('B')).Returns(itemB);
            _mockItemRepository.Setup(x => x.GetItemById('C')).Returns(itemC);
            _mockItemRepository.Setup(x => x.GetItemById('D')).Returns(itemD);
            
            // You can add mock setup for the offer repository if needed

            // Act
            var totalPrice = _cartService.CalculateItemsPrice(itemIds);

            // Assert
            var expectedTotalPrice = 5 + 3 + 2 + 1;
            Assert.AreEqual(expectedTotalPrice, totalPrice);
        }

        [Test]
        public void CalculateItemsPrice_InvalidItemId_ThrowsArgumentException()
        {
            // Arrange
            var itemIds = "ABCDE";
            var itemA = new Item { Id = 'A', Price = 5 };
            _mockItemRepository.Setup(x => x.GetItemById('A')).Returns(itemA);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => _cartService.CalculateItemsPrice(itemIds));
        }
    }