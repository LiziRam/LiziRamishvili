using System;
using System.Web.Mvc;
using Mapster;
using Microsoft.AspNetCore.JsonPatch;
using Todo.Application.ExceptionHandling.CustomExceptions;
using Todo.Application.Todos.Repositories;
using Todo.Application.Todos.Requests;
using Todo.Application.Todos.Responses;
using Todo.Domain;
using Todo.Domain.Todos;
using Todo.Domain.Users;

namespace Todo.Application.Todos
{

    public class ToDoService : IToDoService
    {
        private IToDoRepository _repo;

        public ToDoService(IToDoRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateAsync(CancellationToken cancellationToken, ToDoRequestModel todoCreateRequest, int userId)
        {
            var todoToInsert = todoCreateRequest.Adapt<ToDo>();
            await _repo.CreateAsync(cancellationToken, todoToInsert, userId);
        }

        public async Task<List<ToDoResponseModel>> GetAllAsync(CancellationToken cancellationToken, int userId, Status status)
        {
            if(status == Status.Deleted)
            {
                throw new StatusDeletedException();
            }
            var todosToGet = await _repo.GetAllAsync(cancellationToken, userId, status);
            var todosResponse = todosToGet.Adapt<List<ToDoResponseModel>>();
            return todosResponse.ToList(); 
        }

        public async Task<ToDoResponseModel> GetAsync(CancellationToken cancellationToken, int id, int userId)
        {
            var todoExists = await _repo.Exists(cancellationToken, id);
            if (!todoExists)
                throw new TodoNotFoundException();

            var todoToGet = await _repo.GetAsync(cancellationToken, id);
            if (todoToGet.UserId != userId)
                throw new WrongUserTaskException();

            if(todoToGet.Status == Status.Deleted)
            {
                throw new StatusDeletedException();
            }
            return todoToGet.Adapt<ToDoResponseModel>();
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, ToDoRequestPutModel todoPutRequest, int userId)
        {
            var todoExists = await _repo.Exists(cancellationToken, todoPutRequest.Id);
            if (!todoExists)
                throw new TodoNotFoundException(); 

            var todoToGet = await _repo.GetAsync(cancellationToken, todoPutRequest.Id);
            if (todoToGet.UserId != userId)
                throw new WrongUserTaskException();

            if (todoToGet.Status == Status.Deleted) 
            {
                throw new StatusDeletedException();
            }

            var taskToUpdate = todoPutRequest.Adapt<ToDo>();

            await _repo.UpdateAsync(cancellationToken, taskToUpdate);
        }

        public async Task UpdateStatusAsync(CancellationToken cancellationToken, TodoStatusRequestModel todoStatusRequest, int userId)
        {
            var todoExists = await _repo.Exists(cancellationToken, todoStatusRequest.Id);
            if (!todoExists)
                throw new TodoNotFoundException();

            var todoToGet = await _repo.GetAsync(cancellationToken, todoStatusRequest.Id);
            if (todoToGet.UserId != userId)
                throw new WrongUserTaskException();

            if (todoToGet.Status == Status.Deleted) 
            {
                throw new StatusDeletedException();
            }

            if((int)todoStatusRequest.Status != 1) {
                throw new Exception("Status to be updated can only be 1 (Done)");
            }

            var taskToUpdateStatus = todoStatusRequest.Adapt<ToDo>();

            await _repo.UpdateStatusAsync(cancellationToken, taskToUpdateStatus);
        }

        public async Task PatchAsync(CancellationToken cancellationToken, JsonPatchDocument patchDocument, int id, int userId)
        {
            var todoExists = await _repo.Exists(cancellationToken, id);
            if (!todoExists)
                throw new TodoNotFoundException();

            var todoToGet = await _repo.GetAsync(cancellationToken, id);
            if (todoToGet.UserId != userId)
                throw new WrongUserTaskException();

            if (todoToGet.Status == Status.Deleted) 
            {
                throw new StatusDeletedException();
            }
            await _repo.PatchAsync(cancellationToken, patchDocument, id);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id, int userId)
        {
            var todoExists = await _repo.Exists(cancellationToken, id);
            if (!todoExists)
                throw new TodoNotFoundException();

            var todoToGet = await _repo.GetAsync(cancellationToken, id);
            if (todoToGet.UserId != userId)
                throw new WrongUserTaskException();

            if (todoToGet.Status == Status.Deleted)
            {
                throw new StatusDeletedException();
            }

            await _repo.DeleteAsync(cancellationToken, id);
        }
    }
}

