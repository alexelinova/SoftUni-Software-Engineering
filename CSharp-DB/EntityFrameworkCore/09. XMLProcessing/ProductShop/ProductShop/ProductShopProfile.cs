using AutoMapper;
using ProductShop.Dto.Export;
using ProductShop.Dto.Import;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<ImportUserDto, User>();
            CreateMap<ImportProductDto, Product>();
            CreateMap<ImportCategoryDto, Category>();
            CreateMap<ImportCategoryProductDto, CategoryProduct>();

            CreateMap<Product, ExportProductDto>()
                .ForMember(x => x.BuyerName, y => y.MapFrom(s => $"{s.Buyer.FirstName} {s.Buyer.LastName}"));

            CreateMap<User, ExportSoldProductCountDto>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(s => s.ProductsSold));

            CreateMap<Category, ExportCategoryByProductDto>()
                .ForMember(x => x.ProductCount, y => y.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(x => x.AveragePrice, y => y.MapFrom(s => s.CategoryProducts.Average(cp => cp.Product.Price)))
                .ForMember(x => x.TotalRevenue, y => y.MapFrom(S => S.CategoryProducts.Sum(cp => cp.Product.Price)));
        }
    }
}
