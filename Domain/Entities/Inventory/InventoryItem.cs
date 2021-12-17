using CQRSlite.Domain;
using CSharpFunctionalExtensions;
using Data.Model;
using Domain.Events;
using Domain.ValObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Inventory
{
    public class InventoryItem : AggregateRoot
    {
        public int ProductItemId { get; private set; }
        public int UnitsInStock { get; private set; }
        public bool Deactivated { get; private set; }

        private InventoryItem() { }
        public InventoryItem(Guid id, int productItemId, int unitsInStock)
        {
            if (unitsInStock <= 0)
                throw new Exception("Inventory Item Doesn't Exist");

            Id = id;

            //  InventoryId if 0 then overwrite otherwise Deactivate = true
            ApplyChange(new CreateItemInInventoryEvent(id, productItemId, unitsInStock));
        }

        //  Rehydrate Model
        public void Apply(CreateItemInInventoryEvent e)
        {
            ProductItemId = e.ProductItemId;
            UnitsInStock = e.UnitsInStock;
            Deactivated = false;
        }

        public void Apply(ItemRemovedFromInventory e)
        {
            UnitsInStock = 0;
            Deactivated = true;
        }

        public void Apply(StockAddedToInventoryItemEvent e)
        {
            UnitsInStock += e.UnitsReceived;
        }

        public void Apply(StockRemovedFromInventoryItemEvent e)
        {
            UnitsInStock -= e.RemovedFromStock;
        }

        //  Business Logic
        public void AddItemsToStock(Guid id, int inventoryItemId, int count)
        {
            if (count.Equals(0) || count < 0)
                throw new Exception("Inventory Item must have items.");

            ApplyChange(new StockAddedToInventoryItemEvent(id, inventoryItemId, count));
        }

        public void RemoveStockFromInventory(int count)
        {
            if (count.Equals(0) || count < 0)
                throw new Exception("Inventory Item must have items.");

            var total = UnitsInStock - count;

            if (total < 0)
                throw new Exception("Cannot Remove More Stock Than Exists");

            if (total.Equals(0))
                ApplyChange(new ItemRemovedFromInventory(Id, ProductItemId));
            else
                ApplyChange(new StockRemovedFromInventoryItemEvent(Id, ProductItemId, count));
        }

        public void RemoveInventoryItem(int inventoryItemId)
        {
            ApplyChange(new ItemRemovedFromInventory(Id, inventoryItemId));
        }
    }
}
