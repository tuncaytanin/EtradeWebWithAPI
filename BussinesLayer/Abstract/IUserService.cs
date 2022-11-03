﻿using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IUserService
    {
        Task<ApiDataResponse<IEnumerable<UserDetailDto>>> GetListAsync(Expression<Func<User,bool>> filter = null);

        Task<ApiDataResponse<UserDto>> GetAsync(Expression<Func<User, bool>> filter);
        Task<ApiDataResponse<UserDto>> GetByIdAsync(int id);

        Task<ApiDataResponse<UserDto>> AddAsync(UserAddDto userAddDto);

        Task<ApiDataResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto userUpdateDto);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);

        //Task<ApiDataResponse<AccessToken>> Authenticate(UserForLoginDto userForLoginDto);
    }

}
