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
    public class CreateItemInInventoryEvent : BaseEvent
    {
        public int ProductItemId { get; set; }
        public int UnitsInStock { get; set; }
        public bool Deactivate { get; set; }

        public CreateItemInInventoryEvent(Guid id, int productItemId, int unitsInStock)
        {
            Id = id;
            ProductItemId = productItemId;
            UnitsInStock = unitsInStock;
            Deactivate = false;
        }   
    }
}
