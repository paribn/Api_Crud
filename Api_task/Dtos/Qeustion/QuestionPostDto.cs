using Api_task.Dtos.Option;
using FluentValidation;

namespace Api_task.Dtos.Qeustion
{
    public class QuestionPostDto
    {
        public string Name { get; set; }
        public decimal Points { get; set; }

        public List<OptionPostDto> Options { get; set; }

        public class QuizDtoValidator : AbstractValidator<QuestionPostDto>
        {
            public QuizDtoValidator()
            {

                RuleFor(x => x.Name)
                  .MinimumLength(3).WithMessage("Your length must be at least 3.")
                  .MaximumLength(255).WithMessage("Your  length must not exceed 255.");

                RuleFor(x => x.Points)
                    .InclusiveBetween(1, 100)
                    .NotEmpty();
            }
        }

    }
}
