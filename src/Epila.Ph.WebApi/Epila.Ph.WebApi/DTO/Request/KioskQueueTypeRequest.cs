using FluentValidation;

namespace Epila.Ph.WebApi.DTO.Request
{
    public class KioskQueueTypeRequest
    {
        public int KioskId { get; set; }
        public int QueueTypeId { get; set; }
        public string ReferenceLink { get; set; }
        public string UserName { get; set; }
    }
    public class KioskQueueTypeRequestValidator : AbstractValidator<KioskQueueTypeRequest>
    {
        public KioskQueueTypeRequestValidator()
        {
            RuleFor(o => o.UserName).NotEmpty();
            RuleFor(o => o.KioskId).NotEmpty();
            RuleFor(o => o.QueueTypeId).NotEmpty();
        }
    }
}
