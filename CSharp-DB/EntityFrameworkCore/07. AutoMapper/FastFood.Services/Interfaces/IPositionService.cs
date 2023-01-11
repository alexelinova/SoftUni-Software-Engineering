using FastFood.Services.DTO.Position;
using System.Collections.Generic;

namespace FastFood.Services.Interfaces
{
    public interface IPositionService
    {
        void Create(CreatePositionDto createPositionDto);

        ICollection<ListAllPositionDto> GetAll();
    }
}
