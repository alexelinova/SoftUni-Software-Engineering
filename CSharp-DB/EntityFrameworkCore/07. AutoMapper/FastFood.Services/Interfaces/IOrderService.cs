using FastFood.Services.DTO.Order;
using System.Collections.Generic;

namespace FastFood.Services.Interfaces
{
    public interface IOrderService
    {
        void Create(CreateOrderDto dto);

        ICollection<ListAllOrderDto> GetAll();
    }
}
