using CQRSlite.Commands;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inventory.WriteModel.Commands
{
    public class DeactivateInventoryItem : BaseCommand
    {
        public readonly int InventoryItemId;
        public readonly string Name;

        //  TODO
        public DeactivateInventoryItem(Guid id, int inventoryItemId, int originalVersion)
        {
            Id = id;
            InventoryItemId = inventoryItemId;
            ExpectedVersion = originalVersion;
        }
    }
}
