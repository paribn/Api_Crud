using FluentValidation;

namespace Api_task.Dtos.Account
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }



        public class RegisterDtoValidator : AbstractValidator<RegisterDto>
        {
            public RegisterDtoValidator()
            {
                RuleFor(x => x.FirstName)
               .MinimumLength(3).WithMessage("Minimum 3 chars required!")
               .NotNull().WithMessage("Required!")
               .MaximumLength(255).WithMessage("Maximum 255 chars required!");

                RuleFor(x => x.LastName)
                .MinimumLength(3).WithMessage("Minimum 3 chars required!")
                .NotNull().WithMessage("Required!")
                .MaximumLength(255).WithMessage("Maximum 255 chars required!");

                RuleFor(x => x.Username)
               .MinimumLength(4).WithMessage("Minimum 4 chars required!")
               .NotNull().WithMessage("Required!")
               .MaximumLength(255).WithMessage("Maximum 255 chars required!");

                RuleFor(x => x.Email)
                .MinimumLength(5).WithMessage("Minimum 5 chars required!")
                .NotNull().WithMessage("Email is Required!")
                .EmailAddress()
                .WithMessage("Invalid email address")
                .MaximumLength(255).WithMessage("Maximum 255 chars required!");

                RuleFor(x => x.Password)
              .NotEmpty().WithMessage("Your password cannot be empty")
              .MinimumLength(4).WithMessage("Your password length must be at least 4.")
              .MaximumLength(16).WithMessage("Your password length must not exceed 16.");




            }
        }

    }

}
