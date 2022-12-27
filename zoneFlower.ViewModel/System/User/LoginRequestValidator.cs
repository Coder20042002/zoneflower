using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace zoneFlower.ViewModel.System.User
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("User name to required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password to required").MinimumLength(6).WithMessage("Password is at least 6 charater");
        }
    }
}
