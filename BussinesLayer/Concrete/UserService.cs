using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.Extensions.Options;
using Core.Utilities.Security.Token;
using Core.Utilities.Responses;
using Business.Constants;
using AutoMapper;
using System.Linq.Expressions;
using Entities.Dtos.User;
using Core.Aspects.Transaction;
using Core.Aspects.Caching;
using Core.Entites.Concrete;
namespace Business.Concrete
{
    public class UserService : IUserService
    {
        #region Defination
        private readonly AppSettings _appSettings;
        private readonly IAppUserDal _userDal;
        private readonly IMapper _mapper;

        #endregion

        #region Contructor
        public UserService(IAppUserDal userDal,IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _userDal = userDal;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        #endregion


        [CacheAspect(10)]
        public async Task<ApiDataResponse<IEnumerable<UserDetailDto>>> GetListAsync()
        {


            var responses = await _userDal.GetListAsync();
            IEnumerable<UserDetailDto> userDetailDtos = _mapper.Map<IEnumerable<UserDetailDto>>(responses);
            return new SuccessApiDataResponse<IEnumerable<UserDetailDto>>(userDetailDtos, Messages.Listed);



        }


        [TransactionScopeAspect]
        [CacheRemoveAspect("IUserService.GetListAsync")]
        public async Task<ApiDataResponse<UserDto>> AddAsync(UserAddDto userAddDto)
        {

            var user = _mapper.Map<AppUser>(userAddDto);
            //ToDo : CreatedDate and CreatedUserId düzenlenecek
            user.CreatedDate = DateTime.Now;
            user.CreatedUserId = 1;
            var userAdd = await _userDal.AddAsync(user);
            return new SuccessApiDataResponse<UserDto>(_mapper.Map<UserDto>(userAdd), Messages.Added);
        }


        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            var isDeleted = await _userDal.DeleteByIdAsync(id);
                return new SuccessApiDataResponse<bool>(isDeleted, Messages.Deleten);
            


        }

        public async Task<ApiDataResponse<UserDto>> GetAsync(Expression<Func<AppUser, bool>> filter)
        {
   
             var users = await _userDal.GetAsync(filter);

            return new SuccessApiDataResponse<UserDto>(_mapper.Map<UserDto>(users), Messages.Listed);

        }

        public async Task<ApiDataResponse<UserDto>> GetByIdAsync(int id)
        {
            var user = await _userDal.GetByIdAsync(id);
            if (user is not null)
            {
                return new SuccessApiDataResponse<UserDto>(_mapper.Map<UserDto>(user),Messages.Listed);
            }
            return new ErrorApiDataResponse<UserDto>(null,Messages.NotListed);
        }



        public async Task<ApiDataResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto userUpdateDto)
        {

            var getUser = await _userDal.GetByIdAsync(userUpdateDto.Id);
            //ToDo : UpdateDate and UpdateUserId düzenlenecek
            var userWillUpdate = _mapper.Map<AppUser>(userUpdateDto);

            userWillUpdate.UpdateDate = DateTime.Now;
            userWillUpdate.UpdateUserId = 1;
            userWillUpdate.CreatedDate = getUser.CreatedDate;
            userWillUpdate.CreatedUserId = getUser.CreatedUserId;



      
            
           var userUpdated =  await _userDal.UpdateAsync(userWillUpdate);// User türünde değer dönüyor


            return new SuccessApiDataResponse<UserUpdateDto>(_mapper.Map<UserUpdateDto>(userUpdated),Messages.Updated);
           
        }


    }
}
