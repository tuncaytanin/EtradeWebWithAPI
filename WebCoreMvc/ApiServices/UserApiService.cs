using Core.Utilities.Responses;
using Entities.Concrete;
using Entities.Dtos.User;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebCoreMvc.ApiServices.Interfaces;

namespace WebCoreMvc.ApiServices
{
    public class UserApiService : IUserApiService
    {

        private HttpClient _httpClient;
        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<UserDetailDto>> GetListAsync()
        {
            var response = await _httpClient.GetAsync("Users/Getlist");
        
            if (!response.IsSuccessStatusCode)
                return null;
            var responseSuccess = await response.Content.ReadFromJsonAsync<ApiDataResponse<IEnumerable<UserDetailDto>>>();


            return responseSuccess.Data.ToList();

        }

    }
}
