using FluentValidation;

namespace Epila.Ph.WebApi.DTO.Request
{
    public class QueueTypeRequest
    {
        public string QueueTypeName { get; set; }
        public string QueueTypeDescription { get; set; }
        public string UserName { get; set; }
    }

    public class QueueTypeRequestValidator : AbstractValidator<QueueTypeRequest>
    {
        public QueueTypeRequestValidator()
        {
            RuleFor(o => o.QueueTypeDescription).NotEmpty();
            RuleFor(o => o.QueueTypeName).NotEmpty();
            RuleFor(o => o.UserName).NotEmpty();
        }
    }
}
