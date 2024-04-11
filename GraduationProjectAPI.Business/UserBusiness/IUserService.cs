using GraduationProjectAPI.Business.Models;
using GraduationProjectAPI.Entities;
using SERP.Framework.Common;


namespace GraduationProjectAPI.Business.UserBusiness
{
    public interface IUserService
    {
        public Task<Pagination<User>> GetAllUserAsync(Guid applicationId, UserQueryModel queryModel);
        public Task<User> GetUserByIdAsync(Guid applicationId, Guid UserId);
        public Task<User> AddUserAsync(Guid applicationId, User user);
        public Task<User> DeleteUserAsync(Guid applicationId, Guid UserId);
    }
}
