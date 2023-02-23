using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Subtasks;
using Todo.Application.Subtasks.Requests;
using Todo.Application.Subtasks.Responses;
using Todo.Application.Todos;
using Todo.Application.Todos.Requests;
using Todo.Application.Todos.Responses;
using Todo.Domain;
using Todo.Domain.Users;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _todoService;
        private readonly ISubtaskService _subtaskService;
        private readonly int _userId;

        public ToDoController(IToDoService todoServ, ISubtaskService subtaskServ, IHttpContextAccessor accessor)
        {
            _todoService = todoServ;
            _subtaskService = subtaskServ;
            var IdClaim = accessor.HttpContext.User.Claims.Single(x => x.Type == "UserId");
            _userId = int.Parse(IdClaim.Value);
        }

        /// <summary>
        /// Create a ToDo item for your User
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="todoCreateRequest"></param>
        /// <returns></returns>
        /// <remarks>
        /// Example:
        /// 
        ///     POST /ToDo
        ///     {
        ///         "title": "Task1",
        ///         "targetCompletionDate": "2023-02-22T10:52:04.943Z",
        ///         "subtasks": [
        ///             {
        ///                 "title": "Subtask1"
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task Post(CancellationToken cancellationToken, ToDoRequestModel todoCreateRequest)
        {
            await _todoService.CreateAsync(cancellationToken, todoCreateRequest, _userId);
        }

        /// <summary>
        /// Get all ToDos of your User
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        /// <remarks>
        /// You can filter ToDos by Status. If you don't choose any, it will return all of the ToDos.
        /// 
        ///     0 - Active
        ///     1 - Done
        ///     2 - Deleted
        /// Note that deleted ToDos are impossible to retrieve.
        /// </remarks>
        [HttpGet]
        public async Task<List<ToDoResponseModel>> GetAll(CancellationToken cancellationToken, Status status)
        {
            return await _todoService.GetAllAsync(cancellationToken, _userId, status);
        }

        /// <summary>
        /// Get a specific ToDo.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Note that deleted ToDos are impossible to retrieve.
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<ToDoResponseModel> Get(CancellationToken cancellationToken, int id)
        {
            return await _todoService.GetAsync(cancellationToken, id, _userId);
        }

        /// <summary>
        /// Update a specific ToDo.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="todoPutRequest"></param>
        /// <returns></returns>
        /// <remarks>
        /// Example:
        /// Fields available to update are Title and TargetCompletionDate.
        /// 
        ///     PUT /ToDo
        ///     {
        ///         "id": 1,
        ///         "title": "UpdatedTask1",
        ///         "targetCompletionDate": "2023-02-23T10:52:04.943Z"
        ///     }
        /// Note that deleted ToDos are impossible to update.
        /// </remarks>
        [HttpPut]
        public async Task Put(CancellationToken cancellationToken, ToDoRequestPutModel todoPutRequest)
        {
            await _todoService.UpdateAsync(cancellationToken, todoPutRequest, _userId);
        }

        /// <summary>
        /// Update the status of a ToDo.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="todoStatusRequest"></param>
        /// <returns></returns>
        /// <remarks>
        /// Example:
        /// Change the status of a specific ToDo to Done.
        /// 
        ///     PUT /ToDo
        ///     {
        ///         "id": 1,
        ///         "status": 1
        ///     }
        /// Note that you can only set status field to 1 (DONE).
        /// </remarks>
        [HttpPost("PostTodoStatusUpdate")]
        public async Task PostStatus(CancellationToken cancellationToken, TodoStatusRequestModel todoStatusRequest)
        {
            await _todoService.UpdateStatusAsync(cancellationToken, todoStatusRequest, _userId);
        }

        /// <summary>
        /// Patch a specific field of a specific ToDo
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="patchDocument"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Example:
        /// 
        ///     PATCH /ToDo
        ///     {
        ///         "path": "/Title",
        ///         "op": "replace",
        ///         "value": "PatchedTask1"
        ///     }
        /// </remarks>
        [HttpPatch("{id}")]
        public async Task Patch(CancellationToken cancellationToken, [FromBody] JsonPatchDocument patchDocument, [FromRoute] int id)
        {
            await _todoService.PatchAsync(cancellationToken, patchDocument, id, _userId);
        }

        /// <summary>
        /// Delete a specific ToDo.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete(CancellationToken cancellationToken, int id)
        {
            await _todoService.DeleteAsync(cancellationToken, id, _userId);
        }

        /// <summary>
        /// Create a subtask for your ToDo.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="subPostRequest"></param>
        /// <returns></returns>
        /// <remarks>
        /// Example:
        /// 
        ///     POST /Subtask
        ///     {
        ///         "title": "Subtask2",
        ///         "toDoId": 1
        ///     }
        /// </remarks>
        [HttpPost("PostSubtask")]
        public async Task PostSubtask(CancellationToken cancellationToken, SubtaskPostRequestModel subPostRequest)
        {
            await _subtaskService.CreateAsync(cancellationToken, subPostRequest, _userId);
        }

        /// <summary>
        /// Get all Subtasks of your ToDo.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="todoId"></param>
        /// <returns></returns>
        /// <remarks>
        /// Note that deleted ToDos are impossible to retrieve.
        /// </remarks>
        [HttpGet(("GetAllSubtasks"))]
        public async Task<List<SubtaskResponseModel>> GetAllSubtasks(CancellationToken cancellationToken, int todoId)
        {
            return await _subtaskService.GetAllAsync(cancellationToken, _userId, todoId);
        }


        /// <summary>
        /// Get a specific Subtask.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetSubtask/{id}")]
        public async Task<SubtaskResponseModel> GetSubtask(CancellationToken cancellationToken, int id)
        {
            return await _subtaskService.GetAsync(cancellationToken, id, _userId);
        }

        /// <summary>
        /// Update a specific Subtask.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="subPutRequest"></param>
        /// <returns></returns>
        /// <remarks>
        /// Example:
        /// 
        ///     PUT /Subtask
        ///     {
        ///         "id": 2,
        ///         "title": "UpdatedSubtask2"
        ///     }
        /// </remarks>
        [HttpPut("PutSubtask")]
        public async Task PutSubtask(CancellationToken cancellationToken, SubtaskPutRequestModel subPutRequest)
        {
            await _subtaskService.UpdateAsync(cancellationToken, subPutRequest, _userId);
        }

        
        /// <summary>
        /// Delete a specific Subtask.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteSubtask/{id}")]
        public async Task DeleteSubtask(CancellationToken cancellationToken, int id)
        {
            await _subtaskService.DeleteAsync(cancellationToken, id, _userId);
        }

    }
}

