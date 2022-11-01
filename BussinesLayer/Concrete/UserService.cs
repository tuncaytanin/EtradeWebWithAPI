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

namespace BussinesLayer.Concrete
{
    public class UserService : IUserService
    {

        private readonly IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<UserDto> AddAsync(UserAddDto userAddDto)
        {
            User user = new User()
            {
                UserName = userAddDto.UserName,
                Adress = userAddDto.Adress,
                //ToDo => CreateDate ve CreateUserID düzenlenecek...
                CreatedDate = DateTime.Now,
                CreatedUserId = 1,
                DateOfBirth = userAddDto.DateOfBirth,
                Email = userAddDto.Email,
                FirstName = userAddDto.FirstName,
                Gender = userAddDto.Gender,
                LastName = userAddDto.LastName,
                Password = userAddDto.Password,
                UpdateDate = DateTime.Now,
                UpdateUserId = 1

            };

            user = await _userDal.AddAsync(user);

            return new UserDto()
            {
                Adress = user.Adress,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                Gender = user.Gender,
                Id = user.Id,
                LastName = user.LastName,
                UserName = user.UserName
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userDal.DeleteByIdAsync(id);

        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _userDal.GetByIdAsync(id);
            if (user is not null)
            {
                UserDto userDto = new UserDto()
                {
                    Adress = user.Adress,
                    DateOfBirth = user.DateOfBirth,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Gender = user.Gender,
                    Id = user.Id,
                    LastName = user.LastName,
                    UserName = user.UserName

                };
                return userDto;
            }
            return null;
        }

        public async Task<IEnumerable<UserDetailDto>> GetListAsync()
        {
            var responses = await _userDal.GetListAsync();
            List<UserDetailDto> userDetailDtos = new List<UserDetailDto>();
            foreach (var item in responses.ToList())
            {
                UserDetailDto userDetailDto = new UserDetailDto()
                {
                    Adress = item.Adress,
                    DateOfBirth = item.DateOfBirth,
                    Email = item.Email,
                    FirstName = item.FirstName,
                    Gender = item.Gender == true ? "Erkek" : "Kadın",
                    LastName = item.LastName,
                    UserName = item.UserName,
                    Id = item.Id
                };



                userDetailDtos.Add(userDetailDto);


            }
            return userDetailDtos;
        }

        public async Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto)
        {

            var getUser = await _userDal.GetByIdAsync(userUpdateDto.Id);

            User user = new User()
            {
                UserName = userUpdateDto.UserName,
                Adress = userUpdateDto.Adress,
                //ToDo => CreateDate ve CreateUserID düzenlenecek...
                CreatedDate = getUser.CreatedDate,
                CreatedUserId = getUser.CreatedUserId,
                DateOfBirth = userUpdateDto.DateOfBirth,
                Email = userUpdateDto.Email,
                FirstName = userUpdateDto.FirstName,
                Gender = userUpdateDto.Gender,
                LastName = userUpdateDto.LastName,
                Password = userUpdateDto.Password,
                UpdateDate = DateTime.Now,
                UpdateUserId = 1,
                Id= userUpdateDto.Id

            };

            user =  await _userDal.UpdateAsync(user);

            UserUpdateDto userUpdate = new UserUpdateDto()
            {
                UserName = userUpdateDto.UserName,
                Adress = userUpdateDto.Adress,
                DateOfBirth = userUpdateDto.DateOfBirth,
                Email = userUpdateDto.Email,
                FirstName = userUpdateDto.FirstName,
                Gender = userUpdateDto.Gender,
                LastName = userUpdateDto.LastName,
                Password = userUpdateDto.Password,
                Id = userUpdateDto.Id
            };

            return userUpdate;
           
        }
    }
}
