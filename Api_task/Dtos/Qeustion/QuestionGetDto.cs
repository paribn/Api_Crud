using Api_task.Dtos.Option;
using FluentValidation;

namespace Api_task.Dtos.Qeustion
{
    public class QuestionGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Points { get; set; }
        public List<OptionGetDto> Options { get; set; }

        public class QuizDtoValidator : AbstractValidator<QuestionGetDto>
        {
            public QuizDtoValidator()
            {
                RuleFor(x => x.Id)
                   .NotEmpty().WithMessage("Something went wrong")
                   .NotNull().WithMessage("Required!");

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
