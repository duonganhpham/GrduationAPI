using GraduationProjectAPI.DB;
using GraduationProjectAPI.Entities;
using Microsoft.AspNetCore.Http;
using System;


namespace GraduationProjectAPI.Business.RoomImageBusiness
{
	public class RoomImageRepository : IRoomImageRepository
	{
		private readonly DataContext _context;

		public RoomImageRepository(DataContext context)
		{
			_context = context;
		}

		public async Task SaveImagesAsync(Guid applicationId, List<IFormFile> images, Guid roomid)
		{
			if (images != null && images.Count > 0)
			{
				foreach (var image in images)
				{
					SaveImageAsync(applicationId, image, roomid);
				}
			}
		}

		public async Task SaveImageAsync(Guid applicationId, IFormFile image, Guid roomid)
		{
			// Tạo thư mục nếu chưa tồn tại
			var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
			if (!Directory.Exists(uploadsPath))
			{
				Directory.CreateDirectory(uploadsPath);
			}
			Guid newId = Guid.NewGuid();
			// Tạo tên file duy nhất
			var fileName = newId.ToString() + Path.GetExtension(image.FileName);
			var filePath = Path.Combine(uploadsPath, fileName);

			// Lưu trữ file
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await image.CopyToAsync(stream);
			}

			// Trả về URL truy cập hình ảnh
			var filePath2 = $"uploads/{fileName}";
			var roomImage = new RoomImage
			{
				Id = newId,
				RoomId = roomid,
				ImageUrl = filePath2,
				ApplicationId = applicationId
			};
			_context.RoomImages.Add(roomImage);
			await _context.SaveChangesAsync();
		}
	}
}
