using FluentValidation;

namespace Epila.Ph.WebApi.DTO.Request
{
    public class KioskRequest
    {
        public string KioskName { get; set; }
        public string KioskDescription { get; set; }
        public string UserName { get; set; }
    }

    public class KioskRequestValidator : AbstractValidator<KioskRequest>
    {
        public KioskRequestValidator()
        {
            RuleFor(o => o.KioskName).NotEmpty();
            RuleFor(o => o.UserName).NotEmpty();
        }
    }
}
