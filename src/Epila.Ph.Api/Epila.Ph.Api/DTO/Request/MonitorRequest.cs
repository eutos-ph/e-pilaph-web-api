using FluentValidation;

namespace Epila.Ph.Api.DTO.Request
{
    public class MonitorRequest
    {
        public string MonitorName { get; set; }
        public string UserName { get; set; }
    }

    public class MonitorRequestValidator : AbstractValidator<MonitorRequest>
    {
        public MonitorRequestValidator()
        {
            RuleFor(o => o.MonitorName).NotEmpty();
            RuleFor(o => o.UserName).NotEmpty();
        }
    }
}
