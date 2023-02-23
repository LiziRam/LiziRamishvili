using System;
using FluentValidation;
using Todo.Application.Todos.Requests;
using Todo.Application.Users.Requests;

namespace Todo.API.Infrastructure.Validations
{
	public class TodoCreateValidator : AbstractValidator<ToDoRequestModel>
    {
		public TodoCreateValidator()
		{
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Task title can't be empty and it's length can't be more than 100.");
        }
	}
}

