﻿using EntityLayer.Abstract;
using System;

namespace EntityLayer.Dtos
{
    public class UserDetailDto : IDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
    }
}
