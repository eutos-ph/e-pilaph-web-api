namespace Epila.Ph.WebApi.Data.Entity
{
    public class QueueType : EntityBase
    {
        public string QueueTypeName { get; set; }
        public string QueueTypeDescription { get; set; }
        public bool IsActive { get; set; }
    }
}
