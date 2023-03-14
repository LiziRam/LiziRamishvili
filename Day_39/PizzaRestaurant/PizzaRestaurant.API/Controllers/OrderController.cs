using System;
using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.Application.Orders;
using PizzaRestaurant.Application.Orders.Requests;
using PizzaRestaurant.Application.Orders.Responses;

namespace PizzaRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
	{
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get a specific Order with Id
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
        /// Get all Orders
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<OrderResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Create an Order
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 
        /// <remarks>
        /// Note that OrderId will be generated and kept in the DB.
        /// You can see this order's Id in the united data,
        /// which is approachable by getting all data (GET without Id). 
        ///  
        ///     POST /Address
        ///     {
        ///         "userId": 1,
        ///         "addressId": 1,
        ///         "pizzaId": 2
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task Post(CancellationToken cancellationToken, OrderRequestModel request)
        {
            await _service.CreateAsync(cancellationToken, request);
        }
    }
}

