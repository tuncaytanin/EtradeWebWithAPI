using EntityLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebCoreMvc.Controllers
{
    public class UsersController : Controller
    {
        #region Define
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:44340/api/";
        #endregion

        #region UsersController Constructor

        public UsersController(HttpClient httpClient)
        {
            _httpClient=httpClient;
        }
        #endregion
        public async Task<IActionResult> Index()
        {

            var users = await _httpClient.GetFromJsonAsync<List<UserDetailDto>>(url + "Users/GetList");
            return View(users);
        }
    }
}
