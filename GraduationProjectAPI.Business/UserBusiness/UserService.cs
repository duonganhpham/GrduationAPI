using GraduationProjectAPI.Business.Models;
using GraduationProjectAPI.Entities;
using SERP.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProjectAPI.Business.UserBusiness
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUserAsync(Guid applicationId, User user)
        {
            return await _userRepository.AddUserAsync(applicationId, user);
        }

        public async Task<User> DeleteUserAsync(Guid applicationId, Guid Uid)
        {
            var result = await _userRepository.DeleteUserAsync(applicationId, Uid);
            return result;
        }

        public async Task<Pagination<User>> GetAllUserAsync(Guid applicationId, UserQueryModel queryModel)
        {
            queryModel.PageSize = queryModel.PageSize.HasValue ? queryModel.PageSize.Value : 20;
            queryModel.CurrentPage = queryModel.CurrentPage.HasValue ? queryModel.CurrentPage.Value : 1;

            return await _userRepository.GetAllUserAsync(applicationId, queryModel);
        }

        public async Task<User> GetUserByIdAsync(Guid applicationId, Guid Uid)
        {
            return await _userRepository.GetUserByIdAsync(applicationId, Uid);
        }
    }
}
