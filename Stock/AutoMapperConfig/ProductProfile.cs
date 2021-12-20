using AutoMapper;
using Data.Model;
using Stock.ApplicationModel;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.AutoMapperConfig
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductItem, ItemViewModel>()
                .ForMember(dest => dest.Unit,
                    opt => opt.Ignore())
                .ForMember(dest => dest.DateOfDiscontinuation,
                    opt => opt.MapFrom(src => src.DateOfDiscontinuedUTC));

            //  EF Class -> ViewModel
            CreateMap<Product, DetailProductViewModel>()
                .ForMember(dest => dest.Items,
                    opt => opt.MapFrom(src => src.ProductItems))
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.ProductDescription.Description))
                .ForMember(
                    dest => dest.ProductCount,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.ProductTitle,
                    opt => opt.MapFrom(src => src.ProductTypesBrand.ProductType.Title))
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(src => src.ProductTypesBrand.ProductType.Type)
                )
                .ForMember(
                    dest => dest.Brand,
                    opt => opt.MapFrom(src => src.ProductTypesBrand.Brand.Name)
                )
                .ForMember(
                    dest => dest.ProductCount,
                    opt => opt.MapFrom(src => src.ProductItems.Count())
                );

            CreateMap<Product, BaseProductViewModel>()
                .ForMember(
                    dest => dest.ProductCount,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.ProductTitle,
                    opt => opt.MapFrom(src => src.ProductTypesBrand.ProductType.Title))
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(src => src.ProductTypesBrand.ProductType.Type)
                )
                .ForMember(
                    dest => dest.Brand,
                    opt => opt.MapFrom(src => src.ProductTypesBrand.Brand.Name)
                )
                .ForMember(
                    dest => dest.ProductCount,
                    opt => opt.MapFrom(src => src.ProductItems.Count())
                );

            //  ViewModel -> EF Class
        }

    }
}
