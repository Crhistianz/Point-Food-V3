using AutoMapper;
using PointFood.Commons;
using PointFood.Dto;
using PointFood.Model;
using PointFood.Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.ConfigMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //Order
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<OrderDetailDto, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<RestaurantOrderDto, Restaurant>();
            CreateMap<Restaurant, RestaurantOrderDto>();
            CreateMap<DataCollection<Order>,DataCollection<OrderDto>>();

            //OrderCreate
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderDetailCreateDto, OrderDetail>();

            //Card
            CreateMap<Card, CardDto>();
            CreateMap<CardCreateDto, Card>();

            //Client
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();
            CreateMap<ClientLoginDto, Client>();
            CreateMap<ClientLoginDto, ClientDto>();
            CreateMap<DataCollection<Client>, DataCollection<ClientDto>>();
            CreateMap<ClientCreateDto, Client>();

            //Product
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<DataCollection<ProductDto>, DataCollection<Product>>();
            CreateMap<DataCollection<Product>, DataCollection<ProductDto>>();

            //Restaurant
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<RestaurantDto, Restaurant>();
            CreateMap<RestaurantCreateDto, Restaurant>();
            CreateMap<RestaurantCategoryCreateDto, RestaurantCategory>();
            CreateMap<DataCollection<Restaurant>, DataCollection<RestaurantDto>>();

            //Restaurant Owner
            CreateMap<RestaurantOwner, RestaurantOwnerDto>();
            CreateMap<DataCollection<RestaurantOwner>, DataCollection<RestaurantOwnerDto>>();
            CreateMap<RestaurantOwnerDto, RestaurantOwner>();

            //Category
            CreateMap<Category, CategoryDto>();
            CreateMap<DataCollection<CategoryDto>, DataCollection<Category>>();
            CreateMap<DataCollection<Category>, DataCollection<CategoryDto>>();

            //State
            CreateMap<State, StateDto>();
            CreateMap<DataCollection<StateDto>, DataCollection<State>>();
            CreateMap<DataCollection<State>, DataCollection<StateDto>>();

            //ProductType
            CreateMap<DataCollection<ProductTypeDto>, DataCollection<ProductType>>();
            CreateMap<DataCollection<ProductType>, DataCollection<ProductTypeDto>>();
            CreateMap<ProductTypeDto, ProductType>();
            CreateMap<ProductType, ProductTypeDto>();

            //RestaurantCategory
            CreateMap<DataCollection<RestaurantCategoryDto>, DataCollection<RestaurantCategory>>();
            CreateMap<DataCollection<RestaurantCategory>, DataCollection<RestaurantCategoryDto>>();
            CreateMap<RestaurantCategoryDto, RestaurantCategory>();
            CreateMap<RestaurantCategory, RestaurantCategoryDto>();

            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(
                    dest => dest.Name,
                    opts => opts.MapFrom(src => src.Name)
                ).ForMember(
                    dest => dest.Roles,
                    opts => opts.MapFrom(src => src.UserRoles.Select(y => y.Role.Name).ToList())
                );
            CreateMap<DataCollection<ApplicationUser>, DataCollection<ApplicationUserDto>>();
        }
    }
}
