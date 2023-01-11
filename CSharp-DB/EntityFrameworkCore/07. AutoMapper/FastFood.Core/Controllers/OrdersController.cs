namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data;
    using FastFood.Services.DTO.Employee;
    using FastFood.Services.DTO.Item;
    using FastFood.Services.DTO.Order;
    using FastFood.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Orders;

    public class OrdersController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IItemService itemService;
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrdersController(IEmployeeService employeeService, IItemService itemService, IOrderService orderService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.itemService = itemService;
            this.orderService = orderService;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            ICollection<ListAllItemDto> items = itemService.GetAll().ToList();
            ICollection<ListAllEmployeeDto> employees = employeeService.GetAll().ToList();

            var viewOrder = new CreateOrderViewModel
            {
                Items = mapper.Map<ICollection<ListAllItemDto>, ICollection<CreateOrderItemViewModel>>(items),
                Employees = mapper.Map<ICollection<ListAllEmployeeDto>, ICollection<CreateOrderEmployeeViewModel>>(employees)
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create");
            }

            CreateOrderDto newOrder = mapper.Map<CreateOrderDto>(model);
            this.orderService.Create(newOrder);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            ICollection<ListAllOrderDto> allOrders = this.orderService.GetAll();

            IList<OrderAllViewModel> orders = mapper
                .Map<ICollection<ListAllOrderDto>, IList<OrderAllViewModel>>(allOrders).ToList();

            return this.View(orders);
        }
    }
}
