﻿using System;
using FluentValidation;
using Todo.Application.Subtasks.Requests;

namespace Todo.API.Infrastructure.Validations
{
	public class SubtaskRequestValidator : AbstractValidator<SubtaskRequestModel>
    {
		public SubtaskRequestValidator()
		{
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Subtask title can't be empty and it's length can't be more than 100.");
        }
	}
}

