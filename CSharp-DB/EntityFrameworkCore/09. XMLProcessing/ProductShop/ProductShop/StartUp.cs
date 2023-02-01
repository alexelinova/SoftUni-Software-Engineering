using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.Dto.Export;
using ProductShop.Dto.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            ProductShopContext dbContext = new ProductShopContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //string usersAsXml = File.ReadAllText(@"../../../Datasets/users.xml");
            //string productsAsXml = File.ReadAllText(@"../../../Datasets/products.xml");
            //string categoriesAsXml = File.ReadAllText(@"../../../Datasets/categories.xml");
            //string categoryProductAsXml = File.ReadAllText(@"../../../Datasets/categories-products.xml");

            //ImportUsers(dbContext, usersAsXml);
            //ImportProducts(dbContext, productsAsXml);
            //ImportCategories(dbContext, categoriesAsXml);
            //ImportCategoryProducts(dbContext, categoryProductAsXml);

            //Console.WriteLine(GetProductsInRange(dbContext));
            //Console.WriteLine(GetSoldProducts(dbContext));
            //Console.WriteLine(GetCategoriesByProductsCount(dbContext));
            Console.WriteLine(GetUsersWithProducts(dbContext));

        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportUserDto>), new XmlRootAttribute("Users"));
            StringReader reader = new StringReader(inputXml);

            List<ImportUserDto> usersDto = (List<ImportUserDto>)serializer.Deserialize(reader);

            List<User> users = mapper.Map<List<User>>(usersDto);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportProductDto>), new XmlRootAttribute("Products"));

            List<ImportProductDto> productsDto = (List<ImportProductDto>)serializer.Deserialize(new StringReader(inputXml));

            List<Product> products = mapper.Map<List<Product>>(productsDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportCategoryDto>), new XmlRootAttribute("Categories"));
            List<ImportCategoryDto> categoriesDto = (List<ImportCategoryDto>)serializer.Deserialize(new StringReader(inputXml));

            List<Category> categories = mapper.Map<List<Category>>(categoriesDto);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportCategoryProductDto>), new XmlRootAttribute("CategoryProducts"));
            var categoryProductsDto = (List<ImportCategoryProductDto>)serializer.Deserialize(new StringReader(inputXml));

            List<CategoryProduct> categoryProducts = mapper.Map<List<CategoryProduct>>(categoryProductsDto);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            InitializeMapper();

            var productsDto = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .ProjectTo<ExportProductDto>(mapper.ConfigurationProvider)
                //.Select(x => new ExportProductDto
                //{
                //    Name = x.Name,
                //    Price = x.Price,
                //    BuyerName = x.Buyer.FirstName + " " + x.Buyer.LastName,
                //})
                .Take(10)
                .ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportProductDto>), new XmlRootAttribute("Products"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringWriter sw = new StringWriter();

            serializer.Serialize(sw, productsDto, namespaces);

            return sw.ToString();
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            InitializeMapper();

            var soldProductsDto = context.Users
                .Where(x => x.ProductsSold.Count() > 0)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ProjectTo<ExportSoldProductCountDto>(mapper.ConfigurationProvider)
                //.Select(x => new ExportSoldProductCountDto
                //{
                //    FirstName = x.FirstName,
                //    LastName = x.LastName,
                //    SoldProducts = x.ProductsSold.Select(y => new ExportSoldProductDto
                //    {
                //        Name = y.Name,
                //        Price = y.Price,
                //    }).ToList(),
                //})
                .Take(5)
                .ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportSoldProductCountDto>), new XmlRootAttribute("Users"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringWriter sw = new StringWriter();
            serializer.Serialize(sw, soldProductsDto, namespaces);

            return sw.ToString();
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            InitializeMapper();

            var categoriesByProductsDto = context.Categories
                .ProjectTo<ExportCategoryByProductDto>(mapper.ConfigurationProvider)
                //.Select(x => new ExportCategoryByProductDto
                //{
                //    Name = x.Name,
                //    ProductCount = x.CategoryProducts.Count(),
                //    AveragePrice = x.CategoryProducts.Average(y => y.Product.Price),
                //    TotalRevenue = x.CategoryProducts.Sum(y => y.Product.Price),
                //})
                .OrderByDescending(x => x.ProductCount)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportCategoryByProductDto>), new XmlRootAttribute("Categories"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringWriter sw = new StringWriter();

            serializer.Serialize(sw, categoriesByProductsDto, namespaces);

            return sw.ToString();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            InitializeMapper();

            var usersWithProductsDto = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .OrderByDescending(x => x.ProductsSold.Count)
                .ToList()//judge
                .Select(u => new ExportUsersWithProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportUsersWithProductCountDto()
                    {
                        ProductsCount = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new ExportProductDto
                        {
                            Price = p.Price,
                            Name = p.Name,
                        })
                        .OrderByDescending(p => p.Price)
                        .ToList()
                    }
                })
                .Take(10)
                .ToList();

            ExportUsersWithProductsResult result = new ExportUsersWithProductsResult
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                Users = usersWithProductsDto
            };

            XmlSerializer serializer = new XmlSerializer(typeof(ExportUsersWithProductsResult), new XmlRootAttribute("Users"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringWriter sw = new StringWriter();

            serializer.Serialize(sw, result, namespaces);

            return sw.ToString();
        }

        public static void InitializeMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cnf =>
             cnf.AddProfile<ProductShopProfile>());

            mapper = config.CreateMapper();
        }
    }
}