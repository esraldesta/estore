using AutoMapper;
using Estore.Services.CouponAPI.Models;
using Estore.Services.CouponAPI.Models.Dto;

namespace Estore.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() { 
            var mappingConfig = new MapperConfiguration(config => 
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappingConfig;
        }
    }
}
