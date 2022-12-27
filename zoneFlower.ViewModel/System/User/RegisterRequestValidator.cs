using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoneFlower.ViewModel.System.User
{
    public class RegisterRequestValidator:AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required")
                .MaximumLength(200).WithMessage("First name can not over 200 character");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required")
                .MaximumLength(200).WithMessage("Last name can not over 200 character");

            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100))
                .WithMessage("Birthday can not greater than 100 year");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email format not match");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone is required");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name to required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password to required").MinimumLength(6).WithMessage("Password is at least 6 charater");

            RuleFor(x => x).Custom((request, context) => {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Confirm password is not match");
                }
            });
                
   
        }

    }
    
}
