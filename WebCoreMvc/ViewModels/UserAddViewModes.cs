using Entities.Concrete;
using Entities.Dtos.User;
using System;
using System.Collections.Generic;

namespace WebCoreMvc.ViewModels
{
    public class UserAddViewModes
    {


        //public string UserName { get; set; }
        //public string FirstName { get; set; }

        //public string LastName { get; set; }
        //public string Password { get; set; }
        //public int GenderId { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime DateOfBirth { get; set; }
        //public string Email { get; set; }
        //public string Adress { get; set; }

        public UserAddDto UserAddDto { get; set; } = new UserAddDto();

    }
}
