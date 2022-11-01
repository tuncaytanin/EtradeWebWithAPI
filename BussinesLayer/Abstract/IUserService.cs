﻿using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IUserService
    {
        Task<IEnumerable<UserDetailDto>> GetListAsync();

        Task<UserDto> GetByIdAsync(int id);

        Task<UserDto> AddAsync(UserAddDto userAddDto);

        Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto);
        Task<bool> DeleteAsync(int id);
    }

}
