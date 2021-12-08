using Application.Inventory.Queries.Dtos;
using Application.Inventory.WriteModel.Commands;
using AutoMapper;
using Data.Model;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.AutoMapperConfig
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            //  Frontend -> CommandHandler
            CreateMap<InventoryItemDto, CreateInventoryItemCommand>().ConstructUsing(x => new CreateInventoryItemCommand(Guid.NewGuid(), 0, x.ProductItemId, x.UnitsInStock));
            //  Event -> Persistence
            CreateMap<CreateItemInInventoryEvent, InventoryItem>()  .ForMember(dest => dest.Id, opt => opt.Ignore())
                                                                    .ForMember(dest => dest.AggregateId, opt => opt.MapFrom(src => src.Id));
            CreateMap<ItemRemovedFromInventoryEvent, InventoryItem>().ForMember(dest => dest.AggregateId, opt => opt.MapFrom(src => src.Id));
            
        }
    }
}
