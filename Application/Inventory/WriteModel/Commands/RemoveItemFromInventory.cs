using CQRSlite.Commands;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inventory.WriteModel.Commands
{
    public class RemoveItemFromInventoryCommand : BaseCommand
    {
        public readonly bool Deactivated;
        public readonly int InventoryItemId;

        public RemoveItemFromInventoryCommand(Guid id, int inventoryItemId, bool deactivated)
        {
            Id = id;
            InventoryItemId = inventoryItemId;
            Deactivated = deactivated;
        }
    }
}
