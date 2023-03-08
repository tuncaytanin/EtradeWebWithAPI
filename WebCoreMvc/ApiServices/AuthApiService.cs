﻿using Core.Utilities.Responses;
using EntityLayer.Dtos.Auth;
using EntityLayer.Dtos.User;
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
            var response = await _httpClient.PostAsJsonAsync("Auth/Login",
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
