namespace Epila.Ph.Api.Data.Entity
{
    public class QueueType : BaseEntity
    {
        public long Id { get; set; }
        public string QueueTypeName { get; set; }
        public string QueueTypeDescription { get; set; }
        public bool IsActive { get; set; }
    }
}
