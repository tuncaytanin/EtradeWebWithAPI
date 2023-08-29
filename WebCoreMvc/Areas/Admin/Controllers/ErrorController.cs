using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebCoreMvc.Models;

namespace WebCoreMvc.Areas.Admin.Controllers
{

    [AllowAnonymous]
    [Area("Admin")]
    public class ErrorController : Controller
    {
        ErrorViewModel errorViewModel;
        public IActionResult MystatusCode(int code)
        {

            if (code == 404)
            {
                errorViewModel = new ErrorViewModel()
                {
                    Code = 404,
                    Message = "Sayfa Bulunamadı",
                    Action = "Error404",
                    Controller = "Error"
                };
            }
            else if (code == 500)
            {
                errorViewModel = new ErrorViewModel()
                {
                    Code = 500,
                    Message = "Sunucu Hatası",
                    Action = "InternalServerError500",
                    Controller = "Error"
                };
            }
            else if (code == 401)
            {
                errorViewModel = new ErrorViewModel()
                {
                    Code = 401,
                    Message = "Yetkisiz Erişim",
                    Action = "UnAuthorize401",
                    Controller = "Error"
                };

            }
            else if (code == 400)
            {
                errorViewModel = new ErrorViewModel()
                {
                    Code = 400,
                    Message = "Geçersiz İstek",
                    Action = "BadRequest400",
                    Controller = "Error"
                };
            }
            else
            {
                errorViewModel = new ErrorViewModel()
                {
                    Code = code,
                    Message = "İsteğiniz gerçekleştirilirken bir hata oluştu",
                    Action = "UnKnowError",
                    Controller = "Error"
                };
            }

            return View("Index", errorViewModel);
        }

        public IActionResult Error404()
        {
            if (errorViewModel == null || errorViewModel.Code != 404)
            {
                errorViewModel = new ErrorViewModel()
                {
                    Code = 404,
                    Message = "Sayfa Bulunamadı",
                    Action = "Error404",
                    Controller = "Error",
                };
            }


            return View("Index",errorViewModel);
        }
        public IActionResult Error401()
        {
            if (errorViewModel == null || errorViewModel.Code != 401)
            {
                errorViewModel = new ErrorViewModel()
                {
                    Code = 401,
                    Message = "Yetkisiz Erişim",
                    Action = "UnAuthorize401",
                    Controller = "Error"
                };
            }


            return View("Index", errorViewModel);
        }
        public IActionResult InternalServerError500()
        {
            if (errorViewModel == null || errorViewModel.Code != 500)
            {
                errorViewModel = new ErrorViewModel()
                {
                    Code = 500,
                    Message = "Sunucu Hatası",
                    Action = "InternalServerError500",
                    Controller = "Error"
                };
            }

            return View("Index", errorViewModel);
        }

        public IActionResult BadRequest400()
        {
            if (errorViewModel == null || errorViewModel.Code != 400)
            {
                errorViewModel = new ErrorViewModel()
                {
                    Code = 400,
                    Message = "Geçersiz İstek",
                    Action = "BadRequest400",
                    Controller = "Error"
                };
            }

            return View("Index", errorViewModel);

        }
        public IActionResult UnKnowError()
        {
            if (errorViewModel == null)
            {
                errorViewModel = new ErrorViewModel()
                {
                    Code = 999,
                    Message = "İsteğiniz gerçekleştirilirken bir hata oluştu",
                    Action = "UnKnowError",
                    Controller = "Error"
                };
            }


            return View("Index", errorViewModel);

        }
    }

}
