using FluentValidation;

namespace Api_task.Dtos.Quiz
{
    public class QuizGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatinDate { get; set; }

        public class QuizDtoValidator : AbstractValidator<QuizGetDto>
        {
            public QuizDtoValidator()
            {
                RuleFor(x => x.Id)
                    .NotEmpty().WithMessage("Something went wrong")
                    .NotNull().WithMessage("Required!");

                RuleFor(x => x.Name)
                  .MinimumLength(3).WithMessage("Your length must be at least 3.")
                  .MaximumLength(255).WithMessage("Your  length must not exceed 255.");
            }
        }
    }
}
