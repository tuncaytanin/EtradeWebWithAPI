using Core.Utilities.Responses;
using EntityLayer.Concrete;
using EntityLayer.Dtos.Auth;
using EntityLayer.Dtos.User;
using System.Threading.Tasks;

namespace WebCoreMvc.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto);
    }
}
