using AutoMapper;
using CQRSlite.Events;
using Data.Migrations;
using Data.Model;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductOrder.EventHandler
{
    public class InventoryEventHandler :    IEventHandler<CreateItemInInventoryEvent>, 
                                            IEventHandler<RemoveItemFromInventory>,
                                            IEventHandler<StockAddedToInventoryItemEvent>, 
                                            IEventHandler<StockRemovedFromInventoryItemEvent>
    {
        public readonly IMapper Mapper;
        public readonly AppDbContext Dbcontext;
        public InventoryEventHandler(IMapper mapper, AppDbContext dbcontext)
        {
            Mapper = mapper;
            Dbcontext = dbcontext;
        }
        public Task Handle(CreateItemInInventoryEvent message)
        {
            bool exists = default;
            exists = Dbcontext.InventoryItem.Any(x => x.ProductItemId == message.ProductItemId);

            if (!exists)
            {
                //  Add Inventory Item To Inventory
                var InvItem = Mapper.Map<InventoryItem>(message);
                Dbcontext.InventoryItem.Add(InvItem);
            }
            else
            {
                //  Re-Enable InventoryItem 
                InventoryItem invItem = Dbcontext.InventoryItem.First(x => x.ProductItemId == message.ProductItemId);
                invItem.UnitsInStock = message.UnitsInStock;
                invItem.Version = message.Version;
                invItem.Deactivated = false;
            }

            Dbcontext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Handle(RemoveItemFromInventory message)
        {
            InventoryItem item = Dbcontext.InventoryItem.First(x => x.ProductItemId == message.ProductItemId);
            //  Deactivated Stock and Clear Stock
            item.UnitsInStock = 0;
            item.Deactivated = true;

            item.Version = message.Version;
            Dbcontext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Handle(StockAddedToInventoryItemEvent message)
        {
            InventoryItem item = Dbcontext.InventoryItem.FirstOrDefault(item => item.ProductItemId == message.ProductItemId);
            item.Version = message.Version;
            item.UnitsInStock += message.UnitsReceived;
            Dbcontext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Handle(StockRemovedFromInventoryItemEvent message)
        {
            InventoryItem item = Dbcontext.InventoryItem.FirstOrDefault(item => item.ProductItemId == message.ProductItemId);
            item.Version = message.Version;
            item.UnitsInStock -= message.RemovedFromStock;
            Dbcontext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
