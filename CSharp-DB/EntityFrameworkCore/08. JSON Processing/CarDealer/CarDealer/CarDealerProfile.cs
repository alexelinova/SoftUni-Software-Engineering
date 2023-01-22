using System.Linq;
using AutoMapper;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<ImportSupplierDto, Supplier>();
            CreateMap<ImportPartDto, Part>();
            CreateMap<ImportCustomerDto, Customer>();
            CreateMap<ImportSaleDto, Sale>();

            CreateMap<Customer, ExportCustomerDto>()
                .ForMember(dest => dest.BirthDate, src => src.MapFrom(s => s.BirthDate.ToString("dd/MM/yyyy")));

            CreateMap<Car, ExportCarDto>();

            CreateMap<Supplier, ExportSupplierDto>()
                .ForMember(dest => dest.PartsCount, src => src.MapFrom(s => s.Parts.Count));

            CreateMap<Customer, ExportSalesbyCustomerDto>()
                .ForMember(dest => dest.FullName, src => src.MapFrom(s => s.Name))
                .ForMember(dest => dest.BoughtCars, src => src.MapFrom(s => s.Sales.Count))
                .ForMember(dest => dest.SpentMoney, src => src.MapFrom(s => s.Sales.Sum(x => x.Car.PartCars.Sum(y => y.Part.Price))));

            CreateMap<Sale, ExportSalesWithDiscountDto>()
                .ForMember(dest => dest.Discount, src => src.MapFrom(s => s.Discount.ToString("F2")))
                .ForMember(dest => dest.Price, src => src.MapFrom(s => s.Car.PartCars.Sum(y => y.Part.Price)))
                .ForMember(dest => dest.PriceWithDiscount, src => src.MapFrom(x => x.Car.PartCars.Sum(y => y.Part.Price) - x.Car.PartCars.Sum(y => y.Part.Price) * x.Discount / 100));

            CreateMap<Car, ExportSalesWithDiscountCarDto>();
        }
    }
}
