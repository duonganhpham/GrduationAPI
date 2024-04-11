using Microsoft.AspNetCore.Http;
namespace GraduationProjectAPI.Business.RoomImageBusiness
{
	public interface IRoomImageRepository
	{
		Task SaveImagesAsync(Guid applicationId, List<IFormFile> images, Guid roomId);
		Task SaveImageAsync(Guid applicationId, IFormFile image, Guid roomId);
	}
}
