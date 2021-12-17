using Application.Inventory.WriteModel.Commands;
using CQRSlite.Commands;
using CQRSlite.Domain;
using Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inventory.WriteModel.Handlers
{
    class InventoryCommandHandlers : ICommandHandler<CreateInventoryItemCommand>
    {
        private readonly ISession _session;

        public InventoryCommandHandlers(ISession session)
        {
            _session = session;
        }

        public async Task Handle(CreateInventoryItemCommand command)
        {
            InventoryItem item = new (command.Id, command.ProductItemId, command.UnitsInStock);
            await _session.Add(item);
            await _session.Commit();
        }

        public async Task Handle(RemoveItemFromInventory command)
        {
            InventoryItem item = await _session.Get<InventoryItem>(command.Id);
            item.RemoveInventoryItem(command.InventoryItemId);
            await _session.Commit();
        }

        public async Task Handle(RemoveItemsFromStock command)
        {
            InventoryItem item = await _session.Get<InventoryItem>(command.Id);
            item.RemoveStockFromInventory(command.StocksRemoved);
            await _session.Commit();
        }
    }
}
