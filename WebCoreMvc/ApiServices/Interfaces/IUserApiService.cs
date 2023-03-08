using EntityLayer.Dtos.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebCoreMvc.ApiServices.Interfaces
{
    public interface IUserApiService
    {
        Task<List<UserDetailDto>> GetListAsync();
    }
}
