using EntityLayer.Concrete;
using EntityLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebCoreMvc.ViewModels;

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

        [HttpGet]
        public IActionResult Add()
        {

            UserAddViewModes userAddViewModes = new UserAddViewModes();
            return View(userAddViewModes);
        }


        [HttpPost]
        public async Task<IActionResult> Add(UserAddViewModes userAddViewModel)
        {
            UserAddDto userAddDto = new UserAddDto()
            {
                Adress = userAddViewModel.UserAddDto.Adress,
                DateOfBirth = userAddViewModel.UserAddDto.DateOfBirth,
                Email = userAddViewModel.UserAddDto.Email,
                FirstName = userAddViewModel.UserAddDto.FirstName,
                Gender = userAddViewModel.UserAddDto.Gender,
                LastName = userAddViewModel.UserAddDto.LastName,
                Password = userAddViewModel.UserAddDto.Password,
                UserName = userAddViewModel.UserAddDto.UserName
            };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url + "Users/Add", userAddDto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var userUpdateDto = await _httpClient.GetFromJsonAsync<UserUpdateDto>(url + "users/GetById/" + id.ToString());

            UserUpdateViewModel userUpdateViewModel = new UserUpdateViewModel()
            {
                UserUpdateDto = userUpdateDto
            };
            return View(userUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id,UserUpdateViewModel userUpdateViewModel)
        {

            if (userUpdateViewModel.UserUpdateDto.Id ==0)
                return BadRequest();


            HttpResponseMessage result = await _httpClient.PutAsJsonAsync<UserUpdateDto>(url + "users/update/", userUpdateViewModel.UserUpdateDto);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(result);
        }

    }
}
