using Core.Utilities.Responses;
using Entities.Concrete;
using Entities.Dtos.Auth;
using Entities.Dtos.User;
using System.Threading.Tasks;

namespace WebCoreMvc.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto);
    }
}
