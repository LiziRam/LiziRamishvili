using System;
using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.Application;
using PizzaRestaurant.Application.Pizzas;
using PizzaRestaurant.Application.Pizzas.Requests;
using PizzaRestaurant.Application.Pizzas.Responses;

namespace PizzaRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _service;

		public PizzaController(IPizzaService service)
		{
            _service = service;
		}

        /// <summary>
        /// Get a specific Pizza with Id
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
        /// Get all Pizzas
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<PizzaResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Create a Pizza
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 
        /// <remarks>
        /// Note that PizzaId will be generated and kept in the DB.
        /// You can see this pizza's Id in the united data,
        /// which is approachable by getting all data (GET without Id). 
        ///  
        ///     POST /Pizza
        ///     {
        ///         "name": "Pineapple Pizza",
        ///         "price": 14.5,
        ///         "description": "Hawaiian pizza",
        ///         "caloryCount": 600
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task Post(CancellationToken cancellationToken, PizzaRequestModel request)
        {
            await _service.CreateAsync(cancellationToken, request);
        }

        /// <summary>
        /// Update a Pizza with Id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        ///
        /// <remarks>
        /// Note that PizzaId will be generated and kept in the DB.
        /// You can see this pizza's Id in the united data,
        /// which is approachable by getting all data (GET without Id). 
        ///  
        ///     PUT /Pizza
        ///     {
        ///         "name": "New Pepperoni",
        ///         "price": 14,
        ///         "description": "Double salami",
        ///         "caloryCount": 800
        ///     }
        /// IDs that are in the starter DB: 1, 2
        /// </remarks>
        [HttpPut("{id}")]
        public async Task Put(CancellationToken cancellationToken, PizzaRequestModel request, int id)
        {
            await _service.UpdateAsync(cancellationToken, request, id);
        }

        /// <summary>
        /// Delete a Pizza with Id
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

