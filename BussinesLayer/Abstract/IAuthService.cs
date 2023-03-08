using Core.Utilities.Responses;
using EntityLayer.Dtos;
using EntityLayer.Dtos.Auth;
using EntityLayer.Dtos.User;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IAuthService
    {
        Task<ApiDataResponse<UserDetailDto>> LoginAsync(LoginDto loginDto);
    }
}
