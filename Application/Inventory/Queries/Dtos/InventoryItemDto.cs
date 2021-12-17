using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inventory.Queries.Dtos
{
    public class InventoryItemDto
    {
        public int InventoryItemId;
        public int ProductItemId;
        public int UnitsInStock;
        //  TODO: Does this actually need to be here??
        public Guid id;
    }
}
