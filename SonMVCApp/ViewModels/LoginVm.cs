using FluentValidation;

namespace SonMVCApp.ViewModels
{
    public class LoginVm
    {
        public string EmailOrUserName { get; set; }
        public string Password { get; set; }


    }
    public class LoginValidator : AbstractValidator<LoginVm>
    {
        public LoginValidator()
        {
            RuleFor(x => x.EmailOrUserName).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();


        }
    }
}