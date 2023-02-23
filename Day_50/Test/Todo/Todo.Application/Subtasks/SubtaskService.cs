using System;
using Mapster;
using Todo.Application.ExceptionHandling.CustomExceptions;
using Todo.Application.Subtasks.Repositories;
using Todo.Application.Subtasks.Requests;
using Todo.Application.Subtasks.Responses;
using Todo.Application.Todos.Repositories;
using Todo.Application.Todos.Responses;
using Todo.Domain;
using Todo.Domain.Subtasks;
using Todo.Domain.Todos;
using Todo.Domain.Users;

namespace Todo.Application.Subtasks
{
	public class SubtaskService : ISubtaskService
	{
        private readonly ISubtaskRepository _subtaskRepo;
        private readonly IToDoRepository _taskRepo;

        public SubtaskService(ISubtaskRepository subtaskRepo, IToDoRepository taskRepo)
		{
            _subtaskRepo = subtaskRepo;
            _taskRepo = taskRepo;
        }

        public async Task CreateAsync(CancellationToken cancellationToken, SubtaskPostRequestModel subPostRequest, int userId)
        {
            var todoExists = await _taskRepo.Exists(cancellationToken, subPostRequest.ToDoId);
            if (!todoExists)
                throw new TodoNotFoundException();

            var todoToGet = await _taskRepo.GetAsync(cancellationToken, subPostRequest.ToDoId);
            if (todoToGet.UserId != userId)
                throw new WrongUserTaskException();

            if (todoToGet.Status == Status.Deleted)
            {
                throw new StatusDeletedException();
            }

            var subToInsert = subPostRequest.Adapt<Subtask>();
            await _subtaskRepo.CreateAsync(cancellationToken, subToInsert, todoToGet);
        }

        public async Task<List<SubtaskResponseModel>> GetAllAsync(CancellationToken cancellationToken, int userId, int todoId)
        {
            var todoExists = await _taskRepo.Exists(cancellationToken, todoId);
            if (!todoExists)
                throw new TodoNotFoundException();

            var todoToGet = await _taskRepo.GetAsync(cancellationToken, todoId);
            if (todoToGet.UserId != userId)
                throw new WrongUserTaskException();

            if (todoToGet.Status == Status.Deleted)
            {
                throw new StatusDeletedException();
            }

            return todoToGet.Subtasks.Adapt<List<SubtaskResponseModel>>().ToList();
        }

        public async Task<SubtaskResponseModel> GetAsync(CancellationToken cancellationToken, int id, int userId)
        {
            var subExists = await _subtaskRepo.Exists(cancellationToken, id);
            if (!subExists)
                throw new SubtaskNotFoundException();

            var subToGet = await _subtaskRepo.GetAsync(cancellationToken, id);

            var todoToGet = await _taskRepo.GetAsync(cancellationToken, subToGet.ToDoId);
            if (todoToGet.UserId != userId)
                throw new WrongUserTaskException();

            if (todoToGet.Status == Status.Deleted) 
            {
                throw new StatusDeletedException();
            }

            return subToGet.Adapt<SubtaskResponseModel>();
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, SubtaskPutRequestModel subPutRequest, int userId)
        {
            var subExists = await _subtaskRepo.Exists(cancellationToken, subPutRequest.Id);
            if (!subExists)
                throw new SubtaskNotFoundException();

            var subToGet = await _subtaskRepo.GetAsync(cancellationToken, subPutRequest.Id);

            var todoToGet = await _taskRepo.GetAsync(cancellationToken, subToGet.ToDoId);
            if (todoToGet.UserId != userId)
                throw new WrongUserTaskException();

            if (todoToGet.Status == Status.Deleted) 
            {
                throw new StatusDeletedException();
            }

            var subToUpdate = subPutRequest.Adapt<Subtask>();

            await _subtaskRepo.UpdateAsync(cancellationToken, subToUpdate);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id, int userId)
        {
            var subExists = await _subtaskRepo.Exists(cancellationToken, id);
            if (!subExists)
                throw new SubtaskNotFoundException();

            var subToGet = await _subtaskRepo.GetAsync(cancellationToken, id);

            var todoToGet = await _taskRepo.GetAsync(cancellationToken, subToGet.ToDoId);
            if (todoToGet.UserId != userId)
                throw new WrongUserTaskException();

            if (todoToGet.Status == Status.Deleted) 
            {
                throw new StatusDeletedException();
            }

            await _subtaskRepo.DeleteAsync(cancellationToken, id);
        }
    }
}

