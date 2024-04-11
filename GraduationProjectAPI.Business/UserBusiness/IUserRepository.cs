using GraduationProjectAPI.Business.Models;
using GraduationProjectAPI.Entities;
using SERP.Framework.Common;


namespace GraduationProjectAPI.Business.UserBusiness
{
    public interface IUserRepository
    {
        public const string Message_UserNotFound = "User Not Found";
        public Task<Pagination<User>> GetAllUserAsync(Guid applicationId, UserQueryModel queryModel);
        public Task<User> GetUserByIdAsync(Guid applicationId, Guid Uid);
        public Task<User> AddUserAsync(Guid applicationId, User user);
        public Task<User> DeleteUserAsync(Guid applicationId, Guid Uid);
    }
}
