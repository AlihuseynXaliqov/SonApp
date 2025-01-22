using FluentValidation;

namespace SonMVCApp.Areas.Manage.ViewModels.Agent
{
    public class UpdateAgentVm
    {
        public int  Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public int PositionId { get; set; }
        public IFormFile? formFile { get; set; }
    }



    public class UpdateAgentValidator : AbstractValidator<UpdateAgentVm>
    {
        public UpdateAgentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad bos ola bilmez")
                .MinimumLength(4).WithMessage("Adin en az uzunluqu 4 olmalidir");

        }
    }
}