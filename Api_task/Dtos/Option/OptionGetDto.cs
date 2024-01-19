using FluentValidation;

namespace Api_task.Dtos.Option
{
    public class OptionGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public class OptionDtoValidator : AbstractValidator<OptionGetDto>
        {
            public OptionDtoValidator()
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
