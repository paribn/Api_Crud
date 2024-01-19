using FluentValidation;

namespace Api_task.Dtos.Account
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }


        public class LoginDtoValidator : AbstractValidator<LoginDto>
        {
            public LoginDtoValidator()
            {
                RuleFor(x => x.Username)
                    .MinimumLength(5).WithMessage("Minimum 5 chars required!")
                    .NotNull().WithMessage("Required!")
                    .MaximumLength(255).WithMessage("Maximum 255 chars required!");

                RuleFor(x => x.Password)
                   .NotEmpty().WithMessage("Your password cannot be empty")
                  .MinimumLength(4).WithMessage("Your password length must be at least 4.")
                  .MaximumLength(16).WithMessage("Your password length must not exceed 16.");
            }
        }

    }
}
