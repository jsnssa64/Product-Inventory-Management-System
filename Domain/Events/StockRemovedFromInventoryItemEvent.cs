using CQRSlite.Events;
using Domain.ValObj;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class StockRemovedFromInventoryItemEvent : BaseEvent
    {
        public int ProductItemId { get; set; }
        public int RemovedFromStock { get; set; }
        public StockRemovedFromInventoryItemEvent(Guid id, int productItemId, int removedFromStock)
        {
            Id = id;
            ProductItemId = productItemId;
            RemovedFromStock = removedFromStock;
        }
    }
}
