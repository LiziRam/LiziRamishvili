using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Todo.API.Infrastructure.Auth.JWT;
using Todo.Application.Users;
using Todo.Application.Users.Responses;
using Todo.Application.Users.Requests;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOptions<JWTConfiguration> _options;

        public UserController(IUserService userService, IOptions<JWTConfiguration> options)
        {
            _userService = userService;
            _options = options;
        }

        /// <summary>
        /// Register a User
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="userCreateRequest"></param>
        /// 
        /// <remarks>
        /// Example:
        /// 
        ///     POST /User
        ///     {
        ///       "username": "FirstUser",
        ///       "password": "Password123"
        ///     }
        /// </remarks>
        [Route("Register")]
        [HttpPost]
        public async Task<UserResponseModel> Register(CancellationToken cancellationToken, UserCreateRequestModel userCreateRequest)
        {
            return await _userService.CreateAsync(cancellationToken, userCreateRequest);
        }


        /// <summary>
        /// Log in as a User
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        ///
        /// <remarks>
        /// Example: 
        /// 
        ///     POST /User/PostToLogin
        ///     {
        ///       "username": "FirstUser",
        ///       "password": "Password123"
        ///     }
        /// After successful authentication, returns JWT Token.
        /// </remarks>

        [Route("LogIn")]
        [HttpPost]
        public async Task<string> LogIn(CancellationToken cancellationToken, UserLoginRequestModel userLoginRequest)
        {
            var username = await _userService.AuthenticateAsync(cancellationToken, userLoginRequest.Username, userLoginRequest.Password);
            var userId = await _userService.GetIdByUsername(cancellationToken, userLoginRequest.Username);

            return JWTHelper.GenerateSecurityToken(username, userId, _options);
        }
    }
}

