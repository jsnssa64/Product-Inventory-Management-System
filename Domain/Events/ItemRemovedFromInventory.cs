using CQRSlite.Events;
using Domain.Entities.Inventory;
using Domain.ValObj;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class ItemRemovedFromInventory : BaseEvent
    {

        public int ProductItemId { get; set; }
        public ItemRemovedFromInventory(Guid id, int productItemId)
        {
            //  Aggregate Id
            Id = id;

            ProductItemId = productItemId;
        }
    }
}
