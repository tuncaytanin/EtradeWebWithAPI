using Core.Entity.Abstract;

namespace EntityLayer.Dtos.Auth
{
    public class LoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsRememberMe { get; set; }
    }
}
