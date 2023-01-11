using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.DTO.Category;
using FastFood.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public CategoryService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Create(CreateCategoryDto createCategoryDto)
        {
            Category category = this.mapper.Map<Category>(createCategoryDto);

            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
        }

        public ICollection<ListAllCategoryDto> GetAll()
        => dbContext.Categories
            .ProjectTo<ListAllCategoryDto>(mapper.ConfigurationProvider)
            .ToList();
    }
}
