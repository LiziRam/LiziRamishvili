using System;
using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.Application.Addresses;
using PizzaRestaurant.Application.Addresses.Requests;
using PizzaRestaurant.Application.Addresses.Responses;

namespace PizzaRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get a specific Address with Id
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
        /// Get all Addresses
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<AddressResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Create an Address
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 
        /// <remarks>
        /// Note that AddressId will be generated and kept in the DB.
        /// You can see this address's Id in the united data,
        /// which is approachable by getting all data (GET without Id). 
        ///  
        ///     POST /Address
        ///     {
        ///         "userId": 1,
        ///         "city": "ბათუმი",
        ///         "country": "საქართველო",
        ///         "region": "აჭარა",
        ///         "description": "გამსახურდიას 9"
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task Post(CancellationToken cancellationToken, AddressRequestModel request)
        {
            await _service.CreateAsync(cancellationToken, request);
        }

        /// <summary>
        /// Update an Address with Id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        ///
        /// <remarks>
        /// Note that AddressId will be generated and kept in the DB.
        /// You can see this address's Id in the united data,
        /// which is approachable by getting all data (GET without Id). 
        ///  
        ///     PUT /Address
        ///     {
        ///         "userId": 2,
        ///         "city": "ქუთაისი",
        ///         "country": "საქართველო",
        ///         "region": "იმერეთი",
        ///         "description": "მელიქიშვილის 23"
        ///     }
        /// IDs that are in the starter DB: 1, 2
        /// </remarks>
        [HttpPut("{id}")]
        public async Task Put(CancellationToken cancellationToken, AddressRequestModel request, int id)
        {
            await _service.UpdateAsync(cancellationToken, request, id);
        }

        /// <summary>
        /// Delete an Address with Id
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

