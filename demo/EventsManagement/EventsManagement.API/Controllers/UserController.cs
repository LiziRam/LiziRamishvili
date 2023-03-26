using EventsManagement.API.Infrastructure.Auth.JWT;
using EventsManagement.Application.Events.Requests;
using EventsManagement.Application.Events.Responses;
using EventsManagement.Application.Users;
using EventsManagement.Application.Users.Requests;
using EventsManagement.Application.Users.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EventsManagement.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IOptions<JWTConfiguration> _options;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IOptions<JWTConfiguration> options,
            IHttpContextAccessor accessor)
        {
            _userService = userService;
            _options = options;
        }

        //1. ------------------------------მომხმარებლისთვის---------------------------------

        /// <summary>
        /// Register a User
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// 
        /// <remarks>
        /// Example:
        /// 
        ///     POST /User
        ///     {
        ///       "userName": "FirstUser",
        ///       "email": "firstuser@gmail.com",
        ///       "firstName": "Lizi",
        ///       "lastName": "Ramishvili",
        ///       "password": "Abc123$"
        ///     }
        /// </remarks>
        [Route("Register")]
        [HttpPost]
        public async Task<UserResponseModel> Register(CancellationToken cancellationToken,
            UserCreateRequestModel userCreateRequest) =>
            await _userService.CreateAsync(cancellationToken, userCreateRequest).ConfigureAwait(false);


        /// <summary>
        /// Log in as a User
        /// </summary>
        /// <param name="cancellationToken"></param>
        ///
        /// <remarks>
        /// Example: 
        /// 
        ///     POST /User/PostToLogin
        ///     {
        ///       "userName": "FirstUser",
        ///       "password": "Abc123$"
        ///     }
        /// After successful authentication, returns JWT Token.
        /// </remarks>
        [Route("LogIn")]
        [HttpPost]
        public async Task<string> LogIn(CancellationToken cancellationToken, UserLoginRequestModel userLoginRequest)
        {
            var username = await _userService.AuthenticateAsync(cancellationToken, userLoginRequest.UserName,
                userLoginRequest.Password).ConfigureAwait(false);
            var userId = await _userService.GetIdByUsername(cancellationToken, userLoginRequest.UserName).ConfigureAwait(false);

            return JWTHelper.GenerateSecurityToken(username, userId, _options);
        }


        [HttpGet("{id}")]
        public async Task<UserResponseModel> GetDetails(CancellationToken cancellationToken, int id) =>
            await _userService.GetAsync(cancellationToken, id).ConfigureAwait(false);


        /// <summary>
        /// Update a User
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// 
        /// <remarks>
        /// Example:
        /// 
        ///     PUT /User
        ///     {
        ///       "userName": "FirstUser",
        ///       "email": "updatedemail@gmail.com",
        ///       "firstName": "Elisabed",
        ///       "lastName": "Ramishvili",
        ///       "password": "Abc123$"
        ///     }
        /// </remarks>
        [HttpPut("{id}")]
        public async Task Put(CancellationToken cancellationToken, UserEditRequestModel eventEditRequest, int id) =>
            await _userService.UpdateAsync(cancellationToken, eventEditRequest, id).ConfigureAwait(false);

        //2. ------------------------------ადმინისთვის--------------------------------------

        //TODO ეიპიაიში არასაჭირო
        //[HttpGet("{id}")]
        //public async Task<UserResponseForAdminModel> GetUserById(CancellationToken cancellationToken, int id) =>
        //    await _userService.GetUserByIdAsync(cancellationToken, id).ConfigureAwait(false);

        //[Route("GetActive")]
        //[HttpGet]
        //public async Task<List<UserResponseForAdminModel>> GetAllActiveUsers(CancellationToken cancellationToken) =>
        //    await _userService.GetAllActiveUsersAsync(cancellationToken).ConfigureAwait(false);

    }
}
