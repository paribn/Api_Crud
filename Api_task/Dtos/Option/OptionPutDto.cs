using FluentValidation;

namespace Api_task.Dtos.Option
{
    public class OptionPutDto
    {
        public string Name { get; set; }
        public bool IsCorrect { get; set; }

        public class OptionDtoValidator : AbstractValidator<OptionPutDto>
        {
            public OptionDtoValidator()
            {


                RuleFor(x => x.Name)
                  .MinimumLength(3).WithMessage("Your length must be at least 3.")
                  .MaximumLength(255).WithMessage("Your  length must not exceed 255.");

            }
        }
    }
}
