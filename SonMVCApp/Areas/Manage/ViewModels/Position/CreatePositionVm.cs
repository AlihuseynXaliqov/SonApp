using FluentValidation;

namespace SonMVCApp.Areas.Manage.ViewModels.Position
{
    public class CreatePositionVm
    {
        public string Name { get; set; }

    }
    public class CreatePositionValidator : AbstractValidator<CreatePositionVm>
    {
        public CreatePositionValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().NotNull().WithMessage("Ad bos ola bilmez")
                .MinimumLength(4).WithMessage("Adin en az uzunluqu 4 olmalidir");
        }
    }
}
