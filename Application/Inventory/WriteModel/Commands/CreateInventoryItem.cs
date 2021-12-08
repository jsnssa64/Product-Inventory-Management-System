using CQRSlite.Commands;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inventory.WriteModel.Commands
{
    public class CreateInventoryItemCommand : BaseCommand
    {
        public readonly int InventoryItemId;
        public readonly int ProductItemId;
        public readonly int UnitsInStock;
        public readonly int Deactivated;

        public CreateInventoryItemCommand(Guid id, int inventoryItemId, int productItemId, int unitsInStock)
        {
            Id = id;
            InventoryItemId = inventoryItemId;
            ProductItemId = productItemId;
            UnitsInStock = unitsInStock;
            //  No Version
        }
    }
}
