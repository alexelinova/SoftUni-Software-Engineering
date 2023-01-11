using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.DTO.Employee;
using FastFood.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FastFood.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public EmployeeService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public void Create(CreateEmployeeDto dto)
        {
            Employee employee = mapper.Map<Employee>(dto);

            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
        }

        public ICollection<ListAllEmployeeDto> GetAll()
        => dbContext.Employees
            .ProjectTo<ListAllEmployeeDto>(mapper.ConfigurationProvider)
            .ToList();
    }
}
