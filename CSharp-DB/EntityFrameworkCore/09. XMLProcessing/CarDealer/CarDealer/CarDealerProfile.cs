using AutoMapper;
using CarDealer.DTO.ExportDto;
using CarDealer.DTO.ImportDto;
using CarDealer.Models;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<ImportSupplierDto, Supplier>();
            CreateMap<ImportPartDto, Part>();
            CreateMap<ImportCustomerDto, Customer>();
            CreateMap<ImportSalesDto, Sale>();
            CreateMap<Car, ExportCarWithDistanceDto>();

            CreateMap<Car, ExportCartMakeDto>();
            CreateMap<Supplier, ExportLocalSupplierDto>();

            CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(x => x.Parts, y => y.MapFrom(s => s.PartCars.Select(p => p.Part).OrderByDescending(p => p.Price)));

            CreateMap<Part, ExportPartDto>();

            CreateMap<Customer, ExportSalesByCustomerDto>()
                .ForMember(x => x.CountOfCars, y => y.MapFrom(S => S.Sales.Count))
                .ForMember(x => x.SpentMoney, y => y.MapFrom(s => s.Sales.Select(s => s.Car).SelectMany(c => c.PartCars).Sum(cp => cp.Part.Price)));

            CreateMap<Sale, ExportSaleDto>()
               .ForMember(x => x.Car, y => y.MapFrom(s => s.Car))
               .ForMember(x => x.Price, y => y.MapFrom(s => s.Car.PartCars.Sum(pc => pc.Part.Price)))
               .ForMember(x => x.PriceWithDiscount, y => y.MapFrom(s => s.Car.PartCars.Sum(pc => pc.Part.Price)
                            - s.Car.PartCars.Sum(pc => pc.Part.Price) * (s.Discount / 100)));

            CreateMap<Car, ExportSaleCarDto>();
        }
    }
}
