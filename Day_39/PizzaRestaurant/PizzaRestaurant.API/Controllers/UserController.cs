using System;
using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.Application.Users;
using PizzaRestaurant.Application.Users.Requests;
using PizzaRestaurant.Application.Users.Responses;

namespace PizzaRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
	{
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get a specific User with Id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        ///
        /// <remarks>
        /// IDs that are in the starter DB: 1, 2
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(CancellationToken cancellationToken, int id)
        {
            return Ok(await _service.GetAsync(cancellationToken, id));
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<UserResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Create a User
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 
        /// <remarks>
        /// Note that UserId will be generated and kept in the DB.
        /// You can see this user's Id in the united data,
        /// which is approachable by getting all data (GET without Id). 
        ///  
        ///     POST /User
        ///     {
        ///        "firstName": "მარიამ",
        ///        "lastName": "ნოზაძე",
        ///        "email": "mnoza23@tbc.ge",
        ///        "phoneNumber": "599234951",
        ///        "address": {
        ///                 "userId": 0,
        ///                 "city": "თელავი",
        ///                 "country": "საქართველო",
        ///                 "region": "კახეთი",
        ///                 "description": "წერეთლის 7"
        ///        }
        ///     }
        /// userId field within Address will change automatically according to the User who is the owner.
        /// Therefore, it does not matter what number will be entered in this field.
        /// </remarks>
        [HttpPost]
        public async Task Post(CancellationToken cancellationToken, UserRequestModel request)
        {
            await _service.CreateAsync(cancellationToken, request);
        }

        /// <summary>
        /// Update a User with Id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        ///
        /// <remarks>
        /// Note that UserId will be generated and kept in the DB.
        /// You can see this users's Id in the united data,
        /// which is approachable by getting all data (GET without Id). 
        ///  
        ///     PUT /User
        ///     {
        ///        "firstName": "თეკლა",
        ///        "lastName": "ვარდოსანიძე",
        ///        "email": "tvard23@tbc.ge",
        ///        "phoneNumber": "577896351",
        ///        "address": {
        ///                 "userId": 0,
        ///                 "city": "თელავი",
        ///                 "country": "საქართველო",
        ///                 "region": "კახეთი",
        ///                 "description": "ჭავჭავაძის 2"
        ///        }
        ///     }
        /// IDs that are in the starter DB: 1, 2.
        /// userId field within Address will change automatically according to the User who is the owner.
        /// Therefore, it does not matter what number will be entered in this field.
        /// </remarks>
        [HttpPut("{id}")]
        public async Task Put(CancellationToken cancellationToken, UserRequestModel request, int id)
        {
            await _service.UpdateAsync(cancellationToken, request, id);
        }

        /// <summary>
        /// Delete a User with Id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        ///
        /// <remarks>
        /// IDs that are in the starter DB: 1, 2
        /// </remarks>
        [HttpDelete("{id}")]
        public async Task Delete(CancellationToken cancellationToken, int id)
        {
            await _service.DeleteAsync(cancellationToken, id);
        }
    }
}

