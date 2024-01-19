using Api_task.Dtos.Qeustion;
using FluentValidation;

namespace Api_task.Dtos.Quiz
{
    public class QuizDetailedGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public List<QuestionGetDto> Questions { get; set; }


        public class QuizDtoValidator : AbstractValidator<QuizDetailedGetDto>
        {
            public QuizDtoValidator()
            {
                RuleFor(x => x.Id)
                    .NotEmpty().WithMessage("Something went wrong")
                    .NotNull().WithMessage("Required!");

                RuleFor(x => x.Name)
                  .MinimumLength(3).WithMessage("Your length must be at least 3.")
                  .MaximumLength(255).WithMessage("Your  length must not exceed 255.");

                RuleFor(x => x.CreationDate)
                 .NotEmpty().WithMessage("Required field")
                 .LessThan(p => DateTime.Now).WithMessage("a data deve estar no passado");
            }
        }
    }
}
