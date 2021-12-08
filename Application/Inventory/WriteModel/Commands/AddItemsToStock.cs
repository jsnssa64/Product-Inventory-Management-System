using CQRSlite.Commands;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inventory.WriteModel.Commands
{
    public class AddItemsToStockCommand : BaseCommand
    {
        public readonly bool Deactivated;
        public readonly int StocksAdded;
        public readonly int InventoryItemId;

        public AddItemsToStockCommand(Guid id, int inventoryItemId, int stocksAdded, bool deactivated, int originalVersion)
        {
            Id = id;
            StocksAdded = stocksAdded;
            Deactivated = deactivated;
            ExpectedVersion = originalVersion;
        }
    }
}
