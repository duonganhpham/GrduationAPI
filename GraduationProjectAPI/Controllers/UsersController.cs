using GraduationProjectAPI.Business.Models;
using GraduationProjectAPI.Business.UserBusiness;
using GraduationProjectAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using SERP.Framework.ApiUtils.Controllers;
using SERP.Framework.ApiUtils.Responses;
using SERP.Framework.ApiUtils.Utils;
using SERP.Framework.Business;
using SERP.Framework.Common;
using System.Text.Json;

namespace Graduation_Project_API.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/users")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {

        private readonly IUserService _userService;
        public UsersController(IUserService userService, IHttpRequestHelper httpRequestHelper, ILogger<UsersController> logger)
        : base(httpRequestHelper, logger)
        {
            _userService = userService;
        }
        ///////////////////////////////////////////////////////////////////////////
		[HttpGet()]
		[ProducesResponseType(typeof(ResponsePagination<User>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAll(
			[FromQuery] int? page,
			[FromQuery] int? size,
			[FromQuery] string? sort = "",
			[FromQuery] string? filter = "{ }")
		{
			return await ExecuteFunction(async (RequestUser user, Guid? applicationId) =>
			{
				var filterObject = JsonSerializer.Deserialize<UserQueryModel>(filter);
				if (!string.IsNullOrWhiteSpace(sort)) filterObject.Sort = sort;
				if (size.HasValue) filterObject.PageSize = size;
				if (page.HasValue) filterObject.CurrentPage = page;
				var result = await _userService.GetAllUserAsync(applicationId ?? user.ApplicationId, filterObject);
				return result;
			});
		}
		//////////////////////////////////////////////
		[HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseObject<User>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            return await ExecuteFunction(async (RequestUser user, Guid? applicationId) =>
            {
                return await _userService.GetUserByIdAsync(applicationId ?? user.ApplicationId, id);
            });
        }
        ///////////////////////////////////////////
        [HttpPost("")]
        [ProducesResponseType(typeof(ResponseObject<User>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] UserRequestModel model)
        {
            return await ExecuteFunction(async (RequestUser user, Guid? applicationId) =>
            {
                var mapper = AutoMapperUtils.GetIgnoreNullMapper<UserRequestModel, User>();
                var customer = mapper.Map<UserRequestModel, User>(model);

                return await _userService.AddUserAsync(applicationId ?? user.ApplicationId, customer);
            });
        }
        ////////////////////////////////////////
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseObject<User>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await ExecuteFunction(async (RequestUser user, Guid? applicationId) =>
            {
                return await _userService.DeleteUserAsync(applicationId ?? user.ApplicationId, id);
            });
        }
    }
}
