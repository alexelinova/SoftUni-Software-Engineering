using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO.ExportDto;
using CarDealer.DTO.ImportDto;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string suppliersAsXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //string partsAsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //string carsAsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //string customersAsXml = File.ReadAllText("../../../Datasets/customers.xml");
            //string salesAsXml = File.ReadAllText("../../../Datasets/sales.xml");


            //ImportSuppliers(context, suppliersAsXml);
            //ImportParts(context, partsAsXml);
            //ImportCars(context, carsAsXml);
            //ImportCustomers(context, customersAsXml);
            //ImportSales(context, salesAsXml);

            //Console.WriteLine(GetCarsWithDistance(context));
            //Console.WriteLine(GetCarsFromMakeBmw(context));
            //Console.WriteLine(GetLocalSuppliers(context));
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));
            //Console.WriteLine(GetTotalSalesByCustomer(context));
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportSupplierDto>), new XmlRootAttribute("Suppliers"));
            using StringReader strReader = new StringReader(inputXml);

            List<ImportSupplierDto> suppliersDto = (List<ImportSupplierDto>)serializer.Deserialize(strReader);

            List<Supplier> suppliers = mapper.Map<List<Supplier>>(suppliersDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportPartDto>), new XmlRootAttribute("Parts"));
            using StringReader reader = new StringReader(inputXml);

            List<ImportPartDto> partsDto = (List<ImportPartDto>)serializer.Deserialize(reader);

            var supplierId = context.Suppliers.Select(x => x.Id).ToList();

            List<Part> parts = mapper.Map<List<Part>>(partsDto).Where(x => supplierId.Contains(x.SupplierId)).ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportCarDto>), new XmlRootAttribute("Cars"));
            using StringReader reader = new StringReader(inputXml);

            List<ImportCarDto> carsDto = (List<ImportCarDto>)serializer.Deserialize(reader);

            var partIds = context.Parts.Select(x => x.Id).ToList();

            foreach (var carDto in carsDto)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance,
                };

                foreach (var partId in carDto.Parts.Select(x => x.PartId).Distinct())
                {
                    if (!partIds.Contains(partId))
                    {
                        continue;
                    }

                    car.PartCars.Add(new PartCar
                    {
                        PartId = partId,
                    });
                }

                context.Cars.Add(car);
                context.SaveChanges();
            }

            return $"Successfully imported {carsDto.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportCustomerDto>), new XmlRootAttribute("Customers"));
            StringReader reader = new StringReader(inputXml);

            List<ImportCustomerDto> customersDto = (List<ImportCustomerDto>)serializer.Deserialize(reader);

            List<Customer> customers = mapper.Map<List<Customer>>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportSalesDto>), new XmlRootAttribute("Sales"));

            using StringReader reader = new StringReader(inputXml);

            List<ImportSalesDto> salesDto = (List<ImportSalesDto>)serializer.Deserialize(reader);

            var carIds = context.Cars.Select(x => x.Id).ToList();

            List<Sale> sales = mapper.Map<List<Sale>>(salesDto).Where(x => carIds.Contains(x.CarId)).ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            InitializeAutoMapper();

            List<ExportCarWithDistanceDto> carsWithDistanceDto = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .ProjectTo<ExportCarWithDistanceDto>(mapper.ConfigurationProvider)
                //.Select(x => new ExportCarWithDistanceDto
                //{
                //    Make = x.Make,
                //    Model = x.Model,
                //    TravelledDistance = x.TravelledDistance.ToString(),
                //})
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToList();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportCarWithDistanceDto>), new XmlRootAttribute("cars"));


            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, carsWithDistanceDto, namespaces);

            return writer.ToString();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            InitializeAutoMapper();

            List<ExportCartMakeDto> carWithMake = context.Cars
                .Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ProjectTo<ExportCartMakeDto>(mapper.ConfigurationProvider)
                //.Select(x => new ExportCartMakeDto
                //{
                //    Id = x.Id.ToString(),
                //    Model= x.Model,
                //    TravelledDistance = x.TravelledDistance.ToString(),
                //})
                .ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportCartMakeDto>), new XmlRootAttribute("cars"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringWriter writer = new StringWriter();

            serializer.Serialize(writer, carWithMake, namespaces);

            return writer.ToString();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            InitializeAutoMapper();

            List<ExportLocalSupplierDto> localSuppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .ProjectTo<ExportLocalSupplierDto>(mapper.ConfigurationProvider)
                //.Select(x => new ExportLocalSupplierDto
                //{
                //    Id = x.Id.ToString(),
                //    Name = x.Name,
                //    PartsCount = x.Parts.Count().ToString(),
                //})
                .ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportLocalSupplierDto>), new XmlRootAttribute("suppliers"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringWriter writer = new StringWriter();

            serializer.Serialize(writer, localSuppliers, namespaces);

            return writer.ToString();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            InitializeAutoMapper();

            List<ExportCarWithPartsDto> carsWithParts = context.Cars
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .ProjectTo<ExportCarWithPartsDto>(mapper.ConfigurationProvider)
                //.Select(x => new ExportCarWithPartsDto
                //{
                //    Make = x.Make,
                //    Model = x.Model,
                //    TravelledDistance = x.TravelledDistance.ToString(),
                //    Parts = x.PartCars.OrderByDescending(y => y.Part.Price)
                //      .Select(y => new ExportPartDto
                //      {
                //          Name = y.Part.Name,
                //          Price = y.Part.Price.ToString()
                //      })
                //    .ToList()
                //})
                .Take(5)
                .ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportCarWithPartsDto>), new XmlRootAttribute("cars"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringWriter writer = new StringWriter();

            serializer.Serialize(writer, carsWithParts, namespaces);

            return writer.ToString();

        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            InitializeAutoMapper();

           var salesByCustomer = context.Customers
                .Where(x => x.Sales.Count > 0)
                .ProjectTo<ExportSalesByCustomerDto>(mapper.ConfigurationProvider)
                //.Select(x => new ExportSalesByCustomerDto
                //{
                //    Name = x.Name,
                //    CountOfCars = x.Sales.Count.ToString(),
                //    SpentMoney = x.Sales.Select(y => y.Car).SelectMany(c => c.PartCars).Sum(cp => cp.Part.Price)
                //})
                .OrderByDescending(x => x.SpentMoney)
                .ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportSalesByCustomerDto>), new XmlRootAttribute("customers"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringWriter writer = new StringWriter();

            serializer.Serialize(writer, salesByCustomer, namespaces);

            return writer.ToString();
        }

        public static void InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cnf =>
            {
                cnf.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            InitializeAutoMapper();

            var sales = context.Sales
                .ProjectTo<ExportSaleDto>(mapper.ConfigurationProvider)
                //.Select(x => new ExportSaleDto
                //{
                //    Car = new ExportSaleCarDto()
                //    {
                //        Make = x.Car.Make,
                //        Model = x.Car.Model,
                //        TravelledDistance = x.Car.TravelledDistance
                //    },
                //    Discount = x.Discount,
                //    CustomerName = x.Customer.Name,
                //    Price = x.Car.PartCars.Sum(y => y.Part.Price),
                //    PriceWithDiscount = x.Car.PartCars.Sum(y => y.Part.Price) - x.Car.PartCars.Sum(y => y.Part.Price) * x.Discount / 100
                //})
                .ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportSaleDto>), new XmlRootAttribute("sales"));

            XmlSerializerNamespaces namespaces= new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringWriter writer = new StringWriter();

            serializer.Serialize(writer, sales, namespaces);

            return writer.ToString();
        }
    }
}