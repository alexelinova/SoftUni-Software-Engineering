using AutoMapper;
using CarDealer.DTO.ImportDto;
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
            CreateMap<ImportSalesDto, Sale>();
        }
    }
}
