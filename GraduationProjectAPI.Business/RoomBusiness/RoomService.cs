using GraduationProjectAPI.Business.Models;
using GraduationProjectAPI.Business.RoomImageBusiness;
using GraduationProjectAPI.Business.UserBusiness;
using GraduationProjectAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using SERP.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProjectAPI.Business.RoomBusiness
{
	public class RoomService : IRoomService
	{
		private readonly IRoomRepository _roomRepository;
		private readonly IRoomImageRepository _roomImageRepository;
		public RoomService(IRoomRepository roomRepository, IRoomImageRepository roomImageRepository)
		{
			_roomRepository = roomRepository;
			_roomImageRepository = roomImageRepository;
		}

		public async Task<Pagination<Room>> GetAllRoomAsync(Guid applicationId, RoomQueryModel queryModel)
		{
			queryModel.PageSize = queryModel.PageSize.HasValue ? queryModel.PageSize.Value : 20;
			queryModel.CurrentPage = queryModel.CurrentPage.HasValue ? queryModel.CurrentPage.Value : 1;

			return await _roomRepository.GetAllRoomAsync(applicationId, queryModel);
		}

		public async Task<Room> GetRoomByIdAsync(Guid applicationId, Guid id)
		{
			return await _roomRepository.GetRoomByIdAsync(applicationId, id);
		}

		public async Task<Room> AddRoomAsync(Guid applicationId, Room room, Guid uid, List<IFormFile> images)
		{
			await _roomImageRepository.SaveImagesAsync(applicationId, images, room.Id);
			return await _roomRepository.AddRoomAsync(applicationId, room, uid);
		}
		public async Task<Room> DeleteRoomAsync(Guid applicationId, Guid id)
		{
			return await _roomRepository.DeleteRoomAsync(applicationId, id);
		}
	}
}
