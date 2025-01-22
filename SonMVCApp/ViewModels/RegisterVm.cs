﻿using FluentValidation;

namespace SonMVCApp.ViewModels
{
    public class RegisterVm
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
    public class RegisterValidator : AbstractValidator<RegisterVm>
    {
        public RegisterValidator()
        {
            RuleFor(x=>x.Name).NotNull().NotEmpty().WithMessage("Ad bos ola bilmez")
                .MinimumLength(3).WithMessage("Adin uzunluq en az 3 ola biler");
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("Ad bos ola bilmez")
               .MinimumLength(3).WithMessage("Adin uzunluq en az 3 ola biler");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email bos ola bilmez")
                .EmailAddress().WithMessage("Email duzgun deyil");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password bos ola bilmez")
                .Matches("[A-Z]").WithMessage("Parolda en az 1 boyuk herf olmalidi")
                .Matches("[a-z]").WithMessage("Parolda en az 1 kicik herf olmalidi")
                .Matches("[0-9]").WithMessage("Parolda en az 1 reqem olmalidi")
                .Matches("^[A-Za-z0-9]").WithMessage("Parolda en az 1 simvol olmalidi");
            RuleFor(x => x).Must(x => x.Password == x.ConfirmPassword).WithMessage("Parol eyni deyil");



        }
    }
}
