using Application.Inventory.Queries.Dtos;
using CQRSlite.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inventory.Queries.Query
{
    public class GetInventoryItemsList : IQuery<List<InventoryItemDto>>
    {
    }

    public class GetInventoryItem : IQuery<InventoryItemDto>
    {
        public GetInventoryItem(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
