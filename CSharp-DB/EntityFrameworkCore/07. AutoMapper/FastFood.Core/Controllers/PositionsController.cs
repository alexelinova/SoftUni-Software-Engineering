namespace FastFood.Core.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Models;
    using FastFood.Services.DTO.Position;
    using FastFood.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Positions;

    public class PositionsController : Controller
    {
        private readonly IPositionService positionService;
        private readonly IMapper mapper;

        public PositionsController(IPositionService positionService, IMapper mapper)
        {
            this.positionService= positionService;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreatePositionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create");
            }

            CreatePositionDto newPosition = mapper.Map<CreatePositionDto>(model);
            this.positionService.Create(newPosition);

            return this.RedirectToAction("All", "Positions");
        }

        public IActionResult All()
        {
            ICollection<ListAllPositionDto> allPositions = this.positionService.GetAll();

            IList<PositionsAllViewModel> positions = mapper
                .Map<ICollection<ListAllPositionDto>, ICollection<PositionsAllViewModel>>(allPositions)
                .ToList();

            return this.View(positions);
        }
    }
}
