using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext dbContext = new CarDealerContext();

            Mapper.Initialize(cfg => cfg.AddProfile(typeof(CarDealerProfile)));

            string suppliersAsJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            string partsAsJson = File.ReadAllText(@"../../../Datasets/parts.json");
            string carsAsJson = File.ReadAllText(@"../../../Datasets/cars.json");
            string customersAsJson = File.ReadAllText(@"../../../Datasets/customers.json");
            string salesAsJson = File.ReadAllText(@"../../../Datasets/sales.json");

            //ImportSuppliers(dbcontext, suppliersAsJson);
            //ImportParts(dbcontext, partsAsJson);
            //ImportCars(dbContext, carsAsJson);
            //ImportCustomers(dbContext, customersAsJson);
            //ImportSales(dbContext, salesAsJson);

            Console.WriteLine(GetSalesWithAppliedDiscount(dbContext));

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {

            IEnumerable<ImportSupplierDto> supplierDto = JsonConvert
                .DeserializeObject<IEnumerable<ImportSupplierDto>>(inputJson);

            IEnumerable<Supplier> suppliers = Mapper.Map<IEnumerable<Supplier>>(supplierDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            List<int> supplierId = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            IEnumerable<ImportPartDto> partDto = JsonConvert
                .DeserializeObject<IEnumerable<ImportPartDto>>(inputJson);

            IEnumerable<Part> parts = Mapper.Map<IEnumerable<Part>>(partDto)
                .Where(p => supplierId.Contains(p.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            IEnumerable<ImportCarDto> carsDto = JsonConvert
                .DeserializeObject<IEnumerable<ImportCarDto>>(inputJson);

            foreach (var car in carsDto)
            {
                Car newCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car.PartsId.Distinct())
                {
                    newCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                context.Cars.Add(newCar);
                context.SaveChanges();
            }

            return $"Successfully imported {carsDto.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IEnumerable<ImportCustomerDto> customersDto = JsonConvert
                .DeserializeObject<IEnumerable<ImportCustomerDto>>(inputJson);

            IEnumerable<Customer> customers = Mapper.Map<IEnumerable<Customer>>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IEnumerable<ImportSaleDto> salesDto = JsonConvert.DeserializeObject<IEnumerable<ImportSaleDto>>(inputJson);

            IEnumerable<Sale> sales = Mapper.Map<IEnumerable<Sale>>(salesDto);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            List<ExportCustomerDto> customersDto = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .ProjectTo<ExportCustomerDto>(Mapper.Configuration)
                .ToList();
            //.Select(x => new ExportCustomerDto
            //{
            //    Name = x.Name,
            //    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
            //    IsYoungDriver = x.IsYoungDriver
            //})
            //.ToList();


            string result = JsonConvert.SerializeObject(customersDto, Formatting.Indented);

            return result;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            List<ExportCarDto> carsDto = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ProjectTo<ExportCarDto>(Mapper.Configuration)
                .ToList();
            //.Select(x => new ExportCarDto
            //{
            //    Id = x.Id,
            //    Make = x.Make,
            //    Model = x.Model,
            //    TravelledDistance = x.TravelledDistance
            //})
            //.ToList();

            string result = JsonConvert.SerializeObject(carsDto, Formatting.Indented);
            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            List<ExportSupplierDto> localSuppliersDto = context.Suppliers
                .Where(x => x.IsImporter == false)
                .ProjectTo<ExportSupplierDto>(Mapper.Configuration)
                .ToList();
            //.Select(x => new ExportSupplierDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    PartsCount = x.Parts.Count
            //})
            //.ToList();

            string result = JsonConvert.SerializeObject(localSuppliersDto, Formatting.Indented);

            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(x => new
                {
                    car = new
                    {
                        x.Make,
                        x.Model,
                        x.TravelledDistance,
                    },
                    parts = x.PartCars.Select(y => new
                    {
                        y.Part.Name,
                        Price = y.Part.Price.ToString("F2")
                    })

                })
                .ToList();

            string result = JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Count >= 1)
                .ProjectTo<ExportSalesbyCustomerDto>(Mapper.Configuration)
                //.Select(x => new
                //{
                //    FullName = x.Name,
                //    BoughtCars = x.Sales.Count,
                //    SpentMoney = x.Sales.Sum(y => y.Car.PartCars.Sum(p => p.Part.Price))
                //})
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToList();

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };
            string result = JsonConvert.SerializeObject(customers, Formatting.Indented, settings);

            return result;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .ProjectTo<ExportSalesWithDiscountDto>(Mapper.Configuration)
                //.Select(x => new
                //{
                //    car = new
                //    {
                //        x.Car.Make,
                //        x.Car.Model,
                //        x.Car.TravelledDistance
                //    },
                //    CustomerName = x.Customer.Name,
                //    x.Discount,
                //    Price = x.Car.PartCars.Sum(y => y.Part.Price),
                //    PriceWithDicsount = x.Car.PartCars.Sum(y => y.Part.Price) - x.Car.PartCars.Sum(y => y.Part.Price) * x.Discount / 100
                //})
                .Take(10)
                .ToList();


            string result = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return result;
        }
    }
}