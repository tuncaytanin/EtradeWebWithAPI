using Core.Entites;
using Entities.Abstract;

using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos.User
{
    public class UserUpdateDto : IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpireDate { get; set; }
    }
}
