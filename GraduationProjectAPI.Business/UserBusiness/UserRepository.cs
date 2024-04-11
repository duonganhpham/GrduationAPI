using GraduationProjectAPI.Business.Models;
using GraduationProjectAPI.DB;
using GraduationProjectAPI.Entities;
using Microsoft.EntityFrameworkCore;
using SERP.Framework.Common;
using SERP.Framework.DB.Extensions;
using SERP.Framework.Business;

namespace GraduationProjectAPI.Business.UserBusiness
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(Guid applicationId, User user)
        {
            if (user.Uid == Guid.Empty)
            {
                user.Uid = Guid.NewGuid();
                user.ApplicationId = applicationId;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return user;
            }
            else
            {
                var userUpdate = await GetUserByIdAsync(applicationId, user.Uid);
                if (userUpdate == null)
                {
                    throw new ArgumentException(IUserRepository.Message_UserNotFound);
                }
                userUpdate.AvatarUrl = user.AvatarUrl;
                userUpdate.PhoneNumber = user.PhoneNumber;
                userUpdate.Gender = user.Gender;
                userUpdate.DateOfBirth = user.DateOfBirth;
                userUpdate.PhoneNumber = user.PhoneNumber;
                _context.Users.Update(userUpdate);
                await _context.SaveChangesAsync();

                return userUpdate;
            }
        }
        public async Task<Pagination<User>> GetAllUserAsync(Guid applicationId, UserQueryModel queryModel)
        {
            queryModel.PageSize = queryModel.PageSize.HasValue ? queryModel.PageSize.Value : 20;
            queryModel.CurrentPage = queryModel.CurrentPage.HasValue ? queryModel.CurrentPage.Value : 1;

            var query = _context.Users.Where(x => x.ApplicationId != null);
            if (!string.IsNullOrWhiteSpace(queryModel.FullTextSearch))
            {
                query = query.Where(x =>
                x.PhoneNumber.Contains(queryModel.FullTextSearch) ||
                x.UserName.Contains(queryModel.FullTextSearch)
                );
            }
            // Ex for user sorting.
            var sortExpression = string.Empty;
            if (string.IsNullOrWhiteSpace(queryModel.Sort) || queryModel.Sort.Equals("-LastModifiedOnDate"))
            {
            // user sorting
                query = query.OrderBy(x => x.UserName);
            }
            else
            {
                sortExpression = QueryUtils.FormatSortInput(queryModel.Sort);
            }
            return await query.GetPagedAsync<User>(queryModel.CurrentPage.Value, queryModel.PageSize.Value, sortExpression);
        }
        public async Task<User> GetUserByIdAsync(Guid applicationId, Guid Uid)
        {
            var result = await _context.Users
                                     .FirstOrDefaultAsync(x => x.Uid == Uid);
            return result;
        }

        public async Task<User> DeleteUserAsync(Guid applicationId, Guid Uid)
        {
            var user = await _context.Users
                                    .FirstOrDefaultAsync(x => x.Uid == Uid);

            if (user == null)
            {
                throw new ArgumentException(IUserRepository.Message_UserNotFound);
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
