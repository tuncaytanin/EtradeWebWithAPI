using Core.Entity.Abstract;

namespace EntityLayer.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
