namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using FastFood.Services.DTO.Category;
    using FastFood.Services.DTO.Item;
    using FastFood.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IItemService itemService;
        private readonly IMapper mapper;

        public ItemsController(ICategoryService categoryService, IItemService itemService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.itemService = itemService;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            ICollection<ListAllCategoryDto> allCategories = this.categoryService.GetAll();

            IList<CreateItemViewModel> categories = this.mapper
                .Map<ICollection<ListAllCategoryDto>, ICollection<CreateItemViewModel>>(allCategories)
                .ToList();

            return this.View(categories);
        }

        [HttpPost]
        public IActionResult Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create");
            }

            CreateItemDto newItem = mapper.Map<CreateItemDto>(model);
            itemService.Create(newItem);

           return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            ICollection<ListAllItemDto> allItems = itemService.GetAll();

            IList<ItemsAllViewModels> items = mapper
                .Map<ICollection<ListAllItemDto>, ICollection<ItemsAllViewModels>>(allItems)
                .ToList();

            return this.View(items);
        }
    }
}
