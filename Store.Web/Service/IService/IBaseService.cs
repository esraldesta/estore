using Store.Web.Models;

namespace Store.Web.Service.IService
{
    public interface IBaseService
    {
       Task<ResponseDto> SendAsync(RequestDTO requestDTO,bool withBearer=true);
    }
}
