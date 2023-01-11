using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.DTO.Item;
using FastFood.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FastFood.Services
{
    public class ItemService : IItemService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;
        public ItemService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public void Create(CreateItemDto dto)
        {
            Item item = mapper.Map<Item>(dto);

            dbContext.Items.Add(item);
            dbContext.SaveChanges();
        }

        public ICollection<ListAllItemDto> GetAll()
            => dbContext.Items
            .ProjectTo<ListAllItemDto>(mapper.ConfigurationProvider)
            .ToList();
    }
}
