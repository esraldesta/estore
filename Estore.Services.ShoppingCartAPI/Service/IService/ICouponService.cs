using Estore.Services.ShoppingCartAPI.Models.Dto;

namespace Estore.Services.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}