using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.DTO.Order;
using FastFood.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FastFood.Services
{
    public class OrderService : IOrderService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;
        public OrderService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Create(CreateOrderDto dto)
        {
            Order newOrder = mapper.Map<Order>(dto);

            dbContext.Orders.Add(newOrder);
            dbContext.SaveChanges();
        }

        public ICollection<ListAllOrderDto> GetAll()
        => dbContext.Orders.ProjectTo<ListAllOrderDto>(mapper.ConfigurationProvider).ToList();
    }
}
