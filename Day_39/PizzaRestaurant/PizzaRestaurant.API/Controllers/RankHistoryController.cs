using System;
using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.Application.RankHistories;
using PizzaRestaurant.Application.RankHistories.Requests;
using PizzaRestaurant.Application.RankHistories.Responses;

namespace PizzaRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankHistoryController : ControllerBase
	{
        private readonly IRankHistoryService _service;

        public RankHistoryController(IRankHistoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get a specific Rank with Id
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
        /// Get all Ranks
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<RankHistoryResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Create a Ranking
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 
        /// <remarks>
        /// Note that RankId will be generated and kept in the DB.
        /// You can see this ranks's Id in the united data,
        /// which is approachable by getting all data (GET without Id). 
        ///  
        ///     POST /Address
        ///     {
        ///         "userId": 1,
        ///         "pizzaId": 1,
        ///         "rank": 8
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task Post(CancellationToken cancellationToken, RankHistoryRequestModel request)
        {
            await _service.CreateAsync(cancellationToken, request);
        }
    }
}

