using System;
using FluentValidation;
using Todo.Application.Subtasks.Requests;

namespace Todo.API.Infrastructure.Validations
{
	public class SubtaskUpdateValidator : AbstractValidator<SubtaskPutRequestModel>
	{
		public SubtaskUpdateValidator()
		{
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Subtask title can't be empty and it's length can't be more than 100.");

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Subtask Id field should not be empty.");
        }
	}
}

