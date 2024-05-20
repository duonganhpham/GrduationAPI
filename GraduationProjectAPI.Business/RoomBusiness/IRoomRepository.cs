using GraduationProjectAPI.Business.Models;
using GraduationProjectAPI.Entities;
using SERP.Framework.Common;

namespace GraduationProjectAPI.Business.RoomBusiness
{
	public interface IRoomRepository
	{
		public const string Message_RoomNotFound = "Room Not Found";
		public Task<Pagination<Room>> GetAllRoomAsync(Guid applicationId, RoomQueryModel queryModel);
		public Task<Room> GetRoomByIdAsync(Guid applicationId, Guid id);
		public Task<Room> AddRoomAsync(Guid applicationId, Room room, Guid uid);
        public Task<Room> DeleteRoomAsync(Guid applicationId, Guid id);
	}
}
