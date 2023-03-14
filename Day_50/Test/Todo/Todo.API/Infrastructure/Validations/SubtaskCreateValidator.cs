using System;
using FluentValidation;
using Todo.Application.Subtasks.Requests;
using Todo.Application.Todos.Requests;

namespace Todo.API.Infrastructure.Validations
{
	public class SubtaskCreateValidator : AbstractValidator<SubtaskPostRequestModel>
    {
		public SubtaskCreateValidator()
		{
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Subtask title can't be empty and it's length can't be more than 100.");

            RuleFor(x => x.ToDoId)
                .NotEmpty()
                .WithMessage("ToDo Id field should not be empty.");
        }
	}
}

