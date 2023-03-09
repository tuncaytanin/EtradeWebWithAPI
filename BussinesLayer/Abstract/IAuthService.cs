using Core.Utilities.Responses;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using EntityLayer.Dtos.Auth;
using EntityLayer.Dtos.User;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IAuthService
    {
        Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto);

    }
}
