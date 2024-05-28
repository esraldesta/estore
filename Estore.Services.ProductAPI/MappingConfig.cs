using AutoMapper;
using Estore.Services.ProductAPI.Models;
using Estore.Services.ProductAPI.Models.Dto;

namespace Estore.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() { 
            var mappingConfig = new MapperConfiguration(config => 
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });
            return mappingConfig;
        }
    }
}
