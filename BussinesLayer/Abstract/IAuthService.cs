using Core.Utilities.Responses;
using EntityLayer.Dtos;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IAuthService
    {
        Task<ApiDataResponse<UserDetailDto>> LoginAsync(LoginDto loginDto);
    }
}
