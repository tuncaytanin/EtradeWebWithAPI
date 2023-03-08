using EntityLayer.Concrete;
using EntityLayer.Dtos.User;
using System.Collections.Generic;

namespace WebCoreMvc.ViewModels
{
    public class UserUpdateViewModel
    {

        public UserUpdateDto UserUpdateDto { get; set; } = new UserUpdateDto();
        public List<Gender> Genders { get; set; } = new List<Gender>()
        {
                new Gender(){  Id = true, GenderName = "Erkek"  },
                new Gender(){Id =false,GenderName="Kadın"}
        };
    }
}
