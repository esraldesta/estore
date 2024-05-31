using Store.Web.Models;

namespace Store.Web.Service.IService
{
    public interface ICartService
    {
        Task<ResponseDto> GetCartByUserIDAsync(string userId);
        Task<ResponseDto> UpsertCartsAsync(CartDto cartDto);
        Task<ResponseDto> RemoveFromCartsAsync(int  cartDetailsId);
        Task<ResponseDto> ApplyCouponAsync(CartDto cartDto);
    }
}
