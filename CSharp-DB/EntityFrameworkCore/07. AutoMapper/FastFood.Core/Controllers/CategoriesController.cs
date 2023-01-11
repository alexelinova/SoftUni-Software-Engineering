namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data;
    using FastFood.Services.DTO.Category;
    using FastFood.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                this.RedirectToAction("Create");
            }

            CreateCategoryDto categoryDto = this.mapper.Map<CreateCategoryDto>(model);

            this.categoryService.Create(categoryDto);

            return this.RedirectToAction("All");
         
        }

        public IActionResult All()
        {
            ICollection<ListAllCategoryDto> listAllCategoryDto = this.categoryService.GetAll(); 

            IList<CategoryAllViewModel> allCategories = this.mapper
                .Map<ICollection<ListAllCategoryDto>, ICollection<CategoryAllViewModel>>(listAllCategoryDto)
                .ToList();

            return this.View(allCategories);
        }
    }
}
