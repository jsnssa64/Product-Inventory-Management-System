using CQRSlite.Commands;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inventory.WriteModel.Commands
{
    public class RemoveItemsFromStockCommand : BaseCommand
    {
        public readonly bool Deactivated;
        public readonly int StocksRemoved;
        public readonly int InventoryItemId;

        public RemoveItemsFromStockCommand(Guid id, int inventoryItemId, int stocksRemoved, bool deactivated)
        {
            Id = id;
            StocksRemoved = stocksRemoved;
            Deactivated = deactivated;
        }
    }
}
