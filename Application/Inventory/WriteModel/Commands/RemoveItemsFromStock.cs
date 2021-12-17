using CQRSlite.Commands;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inventory.WriteModel.Commands
{
    public class RemoveItemsFromStock : BaseCommand
    {
        public readonly int StocksRemoved;
        public readonly int InventoryItemId;

        public RemoveItemsFromStock(Guid id, int inventoryItemId, int stocksRemoved)
        {
            Id = id;
            StocksRemoved = stocksRemoved;
        }
    }
}
