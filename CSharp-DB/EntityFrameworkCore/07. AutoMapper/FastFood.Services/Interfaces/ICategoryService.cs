using FastFood.Services.DTO.Category;
using System.Collections.Generic;

namespace FastFood.Services.Interfaces
{
    public interface ICategoryService
    {
        void Create(CreateCategoryDto createCategoryDto);

        ICollection<ListAllCategoryDto> GetAll();

    }
}
