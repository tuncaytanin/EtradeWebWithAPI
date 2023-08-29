using Core.Entites.BaseEntities;
using System;
using System.Transactions;

namespace Core.Entites.Concrete
{
    public class User:CreatedUpdatedDeletedEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }

        public string GsmNumber { get; set; }
        public string ProfileImageUrl { get; set; }

        public int UserTypeId { get; set; }
    }
}
