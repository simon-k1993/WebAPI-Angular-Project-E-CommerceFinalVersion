using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Domain.Entities;
using TheShop.Domain.Entities.Identity;
using TheShop.Domain.Entities.OrderAggregate;
using TheShop.Domain.Models;
using TheShop.DTOs;
using TheShop.Helpers;

namespace TheShop.Mappers.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
               .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
               .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
               .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            CreateMap<TheShop.Domain.Entities.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<AddressDto, TheShop.Domain.Entities.OrderAggregate.Address>();
            CreateMap<Order, OrderToReturnDto>()
                 .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                 .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
        }
    }
}
