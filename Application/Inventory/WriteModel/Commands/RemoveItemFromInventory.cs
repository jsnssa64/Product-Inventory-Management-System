using CQRSlite.Commands;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inventory.WriteModel.Commands
{
    public class RemoveItemFromInventory : BaseCommand
    {
        public readonly bool Deactivated;
        public readonly int InventoryItemId;

        public RemoveItemFromInventory(Guid id, int inventoryItemId)
        {
            Id = id;
            InventoryItemId = inventoryItemId;
            Deactivated = true;
        }
    }
}
