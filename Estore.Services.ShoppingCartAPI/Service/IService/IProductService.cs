using Estore.Services.ShoppingCartAPI.Models.Dto;

namespace Estore.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}