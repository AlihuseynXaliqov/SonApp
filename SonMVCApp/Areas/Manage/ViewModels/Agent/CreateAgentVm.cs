using FluentValidation;
using SonMVCApp.Areas.Manage.ViewModels.Position;

namespace SonMVCApp.Areas.Manage.ViewModels.Agent
{
    public class CreateAgentVm
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int PositionId { get; set; }
        public IFormFile? formFile { get; set; }
    }



    public class CreateAgentValidator : AbstractValidator<CreateAgentVm>
    {
        public CreateAgentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Ad bos ola bilmez")
                .MinimumLength(4).WithMessage("Adin en az uzunluqu 4 olmalidir");

            RuleFor(x => x.formFile).NotEmpty().NotNull().WithMessage("Sekil bos ola bilmez");
            RuleFor(x => x.PositionId).NotEmpty().NotNull().WithMessage("Position bos ola bilmez");


        }
    }
}
