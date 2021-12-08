using CQRSlite.Domain;
using Domain.Events;
using Domain.ValObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Inventory
{
    /*public class Inventory : AggregateRoot
    {
        public List<InventoryItem> InventoryItems { get; private set; }

        private Inventory() { }
        public Inventory(List<InventoryItem> inventoryItems)
        {
            InventoryItems = inventoryItems;
        }

        //  Rehydrate
        public void Apply(ItemAddedtoInventoryEvent e)
        {
            InventoryItems.Add(new InventoryItem(e.InventoryItemId, e.ProductItemId, e.UnitsInStock));
        }

        public void Apply(ItemRemovedFromInventoryEvent e)
        {
            InventoryItems.Remove(InventoryItems.First(x => x.InventoryItemId == e.InventoryItemId));
        }

        public void Apply(StockAddedToInventoryItemEvent e)
        {
            InventoryItems.First(x => x.InventoryItemId == e.InventoryItemId).AddItemsToInventory(e.UnitsReceived);
        }

        //  Business Logic
        public void AddItemOrStockToInventory(int inventoryItemId, int count)
        {
            if (count.Equals(0) && count < 0)
                throw new Exception("Inventory Item must have items.");

            InventoryItem? item = InventoryItems.FirstOrDefault(x => x.InventoryItemId == inventoryItemId);

            if (!InventoryItems.Any(x => x.InventoryItemId == inventoryItemId))
            {
                //  Create New Inventory Item
                ApplyChange(new ItemAddedtoInventoryEvent(Guid.NewGuid(), item.InventoryItemId, item.ProductItemId, count));
            }
            else
            {
                //  TODO:
                ApplyChange(new StockAddedToInventoryItemEvent(Guid.NewGuid(), item.InventoryItemId, count));
            }
        }

        public void RemoveStockFromInventory(int inventoryItemId, int count)
        {
            if (count.Equals(0) && count < 0)
                throw new Exception("Inventory Item must have items.");

            if (!InventoryItems.Any(x => x.Id == inventoryItemId))
                throw new Exception("Inventory Item Doesn't Exist");

            var InvItem = InventoryItems.First(x => x.InventoryItemId == inventoryItemId);
            var stock = InvItem.UnitsInStock;
            var total = stock - count;

            if (total < 0)
                throw new Exception("Cannot Remove More Stock Than Exists");

            if (total.Equals(0))
                ApplyChange(new ItemRemovedFromInventoryEvent(Guid.NewGuid(), inventoryItemId));
            else 
                ApplyChange(new StockRemovedFromInventoryItemEvent(Guid.NewGuid(), inventoryItemId, count));
        }

        public void RemoveInventoryItem(int inventoryItemId)
        {
            if (InventoryItems.Any(x => x.InventoryItemId == inventoryItemId))
            {
                var Item = InventoryItems.First(x => x.InventoryItemId == inventoryItemId);
                ApplyChange(new ItemRemovedFromInventoryEvent(Guid.NewGuid(), inventoryItemId));
            }
            else
            {
                throw new Exception("Item Doesn't Exist In the Inventory");
            }
        }
    }*/
}
