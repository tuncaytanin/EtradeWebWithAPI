using BussinesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Core.Utilities.Security.Token;
using Core.Utilities.Responses;
using BussinesLayer.Constants;
using AutoMapper;
using System.Linq.Expressions;

namespace BussinesLayer.Concrete
{
    public class UserService : IUserService
    {
        #region Defination
        private readonly AppSettings _appSettings;
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        #endregion

        #region Contructor
        public UserService(IUserDal userDal,IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _userDal = userDal;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        #endregion

        public async Task<ApiDataResponse<UserDto>> AddAsync(UserAddDto userAddDto)
        {
            //User user = new User()
            //{
            //    UserName = userAddDto.UserName,
            //    Adress = userAddDto.Adress,
            //    //ToDo => CreateDate ve CreateUserID düzenlenecek...
            //    CreatedDate = DateTime.Now,
            //    CreatedUserId = 1,
            //    DateOfBirth = userAddDto.DateOfBirth,
            //    Email = userAddDto.Email,
            //    FirstName = userAddDto.FirstName,
            //    Gender = userAddDto.Gender,
            //    LastName = userAddDto.LastName,
            //    Password = userAddDto.Password,
            //    UpdateDate = DateTime.Now,
            //    UpdateUserId = 1

            //};

            var user = _mapper.Map<User>(userAddDto);
            //ToDo : CreatedDate and CreatedUserId düzenlenecek
            user.CreatedDate = DateTime.Now;
            user.CreatedUserId = 1;
            var userAdd = await _userDal.AddAsync(user);

            //UserDto userDto=  new UserDto()
            //{
            //    Adress = user.Adress,
            //    DateOfBirth = user.DateOfBirth,
            //    Email = user.Email,
            //    FirstName = user.FirstName,
            //    Gender = user.Gender,
            //    Id = user.Id,
            //    LastName = user.LastName,
            //    UserName = user.UserName
            //};

            return new SuccessApiDataResponse<UserDto>(_mapper.Map<UserDto>(userAdd), Messages.Added);
        }

        //public async Task<ApiDataResponse<AccessToken>> Authenticate(UserForLoginDto userForLoginDto)
        //{
        //    var user = await _userDal.GetAsync(x => x.UserName == userForLoginDto.UserName && x.Password == userForLoginDto.Password);

        //    if (user is null)
        //        return null;

  
            

            
     
        //}

        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            var isDeleted = await _userDal.DeleteByIdAsync(id);
                return new SuccessApiDataResponse<bool>(isDeleted, Messages.Deleten);
            


        }

        public async Task<ApiDataResponse<UserDto>> GetAsync(Expression<Func<User, bool>> filter)
        {
   
             var users = await _userDal.GetAsync(filter);

             return new SuccessApiDataResponse<UserDto>(_mapper.Map<UserDto>(users), Messages.Listed);

        }

        public async Task<ApiDataResponse<UserDto>> GetByIdAsync(int id)
        {
            var user = await _userDal.GetByIdAsync(id);
            if (user is not null)
            {
                //UserDto userDto = new UserDto()
                //{
                //    Adress = user.Adress,
                //    DateOfBirth = user.DateOfBirth,
                //    Email = user.Email,
                //    FirstName = user.FirstName,
                //    Gender = user.Gender,
                //    Id = user.Id,
                //    LastName = user.LastName,
                //    UserName = user.UserName

                //};
                return new SuccessApiDataResponse<UserDto>(_mapper.Map<UserDto>(user),Messages.Listed);
            }
            return new ErrorApiDataResponse<UserDto>(null,Messages.NotListed);
        }

        public async Task<ApiDataResponse<IEnumerable<UserDetailDto>>> GetListAsync(Expression<Func<User, bool>> filter = null)
        {
            
                if (filter is null)
                {
                    var responses = await _userDal.GetListAsync();
                    IEnumerable<UserDetailDto> userDetailDtos = _mapper.Map<IEnumerable<UserDetailDto>>(responses);
                    return new SuccessApiDataResponse<IEnumerable<UserDetailDto>>(userDetailDtos, Messages.Listed);
                }
                else
                {
                    var responses = await _userDal.GetListAsync(filter);
                    IEnumerable<UserDetailDto> userDetailDtos = _mapper.Map<IEnumerable<UserDetailDto>>(responses);
                    return new SuccessApiDataResponse<IEnumerable<UserDetailDto>>(userDetailDtos, Messages.Listed);
                }
            

                // autoMapper ile üst satırda yapıyorumm
            //foreach (var item in responses.ToList())
            //{
            //    UserDetailDto userDetailDto = new UserDetailDto()
            //    {
            //        Adress = item.Adress,
            //        DateOfBirth = item.DateOfBirth,
            //        Email = item.Email,
            //        FirstName = item.FirstName,
            //        Gender = item.Gender == true ? "Erkek" : "Kadın",
            //        LastName = item.LastName,
            //        UserName = item.UserName,
            //        Id = item.Id
            //    };



            //    userDetailDtos.Add(userDetailDto);


            //}

        }

        public async Task<ApiDataResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto userUpdateDto)
        {

            var getUser = await _userDal.GetByIdAsync(userUpdateDto.Id);
            //ToDo : UpdateDate and UpdateUserId düzenlenecek
            var userWillUpdate = _mapper.Map<User>(userUpdateDto);
            userWillUpdate.UpdateDate = DateTime.Now;
            userWillUpdate.UpdateUserId = 1;
            userWillUpdate.CreatedDate = getUser.CreatedDate;
            userWillUpdate.CreatedUserId = getUser.CreatedUserId;

            //User user = new User()
            //{
            //    UserName = userUpdateDto.UserName,
            //    Adress = userUpdateDto.Adress,
            //    //ToDo => CreateDate ve CreateUserID düzenlenecek...
            //    CreatedDate = getUser.CreatedDate,
            //    CreatedUserId = getUser.CreatedUserId,
            //    DateOfBirth = userUpdateDto.DateOfBirth,
            //    Email = userUpdateDto.Email,
            //    FirstName = userUpdateDto.FirstName,
            //    Gender = userUpdateDto.Gender,
            //    LastName = userUpdateDto.LastName,
            //    Password = userUpdateDto.Password,
            //    UpdateDate = DateTime.Now,
            //    UpdateUserId = 1,
            //    Id= userUpdateDto.Id

            //};

            
           var userUpdated =  await _userDal.UpdateAsync(userWillUpdate);// User türünde değer dönüyor


            return new SuccessApiDataResponse<UserUpdateDto>(_mapper.Map<UserUpdateDto>(userUpdated),Messages.Updated);
           
        }

    }
}
