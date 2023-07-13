using ShoppingCart.Models;

namespace ShoppingCart.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly IOfferRepository _offerRepository;

    public ItemRepository(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }
    
    private static List<Item> _items = new List<Item>()
    {
        new Item { Id = 'A', Price = 5 },
        new Item { Id = 'B', Price = 3 },
        new Item { Id = 'C', Price = 2 },
        new Item { Id = 'D', Price = 1 }
    };

    public decimal CalculateItemsPrice(string itemIds)
    {
        var itemCounterList = new List<ItemCounter>(); // item counter list used to keep track of items and their respective count
        var itemIdsList = itemIds.ToCharArray(); // splits the string into individual id's
        foreach (var itemId in itemIdsList)
        {
            // getting the item
            var item = _items.FirstOrDefault(x => x.Id == itemId);
            if (item?.Id == null)  throw new ArgumentException($"Invalid item ID: {itemId}");
            
            // checking if the item exists in the item counter list
            var itemCounter = itemCounterList.FirstOrDefault(x => x.Item?.Id == item.Id);
            if (itemCounter != null)
            {
                itemCounter.Count++;
            }
            else
            {
                itemCounter = new ItemCounter
                {
                    Item = item,
                    Count = 1
                };
                itemCounterList.Add(itemCounter);
            }

            // getting the offer
            var offer = _offerRepository.GetOfferByItemId(item.Id);
            if (offer != null) item.Offer = offer;

        }

        var result = CalculateCounterList(itemCounterList);
        return result;
    }

    private decimal CalculateCounterList(List<ItemCounter> itemCounterList)
    {
        decimal result = 0;
        foreach (var itemCounter in itemCounterList)
        {
            // calculate item result if offer present
            if (itemCounter.Item?.Offer != null)
            {
                var normalRateMultiplier = itemCounter.Count % itemCounter.Item.Offer.ItemCount;
                var offerMultiplier = (int) Math.Floor((decimal)itemCounter.Count / itemCounter.Item.Offer.ItemCount);
                var normalSum = normalRateMultiplier * itemCounter.Item.Price;
                var offerSum = offerMultiplier * itemCounter.Item.Offer.SpecialPrice;

                result += normalSum + offerSum;
            }
            // calculate item result if no offer present
            else if (itemCounter.Item != null)
            {
                result += itemCounter.Item.Price * itemCounter.Count;
            }
        }

        return result;
    }
}