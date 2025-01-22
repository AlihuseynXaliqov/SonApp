using FluentValidation;

namespace SonMVCApp.Areas.Manage.ViewModels.Position
{
    public class UpdatePositionVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class UpdatePositionValidator : AbstractValidator<UpdatePositionVm>
    {
        public UpdatePositionValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Ad bos ola bilmez")
                .MinimumLength(4).WithMessage("Adin en az uzunluqu 4 olmalidir");
        }
    }
}