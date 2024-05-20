using GraduationProjectAPI.Business.Models;
using GraduationProjectAPI.Entities;
using Microsoft.AspNetCore.Http;
using SERP.Framework.Common;

namespace GraduationProjectAPI.Business.RoomBusiness
{
	public interface IRoomService
    {
		public Task<Pagination<Room>> GetAllRoomAsync(Guid applicationId, RoomQueryModel queryModel);
		public Task<Room> GetRoomByIdAsync(Guid applicationId, Guid id);
        public Task<Room> AddRoomAsync(Guid applicationId, Room room, Guid uid, List<IFormFile> images);
        public Task<Room> DeleteRoomAsync(Guid applicationId, Guid id);
	  
    }
}
