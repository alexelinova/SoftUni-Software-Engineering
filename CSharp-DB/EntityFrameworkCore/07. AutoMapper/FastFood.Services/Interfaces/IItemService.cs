using FastFood.Services.DTO.Item;
using System.Collections.Generic;

namespace FastFood.Services.Interfaces
{
    public interface IItemService
    {
        void Create(CreateItemDto dto);

        ICollection<ListAllItemDto> GetAll();
    }
}
