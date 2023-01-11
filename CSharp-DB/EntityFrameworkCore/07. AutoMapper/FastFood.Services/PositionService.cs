using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.DTO.Position;
using FastFood.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FastFood.Services
{
    public class PositionService : IPositionService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;
        public PositionService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;

        }

        public void Create(CreatePositionDto createPositionDto)
        {
            Position position = this.mapper.Map<Position>(createPositionDto);

            this.dbContext.Positions.Add(position);
            this.dbContext.SaveChanges();
        }

        public ICollection<ListAllPositionDto> GetAll()
        => dbContext.Positions
            .ProjectTo<ListAllPositionDto>(mapper.ConfigurationProvider)
            .ToList();
    }
}
