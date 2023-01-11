namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data;
    using FastFood.Services.DTO.Employee;
    using FastFood.Services.DTO.Position;
    using FastFood.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Employees;

    public class EmployeesController : Controller
    {
        private readonly IPositionService positionService;
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeesController(IPositionService positionService, IEmployeeService employeeService, IMapper mapper)
        {
            this.positionService = positionService;
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        public IActionResult Register()
        {
            ICollection<ListAllPositionDto> allPositions = positionService.GetAll();

            IList<RegisterEmployeeViewModel> positions = mapper
                .Map<ICollection<ListAllPositionDto>, ICollection<RegisterEmployeeViewModel>>(allPositions)
                .ToList();

            return this.View(positions);
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Register");
            }

            CreateEmployeeDto newEmployee = mapper.Map<CreateEmployeeDto>(model);
            this.employeeService.Create(newEmployee);

            return this.RedirectToAction("All");

        }

        public IActionResult All()
        {
            ICollection<ListAllEmployeeDto> allEmployees = employeeService.GetAll();

            IList<EmployeesAllViewModel> employees = mapper
                .Map<ICollection<ListAllEmployeeDto>, List<EmployeesAllViewModel>>(allEmployees)
                .ToList();

            return this.View(employees);
        }
    }
}
