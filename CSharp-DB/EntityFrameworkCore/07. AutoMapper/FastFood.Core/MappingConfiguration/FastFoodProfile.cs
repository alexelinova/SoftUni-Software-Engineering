namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using FastFood.Services.DTO.Category;
    using FastFood.Services.DTO.Employee;
    using FastFood.Services.DTO.Item;
    using FastFood.Services.DTO.Order;
    using FastFood.Services.DTO.Position;
    using System;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions

            this.CreateMap<Position, ListAllPositionDto>();
            this.CreateMap<ListAllPositionDto, PositionsAllViewModel>();
            this.CreateMap<CreatePositionInputModel, CreatePositionDto>();

            this.CreateMap<CreatePositionDto, Position>()
                .ForMember(dest => dest.Name, src => src.MapFrom(s => s.PositionName));

            //Categories

            this.CreateMap<CreateCategoryDto, Category>()
                .ForMember(dest => dest.Name, src => src.MapFrom(s => s.CategoryName));

            this.CreateMap<CreateCategoryInputModel, CreateCategoryDto>();
            this.CreateMap<Category, ListAllCategoryDto>();
            this.CreateMap<ListAllCategoryDto, CategoryAllViewModel>();

            //Items

            this.CreateMap<ListAllCategoryDto, CreateItemViewModel>()
                .ForMember(dest => dest.CategoryName, src => src.MapFrom(s => s.Name))
                .ForMember(dest => dest.CategoryId, src => src.MapFrom(s => s.Id));

            this.CreateMap<Item, ListAllItemDto>();
            this.CreateMap<ListAllItemDto, ItemsAllViewModels>();
            this.CreateMap<CreateItemInputModel, CreateItemDto>();
            this.CreateMap<CreateItemDto, Item>();

            //Employees

            this.CreateMap<ListAllPositionDto, RegisterEmployeeViewModel>()
                .ForMember(dest => dest.PositionName, src => src.MapFrom(s => s.Name))
                .ForMember(dest => dest.PositionId, src => src.MapFrom(s => s.Id));

            this.CreateMap<RegisterEmployeeInputModel, CreateEmployeeDto>();
            this.CreateMap<CreateEmployeeDto, Employee>();
            this.CreateMap<Employee, ListAllEmployeeDto>();
            this.CreateMap<ListAllEmployeeDto, EmployeesAllViewModel>();

            //Orders

            this.CreateMap<ListAllEmployeeDto, CreateOrderEmployeeViewModel>();
            this.CreateMap<ListAllItemDto, CreateOrderItemViewModel>();

            this.CreateMap<Order, ListAllOrderDto>()
                .ForMember(dest => dest.DateTime, src => src.MapFrom(s => s.DateTime.ToString("d")))
                .ForMember(dest => dest.OrderId, src => src.MapFrom(s => s.Id));
            this.CreateMap<ListAllOrderDto, OrderAllViewModel>();

            this.CreateMap<CreateOrderInputModel, CreateOrderDto>();
            this.CreateMap<CreateOrderDto, Order>()
                .ForMember(dest => dest.DateTime, src => src.MapFrom(s => DateTime.Now))
                .ForMember(dest => dest.Type, src => src.MapFrom(s => OrderType.ForHere))
                .AfterMap((src, dest) => dest.OrderItems.Add(new OrderItem { Quantity = src.Quantity, ItemId = src.ItemId }));
        }
    }
}
