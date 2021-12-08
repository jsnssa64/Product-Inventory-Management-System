using Application.Inventory.Queries.Dtos;
using Application.Inventory.Queries.Query;
using CQRSlite.Queries;
using Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inventory.Queries
{
    public class InventoryItemsView : IQueryHandler<GetInventoryItemsList, List<InventoryItemDto>>,
                                        IQueryHandler<GetInventoryItem, InventoryItemDto>
    {
        public readonly AppDbContext _context;
        public InventoryItemsView(AppDbContext context)
        {
            _context = context;
        }
        public Task<List<InventoryItemDto>> Handle(GetInventoryItemsList query)
        {
            //_context.InventoryItem.Where(x => x.)
            throw new NotImplementedException();
        }

        public Task<InventoryItemDto> Handle(GetInventoryItem query)
        {
            throw new NotImplementedException();
        }
    }
}
