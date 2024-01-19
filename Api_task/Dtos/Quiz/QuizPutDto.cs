using FluentValidation;

namespace Api_task.Dtos.Quiz
{
    public class QuizPutDto
    {
        public string Name { get; set; }

        public class QuizDtoValidator : AbstractValidator<QuizPutDto>
        {
            public QuizDtoValidator()
            {

                RuleFor(x => x.Name)
                  .MinimumLength(3).WithMessage("Your length must be at least 3.")
                  .MaximumLength(255).WithMessage("Your  length must not exceed 255.");
            }
        }
    }
}
