using CQRSlite.Events;
using Data.Model;
using Domain.ValObj;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class StockAddedToInventoryItemEvent : BaseEvent
    {
        public int ProductItemId { get; set; }
        public int UnitsReceived { get; set; }
        public StockAddedToInventoryItemEvent(Guid id, int productItemId, int unitsReceived)
        {
            Id = id;
            ProductItemId = productItemId;
            UnitsReceived = unitsReceived;
        }
    }
}
