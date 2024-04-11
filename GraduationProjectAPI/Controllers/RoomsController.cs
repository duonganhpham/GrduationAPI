using GraduationProjectAPI.Business.Models;
using GraduationProjectAPI.Business.RoomBusiness;
using GraduationProjectAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SERP.Framework.ApiUtils.Controllers;
using SERP.Framework.ApiUtils.Responses;
using SERP.Framework.ApiUtils.Utils;
using SERP.Framework.Business;
using SERP.Framework.Common;

namespace Graduation_Project_API.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/rooms")]
    [ApiController]
    public class RoomsController : ApiControllerBase
	{
		private readonly IRoomService _roomService;
		public RoomsController(IRoomService roomService, IHttpRequestHelper httpRequestHelper, ILogger<RoomsController> logger)
		: base(httpRequestHelper, logger)
		{
			_roomService = roomService;
		}
		///////////////////////////////////////////////////////////////////////////
		[HttpPost("")]
		[ProducesResponseType(typeof(ResponseObject<Room>), StatusCodes.Status200OK)]
		public async Task<IActionResult> Create([FromForm] RoomRequestModel model)
		{
			return await ExecuteFunction(async (RequestUser user, Guid? applicationId) =>
			{
				var room = new Room
				{
					RomOwnerId = model.RomOwnerId,
					Name = model.Name,
					Address = model.Address,
					Type = model.Type,
					Area = model.Area,
					Price = model.Price,
					WifiInternet = model.WifiInternet,
					AirConditioner = model.AirConditioner,
					WaterHeater = model.WaterHeater,
					Refrigerator = model.Refrigerator,
					WashingMachine = model.WashingMachine,
					EnclosedToilet = model.EnclosedToilet,
					SafedDevice = model.SafedDevice,
					ElectronicPrice = model.ElectronicPrice,
					WaterPrice = model.WaterPrice,
					Description = model.Description,
				};
				return await _roomService.AddRoomAsync(applicationId ?? user.ApplicationId, room, room.RomOwnerId, model.Images);
			});
		}
	}
}
