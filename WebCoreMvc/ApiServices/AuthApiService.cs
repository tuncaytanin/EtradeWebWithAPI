using Core.Utilities.Responses;
using Entities.Concrete;
using Entities.Dtos.Auth;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebCoreMvc.ApiServices.Interfaces;

namespace WebCoreMvc.ApiServices
{
    public class AuthApiService : IAuthApiService
    {

        private HttpClient _httpClient;
        public AuthApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("Auths/Login",
                loginDto);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiDataResponse<UserDto>>(data);
                return await Task.FromResult(result);
            }
            return null;
        }
    }
}
