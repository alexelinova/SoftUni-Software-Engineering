using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.ImportDto;
using CarDealer.Models;
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

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string suppliersAsXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            string partsAsXml = File.ReadAllText("../../../Datasets/parts.xml");
            string carsAsXml = File.ReadAllText("../../../Datasets/cars.xml");
            string customersAsXml = File.ReadAllText("../../../Datasets/customers.xml");
            string salesAsXml = File.ReadAllText("../../../Datasets/sales.xml");


            ImportSuppliers(context, suppliersAsXml);
            ImportParts(context, partsAsXml);
            ImportCars(context, carsAsXml);
            ImportCustomers(context, customersAsXml);

            Console.WriteLine(ImportSales(context, salesAsXml));
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

        public static void InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cnf =>
            {
                cnf.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}