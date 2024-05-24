using Newtonsoft.Json;
using Store.Web.Models;
using Store.Web.Service.IService;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using static Store.Web.Utility.SD;

namespace Store.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;
        public BaseService(IHttpClientFactory httpClientFactory,ITokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
            _httpClientFactory = httpClientFactory;

        }
        public async Task<ResponseDto> SendAsync(RequestDTO requestDTO, bool withBearer = true)
        {
            HttpClient client = _httpClientFactory.CreateClient("EstoreAPI");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            // token
            if (withBearer) { 
                var token = _tokenProvider.GetToken();
                message.Headers.Add("Authorization", $"Bearer {token}");
            }

            message.RequestUri = new Uri(requestDTO.Url);
            if (requestDTO.Data != null) {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDTO.Data), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage? apiResponse = null;
            switch (requestDTO.ApiType) {

                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;

                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;

                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;

                default:
                    message.Method = HttpMethod.Get;
                    break;
            }
            apiResponse = await client.SendAsync(message);
            try
            {

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false

                };
                return dto;
            }
        }
    }
}
