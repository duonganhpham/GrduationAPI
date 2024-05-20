//using GraduationProjectAPI.Business.RoomBusiness;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GraduationProjectAPI.Business.RoomImageBusiness
//{
//	public class RoomImageService : IRoomImageService
//	{
//		private readonly IRoomImageRepository _roomImageRepository;
//		public RoomImageService(IRoomImageRepository roomImageRepository)
//		{
//			_roomImageRepository = roomImageRepository;
//		}
//		public async Task SaveImagesAsync(Guid applicationId, Guid roomId, List<IFormFile> images)
//		{
//			await _roomImageRepository.SaveImagesAsync(applicationId, roomId, images);
//		}
//	}
//}
