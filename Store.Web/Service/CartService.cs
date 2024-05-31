using Store.Web.Models;
using Store.Web.Service.IService;
using Store.Web.Utility;

namespace Store.Web.Service
{
    public class CartService : ICartService
    {
        private readonly IBaseService _baseService;
        public CartService(IBaseService baseService) {
            _baseService = baseService;
        }



        public async Task<ResponseDto> ApplyCouponAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppingCartAPIBase + "/api/cart/ApplyCoupon"

            });
        }

        public async Task<ResponseDto> GetCartByUserIDAsync(string userId)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.ShoppingCartAPIBase + "/api/cart/GetCart" + userId

            });
        }

        public async Task<ResponseDto> RemoveFromCartsAsync(int cartDetailsId)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDetailsId,
                Url = SD.ShoppingCartAPIBase + "/api/cart/RemoveCart"

            });
        }

        public async Task<ResponseDto> UpsertCartsAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppingCartAPIBase + "/api/cart/CartUpsert"

            });
        }
    }
}
