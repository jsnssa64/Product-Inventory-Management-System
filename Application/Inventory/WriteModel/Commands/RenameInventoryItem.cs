using CQRSlite.Commands;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inventory.WriteModel.Commands
{
    public class RenameInventoryItem : BaseCommand
    {
        public readonly int InventoryItemId;
        public readonly string Name;

        public RenameInventoryItem(Guid id, int inventoryItemId, string name, int originalVersion)
        {
            Id = id;
            InventoryItemId = inventoryItemId;
            Name = name;
            ExpectedVersion = originalVersion;
        }
    }
}
