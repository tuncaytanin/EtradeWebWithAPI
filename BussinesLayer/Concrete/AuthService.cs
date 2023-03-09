using BussinesLayer.Abstract;
using EntityLayer.Dtos;
using System.Threading.Tasks;
using Core.Utilities.Security.Token;
using Core.Utilities.Responses;
using BussinesLayer.Constants;
using AutoMapper;
using System;
using EntityLayer.Concrete;
using EntityLayer.Dtos.Auth;
using EntityLayer.Dtos.User;

namespace BussinesLayer.Concrete
{
    public class AuthService : IAuthService
    {
        IUserService _userService;
        ITokenService _tokenService;
        IMapper _mapper;
        public AuthService(IUserService userService, ITokenService tokenService, IMapper mapper)
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _userService = userService;
        }

        public async Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userService.GetAsync(x => x.UserName == loginDto.UserName && x.Password == loginDto.Password);

            if (user.Data is  null)
                return new ErrorApiDataResponse<UserDto>(null, Messages.UserNotFound);
            if (user.Data.TokenExpireDate == null || string.IsNullOrEmpty(user.Data.Token) )
            {
                return await UpdateToken(user);
            }
            if (user.Data.TokenExpireDate < DateTime.UtcNow)
            {
                return await UpdateToken(user);

            }
            return new SuccessApiDataResponse<UserDto>(_mapper.Map<UserDto>(user.Data) ,Messages.SuccessLogin);
        }

        private async Task<ApiDataResponse<UserDto>> UpdateToken(ApiDataResponse<UserDto> user)
        {
            var accessToken = _tokenService.CreateToken(user.Data.Id, user.Data.UserName);
            var userUpdateDto = _mapper.Map<UserUpdateDto>(_mapper.Map<User>(user.Data));
            userUpdateDto.Token = accessToken.Token;
            userUpdateDto.TokenExpireDate = accessToken.Expiration;
            userUpdateDto.PhoneNumber = userUpdateDto.PhoneNumber == null ? string.Empty : userUpdateDto.PhoneNumber;

            var resultUserDto = await _userService.UpdateAsync(userUpdateDto);
            var UserDetailDto = _mapper.Map<UserDto>(_mapper.Map<User>(resultUserDto.Data));

            return new SuccessApiDataResponse<UserDto>(UserDetailDto, Messages.SuccessLogin);
        }
    }
}
