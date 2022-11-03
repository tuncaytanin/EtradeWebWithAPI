using Core.Entity.Abstract;
using EntityLayer.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Dtos
{
    public class UserDetailDto : IDto
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }

    }
}
