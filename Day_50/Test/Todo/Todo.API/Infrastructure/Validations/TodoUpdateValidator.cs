using System;
using FluentValidation;
using Todo.Application.Todos.Requests;

namespace Todo.API.Infrastructure.Validations
{
	public class TodoUpdateValidator : AbstractValidator<ToDoRequestPutModel>
    {
		public TodoUpdateValidator()
		{
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Task title can't be empty and it's length can't be more than 100.");

        }
	}
}

