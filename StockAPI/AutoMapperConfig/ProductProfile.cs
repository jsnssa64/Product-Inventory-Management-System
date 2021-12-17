using Application.Inventory.Queries.Dtos;
using Application.Inventory.WriteModel.Commands;
using AutoMapper;
using Data.Model;
using Domain.Events;
using StockAPI.DTO.Product;
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
            //  EF Class -> DTO
            CreateMap<Product, ProductItemDTO>();
            CreateMap<Product, ProductItemBasicDTO>();
            CreateMap<ProductType, ProductTypeDTO>();

            //  DTO -> EF Class
            CreateMap<ProductTypeDTO, ProductType>();
            CreateMap<ProductItemBasicDTO, Product>();
            CreateMap<ProductItemDTO, Product>();
        }
    }
}
